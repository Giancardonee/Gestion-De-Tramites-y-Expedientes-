using System.Data.Common;
using System.Numerics;
using SGE.Aplicacion;

namespace SGE.Repositorios;

public class RepositorioExpediente(SGEcontext context) : IExpedienteRepositorio
{
    public void ExpedienteAlta(Expediente e)
    {
        context.Add(e);
        context.SaveChanges();
    }

    // tener en cuenta que hay que dar de baja todos sus tramites. ESTO TODAVIA NO LO HICE. ACA HAY QUE USAR UN DELETE EN CASCADA
    public void ExpedienteBaja(int idBorrarExpediente)
    {
        var expedienteBorrar = context.Expedientes.Where(e => e.IdExpediente == idBorrarExpediente).SingleOrDefault();
        if (expedienteBorrar != null)// es porque existe el expediente.
        {
            context.Remove(expedienteBorrar);
            context.SaveChanges();
        }
        else
        {
            throw new RepositorioException(
                "ExpedienteBaja: El expediente que se intenta eliminar no existe.");
        }
    }

    public void ExpedienteModificacion(Expediente eModificar)
    {
        var expedienteModificar = context.Expedientes.Where(e => e.IdExpediente == eModificar.IdExpediente).SingleOrDefault();
        if (expedienteModificar != null)
        {
            expedienteModificar.Caratula = eModificar.Caratula;
            expedienteModificar.Estado = eModificar.Estado;
            context.SaveChanges();
        }
        else
            throw new RepositorioException();
    }

    public Expediente? ExpedienteConsultaPorId(int IdExpedienteBuscado)
    {
        var expedienteBuscado = context.Expedientes.Where(e => e.IdExpediente == IdExpedienteBuscado).SingleOrDefault();
        if (expedienteBuscado != null)
        {
            return expedienteBuscado;
        }
        else
        {
            throw new RepositorioException("ExpedienteConsultaPorId: el expediente no existe.");
        }
    }

    public List<Expediente> ExpedienteConsultaTodos()
    {
        List<Expediente> expedientes = context.Expedientes.ToList();
        if (expedientes.Count == 0)
            throw new RepositorioException("ExpedienteConsultaTodos: no se encontraron expedientes.");
        return expedientes;
    }
}
