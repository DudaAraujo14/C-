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

        public DbSet<Mesa> Mesas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Mesa>(entity =>
            {
                entity.ToTable("MESAS");
                entity.HasKey(m => m.Id);
                entity.Property(m => m.Numero).IsRequired();
                entity.Property(m => m.Status).IsRequired();
                entity.Property(m => m.CreatedAt).IsRequired();
                entity.Property(m => m.UpdatedAt).IsRequired();
            });
        }
    }
}
