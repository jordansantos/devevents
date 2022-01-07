using DevEvents.API.Entidades;
using Microsoft.EntityFrameworkCore;

namespace DevEvents.API.Persistencia
{
  public class DevEventsContext : DbContext
  {
    public DevEventsContext(DbContextOptions<DevEventsContext> options) : base(options)
    {

    }

    public DbSet<Evento> Eventos { get; set; }
    public DbSet<Categoria> Categorias { get; set; }
    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Inscricao> Inscricoes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder) 
    {
      modelBuilder.Entity<Evento>()
        .HasKey(e => e.Id);

      modelBuilder.Entity<Evento>()
        .Property(e => e.Id)
        .IsRequired(true)
        .ValueGeneratedOnAdd();

      modelBuilder.Entity<Evento>()
        .HasOne(e => e.Categoria)
        .WithMany()
        .HasForeignKey(e => e.IdCategoria);

      modelBuilder.Entity<Evento>()
        .HasOne(e => e.Usuario)
        .WithMany()
        .HasForeignKey(e => e.IdUsuario);

      modelBuilder.Entity<Categoria>()
        .HasKey(e => e.Id);

      modelBuilder.Entity<Categoria>()
        .Property(e => e.Id)
        .IsRequired(true)
        .ValueGeneratedOnAdd();

      modelBuilder.Entity<Categoria>()
        .Property(e => e.Descricao)
        .IsRequired(true)
        .HasMaxLength(100);

      modelBuilder.Entity<Usuario>()
        .HasKey(e => e.Id);

      modelBuilder.Entity<Usuario>()
        .Property(e => e.Id)
        .IsRequired(true)
        .ValueGeneratedOnAdd();

      modelBuilder.Entity<Usuario>()
        .Property(e => e.NomeCompleto)
        .IsRequired(true)
        .HasMaxLength(100);

      modelBuilder.Entity<Usuario>()
        .Property(e => e.DataNascimento)
        .IsRequired(true);

      modelBuilder.Entity<Usuario>()
        .Property(e => e.Email)
        .IsRequired(true);

      modelBuilder.Entity<Usuario>()
        .Property(e => e.IsAtivo)
        .IsRequired(true);

      modelBuilder.Entity<Inscricao>()
        .HasKey(e => e.Id);

      modelBuilder.Entity<Inscricao>()
        .Property(e => e.Id)
        .IsRequired(true)
        .ValueGeneratedOnAdd();

      modelBuilder.Entity<Inscricao>()
        .HasOne(e => e.Usuario)
        .WithMany(i => i.Inscricoes)
        .HasForeignKey(e => e.IdUsuario)
        .OnDelete(DeleteBehavior.Restrict);

      modelBuilder.Entity<Inscricao>()
        .HasOne(i => i.Evento)
        .WithMany(e => e.Inscricoes)
        .HasForeignKey(i => i.IdEvento)
        .OnDelete(DeleteBehavior.Restrict);
    }
  }
}
