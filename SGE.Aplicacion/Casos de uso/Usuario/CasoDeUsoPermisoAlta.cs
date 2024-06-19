namespace SGE.Aplicacion;

public class CasoDeUsoPermisosAlta (IUsuarioRepositorio repositorio)
{
    public void Ejecutar (Usuario usuario ,String permisosAOtorgar)
    {
        repositorio.AgregarPermiso(usuario,permisosAOtorgar);
    }
}
