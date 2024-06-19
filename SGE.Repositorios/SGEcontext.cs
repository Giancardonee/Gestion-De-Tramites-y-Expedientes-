using Microsoft.EntityFrameworkCore;
using SGE.Aplicacion;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
namespace SGE.Repositorios;

public class SGEcontext : DbContext
{
#nullable disable
    public DbSet<Expediente> Expedientes { get; set; }
    public DbSet<Tramite> Tramites { get; set; }
    public DbSet<Usuario> Usuarios { get; set; }
#nullable restore
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("data source=SGE.sqlite");
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configuración de la entidad Expediente
        modelBuilder.Entity<Expediente>(entity =>
        {
            entity.HasKey(e => e.IdExpediente);
            entity.Property(e => e.IdExpediente)
                  .ValueGeneratedOnAdd(); // Auto incrementable

            entity.HasMany(e => e.listaDeTramites)
                  .WithOne()
                  .HasForeignKey(t => t.ExpedienteID);
        });

        // Configuración de la entidad Tramite
        modelBuilder.Entity<Tramite>(entity =>
        {
            entity.HasKey(t => t.IdTramite);
            entity.Property(t => t.IdTramite)
                  .ValueGeneratedOnAdd(); // Auto incrementable

            entity.HasOne<Expediente>()
                  .WithMany(e => e.listaDeTramites)
                  .HasForeignKey(t => t.ExpedienteID);
        });

        // Configuración de la entidad Usuario
        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(u => u.id);
            entity.Property(u => u.id)
                  .ValueGeneratedOnAdd(); // Auto incrementable
        });

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


        modelBuilder.Entity<Tramite>();
        // Convertir DateTime a string con el formato deseado
        var dateTimeConverter = new ValueConverter<DateTime, string>(
    v => v.ToString("yyyy-MM-dd-HH-mm"),
    v => DateTime.ParseExact(v, "yyyy-MM-dd-HH-mm", null));

        // Aplicar el convertidor a las propiedades de fecha en la entidad Expediente
        modelBuilder.Entity<Expediente>()
            .Property(e => e.FechaCreacion)
            .HasConversion(dateTimeConverter);

        modelBuilder.Entity<Expediente>()
            .Property(e => e.FechaModificacion)
            .HasConversion(dateTimeConverter);

        // Aplicar el convertidor a las propiedades de fecha en la entidad Tramite
        modelBuilder.Entity<Tramite>()
            .Property(t => t.FechaCreacion)
            .HasConversion(dateTimeConverter);

        modelBuilder.Entity<Tramite>()
            .Property(t => t.FechaUltModificacion)
            .HasConversion(dateTimeConverter);
    }

}