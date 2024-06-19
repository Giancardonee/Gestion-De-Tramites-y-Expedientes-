namespace SGE.Aplicacion;

public interface IUsuarioRepositorio
{
    public void AgregarUsuario(Usuario usuario);
    public void EliminarUsuario(int id);
    public void ModificarUsuario (Usuario usuario);
    public List<Usuario> ListarUsuarios ();
    public bool AutenticarUsuario(Usuario usuario);
    public void AgregarPermiso(Usuario usuario, String permisoAOtorgar);
    public void QuitarPermiso(Usuario usuario, String permisoAQuitar);
}
