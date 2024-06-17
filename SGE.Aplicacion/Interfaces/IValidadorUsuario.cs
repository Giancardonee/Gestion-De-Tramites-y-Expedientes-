namespace SGE.Aplicacion;

public interface IValidadorUsuario
{
    public void ValidarCorreo(String correo);
    public void ValidarContraseña(String contraseña);
   public void ValidarDemasCampos(String nombre, String apellido);
}
