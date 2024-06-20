namespace SGE.Aplicacion;

public class CasoDeUsoPermisoBaja (IUsuarioRepositorio repositorio)
{
    public void Ejecutar (int id , String permisoAEliminar)
    {
        repositorio.QuitarPermiso(id,permisoAEliminar);
    }
}
