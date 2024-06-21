namespace SGE.Aplicacion;

public class CasoDeUsoPermisoAlta (IUsuarioRepositorio repositorio)
{
    public void Ejecutar (int id,String permisosAOtorgar)
    {
        repositorio.AgregarPermiso(id,permisosAOtorgar);
    }
}
