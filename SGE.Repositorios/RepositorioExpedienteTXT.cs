using System.Numerics;
using SGE.Aplicacion;

namespace SGE.Repositorios;

public class RepositorioExpedienteTXT : IExpedienteRepositorio
{
    static readonly string _nombreArch = "Expedientes.txt";
    static int contadorExpedientes = contadorActual();

    public void ExpedienteAlta(Expediente e)
    {
        using var sw = new StreamWriter(_nombreArch, true);
        e.IdExpediente = ++contadorExpedientes;
        escribirValores(e, sw);
    }

    public void ExpedienteBaja(int idBorrarExpediente)
    {

        bool encontre = false;
        List<Expediente> listaExpediente = new List<Expediente>();
        using var sr = new StreamReader(_nombreArch, true);
        while (!sr.EndOfStream)
        {
            Expediente eActual = leerExpediente(sr);
            if (eActual.IdExpediente != idBorrarExpediente)
                listaExpediente.Add(eActual);
            else
                encontre = true;
        }
        if (encontre)
        {
            sr.Dispose();
            actualizarArchivo(listaExpediente);
        }
        else
            throw new RepositorioException(
                "ExpedienteBaja: El expediente que se intenta eliminar no existe."
            );
    }

    public void ExpedienteModificacion(Expediente eModificar)
    {
        bool encontre = false;
        List<Expediente> listaExpediente = new List<Expediente>();
        using var sr = new StreamReader(_nombreArch, true);
        while (!sr.EndOfStream)
        {
            Expediente eActual = leerExpediente(sr);
            if (eActual.IdExpediente == eModificar.IdExpediente)
            {
                eActual.Caratula = eModificar.Caratula;
                eActual.Estado = eModificar.Estado;
                encontre = true;
            }
            listaExpediente.Add(eActual);
        }
        if (encontre)
        {
            sr.Dispose();
            actualizarArchivo(listaExpediente);
        }
        else
            throw new RepositorioException();
    }

    public Expediente? ExpedienteConsultaPorId(int IdExpediente)
    {

        Expediente resultado = new Expediente();
        using var sr = new StreamReader(_nombreArch, true);
        resultado = leerExpediente(sr);
        while (!sr.EndOfStream && resultado.IdExpediente != IdExpediente)
        {
            resultado = leerExpediente(sr);
        }
        if (resultado.IdExpediente == IdExpediente)
        {
            return resultado;
        }
        else
        {
            throw new RepositorioException("ExpedienteConsultaPorId: el expediente no existe.");
        }
    }

    public List<Expediente> ExpedienteConsultaTodos()
    {
        List<Expediente> expedientes = new List<Expediente>();
        using var sr = new StreamReader(_nombreArch, true);
        while (!sr.EndOfStream)
        {
            expedientes.Add(leerExpediente(sr));
        }
        if (expedientes.Count == 0)
            throw new RepositorioException();
        return expedientes;
    }

    //==================== metodos privados
    private Expediente leerExpediente(StreamReader sr)
    {
        Expediente e = new Expediente();
        string? id = sr.ReadLine();
        if (!String.IsNullOrEmpty(id))
        {
            e.IdExpediente = int.Parse(id);
            e.FechaCreacion = DateTime.Parse(sr.ReadLine() ?? "");
            e.FechaModificacion = DateTime.Parse(sr.ReadLine() ?? "");
            e.Caratula = sr.ReadLine() ?? "";
            e.Estado = Enum.Parse<EstadoExpediente>(sr.ReadLine() ?? "");
            e.UsuarioUltModificacion = int.Parse(sr.ReadLine() ?? "");
        }
        else
        {
            throw new RepositorioException("leerExpediente: El archivo está vacío");
        }
        return e;
    }

    private void actualizarArchivo(List<Expediente> listaExpedientes)
    {
        if (File.Exists(_nombreArch))
        {
            File.Delete(_nombreArch);
            using var sw = new StreamWriter(_nombreArch, true);
            foreach (Expediente e in listaExpedientes)
            {
                escribirValores(e, sw);
            }
        }
    }

    private static int contadorActual()
    {
        using var sr = new StreamReader(_nombreArch, true);
        int ultimoId = 0;
        while (!sr.EndOfStream)
        {
            string? id = sr.ReadLine();
            if (!String.IsNullOrEmpty(id))
            {
                ultimoId = Int32.Parse(id);
                for (int i = 1; i < 6; i++)
                {
                    sr.ReadLine();
                }
            }
        }
        return ultimoId;
    }

    private void escribirValores(Expediente e, StreamWriter sw)
    {
        sw.WriteLine(e.IdExpediente);
        sw.WriteLine(e.FechaCreacion);
        sw.WriteLine(e.FechaModificacion);
        sw.WriteLine(e.Caratula);
        sw.WriteLine(e.Estado);
        sw.WriteLine(e.UsuarioUltModificacion);
    }
}
