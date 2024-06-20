using SGE.Aplicacion;
namespace SGE.Autenticacion;

public class CasoDeUsoIniciarSesion (IServicioIniciarSesion autenticador)
{
    public bool Ejecutar(Usuario usuario) {
        return autenticador.IniciarSesion(usuario);
    }
}
