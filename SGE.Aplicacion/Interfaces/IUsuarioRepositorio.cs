namespace SGE.Aplicacion;

public interface IUsuarioRepositorio
{
    public void RegistrarUsuario(Usuario usuario,String hashContraseña);
    public void EliminarUsuario(int id);
    public void ModificarUsuario (Usuario usuario);
    public List<Usuario> ListarUsuarios ();
    public bool AutenticarUsuario(Usuario usuario,String hashContraseña);
    public Usuario? GetUsuario(String correo); 
    Usuario? ConsultaPorId(int id);
    void ModificarPermisos(int id, String permisos);
}
