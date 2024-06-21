namespace SGE.Aplicacion;

public class CasoDeUsoExpedienteBaja(
    IExpedienteRepositorio repoExpediente,
    IServicioAutorizacion autorizador
    
)
{
    public void Ejecutar(int idBaja, Usuario usuario)
    {
        try
        {
            if (autorizador.TienePermiso(usuario, Permiso.ExpedienteBaja))
            {
                repoExpediente.ExpedienteBaja(idBaja);
            }
            else
            {
                throw new AutorizacionException();
            }
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
        catch (Exception ex)
        {
          Console.WriteLine(ex.Message);
          throw;
        }
    }
}
