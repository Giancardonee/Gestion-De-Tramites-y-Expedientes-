namespace SGE.Aplicacion;

public class CasoDeUsoAutenticacionUsuario(IUsuarioRepositorio repoUsuario)
{
    public void Ejecutar (Usuario usuario)
    {   
        repoUsuario.AutenticarUsuario(usuario);
    }
}
