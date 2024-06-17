namespace SGE.Aplicacion;

public class CasoDeUsoUsuarioAlta (IUsuarioRepositorio repoUsuario, IValidadorUsuario validadorUsuario)// y dbContext
{
    public void Ejecutar(Usuario usuario)
    {
        //validaciones para el alta de usuario
        try
        {
            validadorUsuario.ValidarCorreo(usuario.Correo);
            validadorUsuario.ValidarContraseña(usuario.Contraseña);
            validadorUsuario.ValidarDemasCampos(usuario.Nombre,usuario.Contraseña);
            repoUsuario.AgregarUsuario(usuario);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
}
