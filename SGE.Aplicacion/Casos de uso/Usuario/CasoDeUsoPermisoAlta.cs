namespace SGE.Aplicacion;

public class CasoDeUsoPermisosAlta (IUsuarioRepositorio repositorio)
{
    public void Ejecutar (int id,String permisosAOtorgar)
    {
        repositorio.AgregarPermiso(id,permisosAOtorgar);
    }
}
