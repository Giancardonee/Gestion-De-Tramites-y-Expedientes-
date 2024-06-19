using SGE.Aplicacion; 
namespace SGE.Autenticacion;

public interface IServicioIniciarSesion
{
    public bool IniciarSesion(Usuario usuario);
}
