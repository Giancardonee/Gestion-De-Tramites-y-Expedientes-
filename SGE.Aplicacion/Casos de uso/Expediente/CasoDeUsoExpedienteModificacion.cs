namespace SGE.Aplicacion;

public class CasoDeUsoExpedienteModificacion(IExpedienteRepositorio repo, IServicioAutorizacion autorizador)
{
    public void Ejecutar(Expediente e, Usuario usuario)
    {
        try
        {

            if (autorizador.TienePermiso(usuario, Permiso.ExpedienteModificacion))
            {
                e.FechaModificacion = DateTime.Now;
                e.UsuarioUltModificacion = usuario.Id;
                repo.ExpedienteModificacion(e);
            }
        }
        catch (RepositorioException excE)
        {
            Console.WriteLine(excE.Message);
        }
        catch (Exception ex)
        {
          Console.WriteLine(ex.Message);
        }
    }
}
