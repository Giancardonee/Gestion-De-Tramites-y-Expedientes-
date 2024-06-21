namespace SGE.Aplicacion;

public class ServicioAutorizacion : IServicioAutorizacion
{
  public bool TienePermiso(Usuario usuario, Permiso accion)
  {
    if (usuario != null)
    {
      if (!String.IsNullOrEmpty(usuario.ListaPermisos))
      {
        string[] permisos = usuario.ListaPermisos.Split(',');
        foreach (String permisoActual in permisos)
        {
          if (permisoActual == accion.ToString())
          {
            return true;
          }
        }
      }
    }                                        
    return false;
  }
} 

