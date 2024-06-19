namespace SGE.Aplicacion;

public class CasoDeUsoTramiteModificacion(
    ITramiteRepositorio repoTramite,
    IServicioAutorizacion autorizador,
    ServicioActualizacionEstado actualizacionEstado
)
{
    public void Ejecutar(Tramite t, Usuario usuario)
    {
        try
        {
            if (autorizador.TienePermiso(usuario, Permiso.TramiteModificacion))
            {
                repoTramite.TramiteModificacion(t);
                actualizacionEstado.actualizacionEstadoExpediente(t.ExpedienteId, t.TipoTramite);
            }
            else throw new AutorizacionException(); 
        }
        catch (AutorizacionException e)
        {
            Console.WriteLine(e.Message); 
        }
        catch (RepositorioException e)
        {
            Console.WriteLine(e.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
