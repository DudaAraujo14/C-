using Atendimentos.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Atendimentos.Infrastructure.Context
{
    public class AtendimentosDbContext : DbContext
    {
        public AtendimentosDbContext(DbContextOptions<AtendimentosDbContext> options)
            : base(options)
        {
        }

        // 🧩 Tabelas do sistema
        public DbSet<Mesa> Mesas { get; set; }
        public DbSet<Garcom> Garcons { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // =====================
            // CONFIGURAÇÃO DE MESA
            // =====================
            modelBuilder.Entity<Mesa>(entity =>
            {
                entity.ToTable("MESAS");

                entity.HasKey(m => m.Id);

                entity.Property(m => m.Numero)
                    .IsRequired();

                entity.HasIndex(m => m.Numero)
                    .IsUnique();

                entity.Property(m => m.Status)
                    .IsRequired();

                entity.Property(m => m.CreatedAt)
                    .IsRequired();

                entity.Property(m => m.UpdatedAt)
                    .IsRequired();

                entity.Property(m => m.Localizacao)
                    .HasMaxLength(80);

                entity.Property(m => m.QrCode)
                    .HasMaxLength(256);
            });

            // =======================
            // CONFIGURAÇÃO DE GARÇOM
            // =======================
            modelBuilder.Entity<Garcom>(entity =>
            {
                entity.ToTable("GARCONS");

                entity.HasKey(g => g.Id);

                entity.Property(g => g.Nome)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(g => g.Matricula)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(g => g.Telefone)
                    .HasMaxLength(20);

                entity.Property(g => g.DataContratacao)
                    .IsRequired();

                entity.Property(g => g.Ativo)
                    .IsRequired();
            });
        }
    }
}
