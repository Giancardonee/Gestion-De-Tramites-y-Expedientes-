namespace SGE.Aplicacion;

public interface IServicioAutorizacion
{
    bool TienePermiso(Usuario usuario, Permiso permiso);
}
