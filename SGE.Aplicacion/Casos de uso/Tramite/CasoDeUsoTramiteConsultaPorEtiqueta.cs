namespace SGE.Aplicacion;

public class CasoDeUsoTramiteConsultaPorEtiqueta(ITramiteRepositorio repoTramite)
{

    public List<Tramite> Ejecutar(EtiquetaTramite e){
        List<Tramite> listaTramites = new List<Tramite>();
        try
        {   
            listaTramites =  repoTramite.TramiteConsultaPorEtiqueta(e);
        }
        catch (RepositorioException exc)
        {
            Console.WriteLine(exc.Message);
        }
        return listaTramites;
    }
}
