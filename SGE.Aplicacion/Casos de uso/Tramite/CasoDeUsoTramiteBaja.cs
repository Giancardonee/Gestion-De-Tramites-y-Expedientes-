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
                if (ultimoTramite.Id == idTramite)
                {
                    Tramite nuevoUltTramite = repoTramite.TramiteConsultaUltimo();
                    if (nuevoUltTramite.Id > 0) 
                        actualizacionEstado.actualizacionEstadoExpediente(nuevoUltTramite.ExpedienteId, nuevoUltTramite.TipoTramite);
                }
            }
            else
                throw new AutorizacionException();
        }
        catch (AutorizacionException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
        catch (RepositorioException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }
}
