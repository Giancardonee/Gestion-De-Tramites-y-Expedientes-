namespace SGE.Aplicacion;

public class CasoDeUsoUsuarioBaja (IUsuarioRepositorio repositorio)
{
    public void Ejecutar (int id)
    {
        repositorio.EliminarUsuario(id);
    }
}
