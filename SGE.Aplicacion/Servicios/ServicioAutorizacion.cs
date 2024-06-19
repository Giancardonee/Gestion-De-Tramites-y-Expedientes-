namespace SGE.Aplicacion;

public class ServicioAutorizacion : IServicioAutorizacion
{
  public bool TienePermiso(Usuario usuario, Permiso accion)
  {
    if (usuario.Id == 1) return true;
    else
    {
      if (!String.IsNullOrEmpty(usuario.ListaPermisos))
      {
        string[] permisos = usuario.ListaPermisos.Split(',');
        foreach (String permisoActual in permisos)
        {
          if (permisoActual.Equals(accion)) 
          {
            return true;
          }
        }
      }
    }
    return false;
  }
}

