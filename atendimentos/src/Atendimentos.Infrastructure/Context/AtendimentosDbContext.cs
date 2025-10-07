using Microsoft.EntityFrameworkCore;
using Atendimentos.Domain.Entities;

namespace Atendimentos.Infrastructure.Context
{
    public class AtendimentosDbContext : DbContext
    {
        public AtendimentosDbContext(DbContextOptions<AtendimentosDbContext> options)
            : base(options)
        {
        }

        public DbSet<Mesa> Mesas { get; set; }
        public DbSet<Garcom> Garcons { get; set; }
        public DbSet<Comanda> Comandas { get; set; }
        public DbSet<Cliente> Clientes { get; set; } // ✅ Adicionado

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // 🧩 Configuração da tabela MESAS
            modelBuilder.Entity<Mesa>(entity =>
            {
                entity.ToTable("MESAS");
                entity.HasKey(m => m.Id);
                entity.HasIndex(m => m.Numero).IsUnique();

                entity.Property(m => m.Numero).IsRequired();
                entity.Property(m => m.Status).IsRequired();
                entity.Property(m => m.Capacidade);
                entity.Property(m => m.Localizacao).HasMaxLength(80);
                entity.Property(m => m.QrCode).HasMaxLength(256);
                entity.Property(m => m.CreatedAt).IsRequired();
                entity.Property(m => m.UpdatedAt).IsRequired();
                entity.Property(m => m.RowVersion)
                      .IsRowVersion()
                      .IsConcurrencyToken()
                      .IsRequired();
            });

            // 🧑‍🍳 Configuração da tabela GARCONS
            modelBuilder.Entity<Garcom>(entity =>
            {
                entity.ToTable("GARCONS");
                entity.HasKey(g => g.Id);
                entity.Property(g => g.Nome).IsRequired().HasMaxLength(100);
                entity.Property(g => g.Matricula).IsRequired().HasMaxLength(20);
                entity.Property(g => g.Telefone).IsRequired().HasMaxLength(20);
                entity.Property(g => g.DataContratacao).IsRequired();
                entity.Property(g => g.Ativo).IsRequired();
            });

            // 🧾 Configuração da tabela COMANDAS
            modelBuilder.Entity<Comanda>(entity =>
            {
                entity.ToTable("COMANDAS");
                entity.HasKey(c => c.Id);
                entity.Property(c => c.Status).IsRequired();
                entity.Property(c => c.DataHoraAbertura).IsRequired();
                entity.Property(c => c.ValorTotal).HasColumnType("DECIMAL(10,2)");

                entity.HasOne<Mesa>()
                      .WithMany()
                      .HasForeignKey(c => c.MesaId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne<Garcom>()
                      .WithMany()
                      .HasForeignKey(c => c.GarcomId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne<Cliente>()
                      .WithMany()
                      .HasForeignKey(c => c.ClienteId)
                      .OnDelete(DeleteBehavior.SetNull);
            });

            // 👤 Configuração da tabela CLIENTES
            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.ToTable("CLIENTES");
                entity.HasKey(c => c.Id);
                entity.Property(c => c.Nome).IsRequired().HasMaxLength(120);
                entity.Property(c => c.CPF).IsRequired().HasMaxLength(14);
                entity.Property(c => c.Telefone).HasMaxLength(20);
                entity.Property(c => c.DataCadastro).IsRequired();
            });
        }
    }
}
