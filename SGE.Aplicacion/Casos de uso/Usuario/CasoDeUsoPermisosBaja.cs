namespace SGE.Aplicacion;

public class CasoDeUsoPermisosBaja (IUsuarioRepositorio repositorio)
{
    public void Ejecutar (Usuario usuario , String permisoAEliminar)
    {
        repositorio.QuitarPermiso(usuario,permisoAEliminar);
    }
}
