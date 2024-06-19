namespace SGE.Aplicacion;

public class CasoDeUsoTramiteAlta(ITramiteRepositorio repoTramite, IServicioAutorizacion autorizador,
    ServicioActualizacionEstado actualizacionEstado, IValidadorTramite validador)
{
    public void Ejecutar(Tramite t, Usuario usuario)
    {
        try
        {
            if (autorizador.TienePermiso(usuario, Permiso.TramiteAlta))
            {
                t.UsuarioUltModificacion = usuario.Id;
                validador.Validar(t);
                t.FechaCreacion = DateTime.Now;
                t.FechaUltModificacion = DateTime.Now;
                repoTramite.TramiteAlta(t);
                actualizacionEstado.actualizacionEstadoExpediente(t.ExpedienteId, t.TipoTramite);
            }
            else
            {
                throw new AutorizacionException();
            }
        }
        catch (AutorizacionException e)
        {
            Console.WriteLine(e.Message);
        }
        catch (ValidacionException exc)
        {
            Console.WriteLine(exc.Message);
        }
    }

}
