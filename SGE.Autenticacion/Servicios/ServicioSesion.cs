using SGE.Aplicacion;
namespace SGE.Autenticacion;
public class ServicioSesion : IServicioSesion
{
    private Usuario? usuarioLogueado;
    public bool esAdmin {get;set;}

    public Usuario? GetUsuario() {
        return usuarioLogueado;
    }

    public void LogIn(Usuario? usuario) {
        if(usuario != null) {
        usuarioLogueado = usuario;
        esAdmin = usuario.Id == 1;
        }
    }

    public void LogOut() {
        usuarioLogueado = null;
    }
}