namespace SGE.Aplicacion;

public class CasoDeUsoExpedienteModificacion(IExpedienteRepositorio repo, IServicioAutorizacion autorizador)
{
    public void Ejecutar(Expediente e, int IdUsuario)
    {
        try
        {

            if (autorizador.TienePermiso(IdUsuario, Permiso.ExpedienteModificacion))
            {
                e.FechaModificacion = DateTime.Now;
                e.UsuarioUltModificacion = IdUsuario;
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
