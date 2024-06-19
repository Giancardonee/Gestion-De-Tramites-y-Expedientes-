using SGE.Aplicacion;
namespace SGE.Repositorios;
using System.Text;
using System.Security.Cryptography;

public class RepositorioUsuario(SGEcontext context) : IUsuarioRepositorio
{
    public void AgregarUsuario(Usuario usuario)
    {
        ChequearExisteCorreo(usuario.Correo);
        usuario.Contraseña = hashPassword(usuario.Contraseña);
        context.Usuarios.Add(usuario);
        context.SaveChanges();
    }

    public bool AutenticarUsuario(Usuario usuario)
    {
        string hashContraseña = hashPassword(usuario.Contraseña);
        var usuarioComparar = context.Usuarios.SingleOrDefault(u => u.Correo == usuario.Correo && u.Contraseña == hashContraseña);
        if (usuarioComparar != null)
        {
            return true;
        }
        return false;
    }


    // recibir correo en vez de id.
    public void EliminarUsuario(int idBorrarUsuario)
    {
        var usuarioBorrar = context.Usuarios.Where(u => u.Id == idBorrarUsuario).SingleOrDefault();
        if (usuarioBorrar != null)// es porque existe el usuari.
        {
            context.Remove(usuarioBorrar);
            context.SaveChanges();
        }
        else
        {
            throw new RepositorioException(
                "UsuarioBaja: El usuario que se intenta eliminar no existe.");
        }
    }
    public void ModificarUsuario(Usuario usuario)
    {
        var usuarioModificar = context.Usuarios.Where(u => u.Id == usuario.Id).SingleOrDefault();
        if (usuarioModificar != null)
        {
            usuarioModificar.Nombre = usuario.Nombre;
            usuarioModificar.Apellido = usuario.Apellido;
            usuarioModificar.Correo = usuario.Correo;
            usuarioModificar.Contraseña = usuario.Contraseña;
            context.SaveChanges();
        }
        else
            throw new RepositorioException("ModificarUsuario: El usuario no existe.");
    }

    // recibir correo, y permisos
  
    public List<Usuario> ListarUsuarios()
    {
        List<Usuario> usuarios = context.Usuarios.ToList();
        if (usuarios.Count == 0)
            throw new RepositorioException("ListarUsuarios: no se encontraron usuarios.");
        return usuarios;
    }

    // QUITAR PERMSISOS ADJUDICADOS DESDE LA UI !!
    public void AgregarPermiso(Usuario usuario, String permisoAOtorgar)
    {
        var usuarioModificar = context.Usuarios.Where(u => u.Id == usuario.Id).SingleOrDefault();
        if (usuarioModificar != null)
        {
            if (!string.IsNullOrEmpty(usuarioModificar.ListaPermisos))
            {
                usuarioModificar.ListaPermisos += $",{permisoAOtorgar}";
            }
            else
            {
                usuarioModificar.ListaPermisos = permisoAOtorgar;
            }
            context.SaveChanges();
        }
        else
            throw new RepositorioException("AgregarPermisos: El usuario no existe.");
    }


    public void QuitarPermiso(Usuario usuario, String permisoAQuitar)
    {
        var usuarioModificar = context.Usuarios.Where(u => u.Id == usuario.Id).SingleOrDefault();
        if (usuarioModificar != null)
        {

            if (!string.IsNullOrEmpty(usuarioModificar.ListaPermisos))
            {
                var permisos = usuarioModificar.ListaPermisos.Split(',').Where(p => p != permisoAQuitar);
                usuarioModificar.ListaPermisos = String.Join(',', permisos);
                context.SaveChanges();
            }
        }
        else
            throw new RepositorioException("AgregarPermisos: El usuario no existe.");
    }

    private string hashPassword(string password)
    {
        using (var sha256 = SHA256.Create())
        {
            byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < bytes.Length; i++)
            {
                builder.Append(bytes[i].ToString("x2"));
            }
            return builder.ToString();
        }
    }

    private void ChequearExisteCorreo(String correoNuevo)
    {
        bool emailExists = context.Usuarios // Replace with your table name
        .Where(e => e.Correo == correoNuevo) // Filter by the Email property
        .Any(); // Check if any records match the condition
        if (emailExists)
        {
            throw new RepositorioException("El correo ya esta en uso.");
        }
    }
}
