namespace SGE.Aplicacion;

public class CasoDeUsoExpedienteAlta(IExpedienteRepositorio repoExpediente, IServicioAutorizacion autorizador, IValidadorExpediente validacion)
{

    public void Ejecutar(Expediente e, Usuario usuario)
    {
        try
        {
            if (autorizador.TienePermiso(usuario, Permiso.ExpedienteAlta))
            {
                e.UsuarioUltModificacion = usuario.Id;
                validacion.Validar(e);
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
            throw;
        }
        catch (ValidacionException exc)
        {
            Console.WriteLine(exc.Message);
            throw;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
          throw; 
        }
    }

}
