namespace SGE.Aplicacion;
public class CasoDeUsoModificarPermisos (IUsuarioRepositorio repoUsuario)
{
    public void Ejecutar (int id, String permisos)
    {
        repoUsuario.ModificarPermisos(id,permisos); 
    }
}