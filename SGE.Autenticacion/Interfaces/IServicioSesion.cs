using SGE.Aplicacion;
namespace SGE.Autenticacion;
public interface IServicioSesion
{
    public Usuario? GetUsuario();
    public void LogIn(Usuario? usuario);
    public void LogOut();
    public bool esAdmin{get;set;}
}