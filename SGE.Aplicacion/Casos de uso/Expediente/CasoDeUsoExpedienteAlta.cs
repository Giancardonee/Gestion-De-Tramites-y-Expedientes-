namespace SGE.Aplicacion;

public class CasoDeUsoExpedienteAlta(IExpedienteRepositorio repoExpediente, IServicioAutorizacion autorizador, IValidadorExpediente validacion)
{

    public void Ejecutar(Expediente e, int IdUsuario)
    {
        try
        {
            if (autorizador.TienePermiso(IdUsuario, Permiso.ExpedienteAlta))
            {
                validacion.Validar(e);
                e.UsuarioUltModificacion = IdUsuario;
                repoExpediente.ExpedienteAlta(e);
            }
            else
            {
                throw new AutorizacionException();
            }
        }
        catch (AutorizacionException error)
        {
            Console.WriteLine(error.Message);
        }
        catch (ValidacionException exc)
        {
            Console.WriteLine(exc.Message);
        }
        catch (Exception ex)
        {
          Console.WriteLine(ex.Message);
        }
    }

}
