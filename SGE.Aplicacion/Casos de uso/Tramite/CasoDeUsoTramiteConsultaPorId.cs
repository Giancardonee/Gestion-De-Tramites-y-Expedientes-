namespace SGE.Aplicacion;

public class CasoDeUsoTramiteConsultaPorId(ITramiteRepositorio repoTramite)
{

    public Tramite Ejecutar(int idTramite){
        Tramite tramite = new Tramite();
        try
        {   
            return repoTramite.TramiteConsultaPorId(idTramite);
        }
        catch (RepositorioException exc)
        {
            throw; 
        }
    }
}
