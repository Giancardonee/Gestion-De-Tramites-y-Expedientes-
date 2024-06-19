using SGE.Aplicacion;
namespace SGE.Autenticacion;

public class CasoDeUsoIniciarSesion (IServicioIniciarSesion autenticador)
{
    public void Ejecutar(Usuario usuario) {
        autenticador.IniciarSesion(usuario);
    }
}
