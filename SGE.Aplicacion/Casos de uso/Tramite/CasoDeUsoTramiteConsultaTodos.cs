namespace SGE.Aplicacion;

public class CasoDeUsoTramiteConsultaTodos(ITramiteRepositorio repoTramite)
{

    public List<Tramite> Ejecutar(){
        List<Tramite> listaTramites = new List<Tramite>();
        try
        {   
            listaTramites =  repoTramite.TramiteConsultaTodos();
        }
        catch (RepositorioException exc)
        {
            Console.WriteLine(exc.Message);
        }
        return listaTramites;
    }
}
