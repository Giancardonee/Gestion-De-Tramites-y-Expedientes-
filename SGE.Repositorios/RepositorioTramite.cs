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
        var tramiteBorrar = context.Tramites.Where(t => t.Id == idBorrarTramite).SingleOrDefault();
        if (tramiteBorrar != null)// es porque existe el tramite.
        {
            context.Remove(tramiteBorrar);
            context.SaveChanges();
        }
        else
            throw new RepositorioException("El tramite que se intenta eliminar no existe.");
    }

    public Tramite TramiteConsultaPorId(int idTramite)
    {
        var tramite = context.Tramites.Where(t => t.Id == idTramite).SingleOrDefault();
        if (tramite != null)// es porque existe el tramite.
        {
            return tramite;
        }
        else
            throw new RepositorioException("El tramite que se busca no existe.");
    }

    public void TramiteModificacion(Tramite tModificar)
    {
        var tramiteModificar = context.Tramites.Where(t => t.Id == tModificar.Id).SingleOrDefault();
        if (tramiteModificar != null)
        {
            tramiteModificar.ExpedienteId = tModificar.ExpedienteId;
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
        var tramitesFiltrados = context.Tramites.Where(t => t.ExpedienteId == idExpediente).ToList();
        if (tramitesFiltrados.Count == 0)
            throw new RepositorioException("TramiteConsultaPorIdExpediente: el expediente no tiene trámites asociados.");
        return tramitesFiltrados;
    }

    public Tramite TramiteConsultaUltimo()
    {
        var ultimoTramite = context.Tramites.OrderByDescending(t => t.Id).First();
        if (ultimoTramite == null) return new Tramite() { Id = 0 };
        else return ultimoTramite;
    }

    public List<Tramite> TramiteConsultaTodos()
    {
        var listaTramites = context.Tramites.ToList();
        if (listaTramites.Any())
        {
            return listaTramites;
        }
        else
        {
            throw new RepositorioException("No se encontraron trámites.");
        }
    }
}
