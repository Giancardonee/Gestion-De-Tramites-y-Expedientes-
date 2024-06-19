using Microsoft.EntityFrameworkCore;
using SGE.Aplicacion;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
namespace SGE.Repositorios;

public class SGEcontext : DbContext
{

    public DbSet<Expediente> Expedientes { get; set; }
    public DbSet<Tramite> Tramites { get; set; }
    public DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("data source=SGE.sqlite");
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //=====================================================================
        //Estas conversiones, las usamos para que en la bd se almacene en foramto string y no en integer.
        // Configuración de la conversión de Enum a string para EstadoExpediente
        modelBuilder
            .Entity<Expediente>()
            .Property(e => e.Estado)
            .HasConversion(new EnumToStringConverter<EstadoExpediente>());

        // Configuracion de la conversion de Enum a string para TipoTramite
        modelBuilder
            .Entity<Tramite>()
            .Property(t=> t.TipoTramite)
            .HasConversion(new EnumToStringConverter<EtiquetaTramite>());
        //=====================================================================
    }
}
