namespace SGE.Aplicacion;

public class CasoDeUsoTramiteConsultaPorId(ITramiteRepositorio repoTramite)
{

    public Tramite Ejecutar(int idTramite){
        Tramite tramite = new Tramite();
        try
        {   
            tramite = repoTramite.TramiteConsultaPorId(idTramite);
        }
        catch (RepositorioException exc)
        {
            Console.WriteLine(exc.Message);
        }
        return tramite;
    }
}
