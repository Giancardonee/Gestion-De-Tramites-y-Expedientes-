namespace SGE.Aplicacion;

public class CasoDeUsoTramiteBaja(
    ITramiteRepositorio repoTramite,
    IServicioAutorizacion autorizador,
    ServicioActualizacionEstado actualizacionEstado
)
{
    public void Ejecutar(int idTramite, Usuario usuario)
    {
        try
        {
            if (autorizador.TienePermiso(usuario, Permiso.TramiteBaja))
            {
                Tramite ultimoTramite = repoTramite.TramiteConsultaUltimo();                
                repoTramite.TramiteBaja(idTramite);
                if (ultimoTramite.IdTramite == idTramite)
                {
                    Tramite nuevoUltTramite = repoTramite.TramiteConsultaUltimo();
                    if (nuevoUltTramite.IdTramite > 0) 
                        actualizacionEstado.actualizacionEstadoExpediente(nuevoUltTramite.ExpedienteID, nuevoUltTramite.TipoTramite);
                }
            }
            else
                throw new AutorizacionException();
        }
        catch (AutorizacionException e)
        {
            Console.WriteLine(e.Message);
        }
        catch (RepositorioException e)
        {
            Console.WriteLine(e.Message);
        }
    }
}
