namespace SGE.Aplicacion;

public class CasoDeUsoUsuarioModificacion (IUsuarioRepositorio repoUsuario, IValidadorUsuario validadorUsuario)
{
    public void Ejecutar (Usuario usuario)
    {
        try{
            validadorUsuario.ValidarCorreo(usuario.Correo);
            validadorUsuario.ValidarContraseña(usuario.Contraseña);
            validadorUsuario.ValidarDemasCampos(usuario.Nombre,usuario.Contraseña);
            repoUsuario.ModificarUsuario(usuario);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
}
