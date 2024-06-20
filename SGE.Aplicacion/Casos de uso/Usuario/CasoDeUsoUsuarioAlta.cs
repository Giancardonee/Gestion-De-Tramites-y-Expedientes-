
namespace SGE.Aplicacion;

public class CasoDeUsoUsuarioAlta (IUsuarioRepositorio repoUsuario, IValidadorUsuario validadorUsuario, IServicioHashContraseña servicioHash)
{
    public void Ejecutar(Usuario usuario)
    {
        //validaciones para el alta de usuario
        try
        {
            validadorUsuario.ValidarCorreo(usuario.Correo);
            validadorUsuario.ValidarContraseña(usuario.Contraseña);
            validadorUsuario.ValidarDemasCampos(usuario.Nombre,usuario.Apellido);
            String hashContraseña = servicioHash.hashPassword(usuario.Contraseña);
            repoUsuario.RegistrarUsuario(usuario,hashContraseña);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
}
