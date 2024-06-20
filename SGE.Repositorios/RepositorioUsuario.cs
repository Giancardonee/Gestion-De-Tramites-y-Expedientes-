using SGE.Aplicacion;
namespace SGE.Repositorios;


public class RepositorioUsuario(SGEcontext context) : IUsuarioRepositorio
{
    public void RegistrarUsuario(Usuario usuario, String hashContraseña)
    {
        ChequearExisteCorreo(usuario.Correo);
        usuario.Contraseña = hashContraseña;
        if (esUsuarioAdministrador()) asignarTodosLosPermisos(usuario);    
        context.Usuarios.Add(usuario);
        context.SaveChanges();
    }

    public bool AutenticarUsuario(Usuario usuario, String hashContraseña)
    {
        var usuarioComparar = context.Usuarios.SingleOrDefault(u => u.Correo == usuario.Correo && u.Contraseña == hashContraseña);
        if (usuarioComparar != null)
        {
            return true;
        }
        else{
             throw new RepositorioException(
                "AutenticarUsuario: Credenciales invalidas.");
        }
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
    public void AgregarPermiso(int Id, String permisoAOtorgar)
    {
        var usuarioModificar = context.Usuarios.Where(u => u.Id == Id).SingleOrDefault();
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


    public void QuitarPermiso(int Id, String permisoAQuitar)
    {
        var usuarioModificar = context.Usuarios.Where(u => u.Id == Id).SingleOrDefault();
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

    private void ChequearExisteCorreo(String correoNuevo)
    {
        bool existeMail = context.Usuarios 
        .Where(e => e.Correo == correoNuevo) 
        .Any(); 
        if (existeMail)
        {
            throw new RepositorioException("El correo ya esta en uso.");
        }
    }

    private bool esUsuarioAdministrador()
    {
        return !context.Usuarios.Any();
    }

    private void asignarTodosLosPermisos(Usuario usuario)
    {
        String permisos = String.Join(',',Enum.GetNames(typeof(Permiso)));
        usuario.ListaPermisos = permisos;
    }
}
