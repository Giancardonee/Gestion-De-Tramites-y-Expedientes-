namespace SGE.Aplicacion;

public class CasoDeUsoExpedienteConsultaPorId(IExpedienteRepositorio repoExpediente)
{
    public Expediente? Ejecutar(int idConsulta)
    {
        Expediente? expediente = new Expediente();
        try
        {
            expediente = repoExpediente.ExpedienteConsultaPorId(idConsulta);
        }
        catch (RepositorioException e)
        {
            Console.WriteLine(e.Message);
        }

        return expediente;
    }
}
