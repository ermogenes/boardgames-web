using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace boardgames_web.db
{
    public partial class boardgamesContext : DbContext
    {
        public boardgamesContext()
        {
        }

        public boardgamesContext(DbContextOptions<boardgamesContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Boardgame> Boardgame { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Boardgame>(entity =>
            {
                entity.ToTable("boardgame");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasMaxLength(36);

                entity.Property(e => e.Ano).HasColumnName("ano");

                entity.Property(e => e.BggUrl)
                    .HasColumnName("bgg_url")
                    .HasMaxLength(500);

                entity.Property(e => e.Designer)
                    .IsRequired()
                    .HasColumnName("designer")
                    .HasMaxLength(100);

                entity.Property(e => e.ImgUrl)
                    .HasColumnName("img_url")
                    .HasMaxLength(500);

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasColumnName("nome")
                    .HasMaxLength(100);

                entity.Property(e => e.Nota)
                    .HasColumnName("nota")
                    .HasColumnType("decimal(3,1)");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
