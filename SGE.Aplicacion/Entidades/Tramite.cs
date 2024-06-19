using System.Dynamic;
using System.Text.RegularExpressions;

namespace SGE.Aplicacion;

public class Tramite
{
    public int Id { get; set; }
    public int ExpedienteId { get; set; }
    public EtiquetaTramite TipoTramite { get; set; }
    public string ContenidoTramite { get; set; }
    public DateTime FechaCreacion { get; set; }
    public DateTime FechaUltModificacion { get; set; }
    public int UsuarioUltModificacion { get; set; }

    public Tramite(int ExpId, EtiquetaTramite etiqueta, string contenido)
        : this()
    {
        ExpedienteId = ExpId;
        TipoTramite = etiqueta;
        ContenidoTramite = contenido;
    }

    public Tramite()
    {
        TipoTramite = EtiquetaTramite.EscritoPresentado;
        FechaCreacion = DateTime.Now;
        FechaUltModificacion = DateTime.Now;
        ContenidoTramite="";
    }

    public override string ToString()
    {
        return $"Id de Expediente: {ExpedienteId}, Id de tramite: {Id}, Tipo de tramite: {TipoTramite} , Contenido del tramite: {ContenidoTramite}  ";
    }
}
