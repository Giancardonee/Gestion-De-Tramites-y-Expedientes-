namespace SGE.Aplicacion;

public class CasoDeUsoExpedienteConsultaTodos(IExpedienteRepositorio repoExpediente)
{
    public List<Expediente> Ejecutar()
    {
        List<Expediente> listaExpedientes = new List<Expediente>();
        try
        {
            listaExpedientes = repoExpediente.ExpedienteConsultaTodos();
        }
        catch (RepositorioException e)
        {
            Console.WriteLine(e.Message);
        }
        return listaExpedientes;
    }


}
