namespace SGE.Aplicacion;

public interface IServicioAutorizacion
{
    bool TienePermiso(Usuario usuarui, Permiso permiso);
}
