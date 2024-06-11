namespace SGE.Aplicacion;

public class CasoDeUsoExpedienteConTramitesAsociados(IExpedienteRepositorio repoExpediente, ITramiteRepositorio repoTramite)
{
    public Expediente? Ejecutar(int idExpediente)
    {
        Expediente? exp = repoExpediente.ExpedienteConsultaPorId(idExpediente);
        try
        {
        if (exp != null)
            exp.listaDeTramites = repoTramite.TramiteConsultaPorIdExpediente(idExpediente);
        }
        catch (RepositorioException ex)
        {
            Console.WriteLine(ex.Message);
        }
        return exp;
    }
}
