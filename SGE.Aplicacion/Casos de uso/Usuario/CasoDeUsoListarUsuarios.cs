namespace SGE.Aplicacion;

public class CasoDeUsoListarUsuarios (IUsuarioRepositorio repoUsuario)
{
    public List<Usuario> Ejecutar ()
    {
        return repoUsuario.ListarUsuarios(); 
    }
}
