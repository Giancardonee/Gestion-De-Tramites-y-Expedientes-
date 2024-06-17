namespace SGE.Aplicacion;

public interface IUsuarioRepositorio
{
    public void AgregarUsuario(Usuario usuario);
    public void EliminarUsuario(int id);
    public void ModificarUsuario (Usuario usuario); 
    public void ModificarPermisos(Usuario usuario);
    public List<Usuario> ListarUsuarios ();

}
