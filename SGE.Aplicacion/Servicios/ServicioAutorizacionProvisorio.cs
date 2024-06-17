namespace SGE.Aplicacion;

public class ServicioAutorizacionProvisorio : IServicioAutorizacion
{
  public bool TienePermiso(Usuario usuario,Permiso accion)
    {   
        if (usuario.id==1) return true;
        else 
        {
          foreach (Permiso permisoUsuario in usuario.ListaPermisos)
          {
            if (permisoUsuario== accion) return true;
          }
        }
        return false;
    }
}

