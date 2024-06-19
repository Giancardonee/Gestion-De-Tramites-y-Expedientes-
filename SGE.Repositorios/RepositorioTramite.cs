using SGE.Aplicacion;

namespace SGE.Repositorios;

public class RepositorioTramite(SGEcontext context) : ITramiteRepositorio
{
    public void TramiteAlta(Tramite t)
    {
        context.Add(t);
        context.SaveChanges();
    }

    public void TramiteBaja(int idBorrarTramite)
    {
        var tramiteBorrar = context.Tramites.Where(t => t.IdTramite == idBorrarTramite).SingleOrDefault();
        if (tramiteBorrar != null)// es porque existe el tramite.
        {
            context.Remove(tramiteBorrar);
            context.SaveChanges();
        }
        else
            throw new RepositorioException("El tramite que se intenta eliminar no existe.");
    }

    public void TramiteModificacion(Tramite tModificar)
    {
        var tramiteModificar = context.Tramites.Where(t => t.IdTramite == tModificar.IdTramite).SingleOrDefault();
        if (tramiteModificar != null)
        {
            tramiteModificar.ExpedienteID = tModificar.ExpedienteID;
            tramiteModificar.FechaUltModificacion = DateTime.Now;
            tramiteModificar.TipoTramite = tModificar.TipoTramite;
            tramiteModificar.ContenidoTramite = tModificar.ContenidoTramite;
            tramiteModificar.UsuarioUltModificacion = tModificar.UsuarioUltModificacion;
            context.SaveChanges();
        }
        else
            throw new RepositorioException();
    }

    public List<Tramite> TramiteConsultaPorEtiqueta(EtiquetaTramite etiqueta)
    {
        var listaTramites = context.Tramites
                            .Where(t => t.TipoTramite == etiqueta)
                            .ToList();
        if (listaTramites.Any()) // devuelve true si hay al menos un elemento.  false si esta vacia
        {
            return listaTramites;
        }
        else
        {
            throw new RepositorioException("No se encontraron trámites para la etiqueta especificada.");
        }
    }

    public List<Tramite> TramiteConsultaPorIdExpediente(int idExpediente)
    {
        var tramitesFiltrados =   context.Tramites.Where(t => t.ExpedienteID == idExpediente).ToList();
        if (tramitesFiltrados.Count == 0)
            throw new RepositorioException("TramiteConsultaPorIdExpediente: el expediente no tiene trámites asociados.");
        return tramitesFiltrados;
    }

    public Tramite TramiteConsultaUltimo()
    {
        var ultimoTramite = context.Tramites.OrderByDescending(t => t.IdTramite).First();
        if (ultimoTramite == null) return new Tramite(){IdTramite=0};
        else return ultimoTramite;
    }
}
