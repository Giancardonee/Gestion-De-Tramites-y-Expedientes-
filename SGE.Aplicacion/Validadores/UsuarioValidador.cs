namespace SGE.Aplicacion;
using System.Text.RegularExpressions;


public class UsuarioValidador : IValidadorUsuario
{
    // validar si hay un usaurio registrado con ese correo, en la db
    public void ValidarCorreo(string correoElectronico)
    {
        if (string.IsNullOrWhiteSpace(correoElectronico))
        {
            throw new Exception("El correo no puede estar vacío.");

        }
        else if (!Regex.IsMatch(correoElectronico, @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$"))
        {
            throw new Exception("El correo no es válido.");
        }

    }

    public void ValidarContraseña(String contraseña)
    {
        if (!Regex.IsMatch(contraseña, @"^(?=.*[0-9])(?=.{8,30}$).*$"))
        {
            throw new Exception("La contraseña no es válida. Debe tener minimo 8 caracteres y un valor numerico.");
        }
    }

    public void ValidarDemasCampos(string nombre, string apellido)
    {
        if (string.IsNullOrEmpty(nombre))
        {
            throw new ArgumentNullException("nombre", "El campo nombre no puede estar vacío");
        }

        if (string.IsNullOrEmpty(apellido))
        {
            throw new ArgumentNullException("apellido", "El campo apellido no puede estar vacío");
        }

    }
}
