namespace SGE.Aplicacion;

public class CasoDeUsoTramiteAlta(ITramiteRepositorio repoTramite, IServicioAutorizacion autorizador,
    ServicioActualizacionEstado actualizacionEstado, IValidadorTramite validador)
{
    public void Ejecutar(Tramite t, int IdUsuario)
    {
        try
        {
            if (autorizador.TienePermiso(IdUsuario, Permiso.TramiteAlta))
            {
                validador.Validar(t);
                t.FechaCreacion = DateTime.Now;
                t.FechaUltModificacion = DateTime.Now;
                t.UsuarioUltModificacion = IdUsuario;
                repoTramite.TramiteAlta(t);
                actualizacionEstado.actualizacionEstadoExpediente(t.ExpedienteID, t.TipoTramite);
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
