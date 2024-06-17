namespace SGE.Aplicacion;

public class CasoDeUsoListarUsuarios (IUsuarioRepositorio repoUsuario)// dbContext
{
    public List<Usuario> Ejecutar ()
    {
        return repoUsuario.ListarUsuarios(); 
    }
}
