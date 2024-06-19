using SGE.Aplicacion;
namespace SGE.Autenticacion;

public class ServicioIniciarSesion (IServicioHashContraseña hash, IUsuarioRepositorio repoUsuario): IServicioIniciarSesion
{
    public bool IniciarSesion(Usuario usuario) {
        bool resultado = false;
        string hashContraseña = hash.hashPassword(usuario.Contraseña);
        try{
              resultado = repoUsuario.AutenticarUsuario(usuario,hashContraseña);
        }
        catch (RepositorioException exc)
        {
            Console.WriteLine(exc.Message);
        }
        return resultado;
    }
}


