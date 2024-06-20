using SGE.Aplicacion;
namespace SGE.Autenticacion;

public class ServicioIniciarSesion (IServicioHashContraseña hash, IUsuarioRepositorio repoUsuario, IValidadorUsuario validador, IServicioSesion servicioSesion): IServicioIniciarSesion
{
    public bool IniciarSesion(Usuario usuario) {
        bool resultado = false;
        string hashContraseña = hash.hashPassword(usuario.Contraseña);
        try{
              validador.ValidarCorreo(usuario.Correo);
              resultado = repoUsuario.AutenticarUsuario(usuario,hashContraseña);
              servicioSesion.LogIn(repoUsuario.GetUsuario(usuario.Correo));
        }
        catch (RepositorioException exc)
        {
            Console.WriteLine(exc.Message);
            throw;
        }
        return resultado;
    }
}


