using System;
using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace BL
{
    public partial class _4ZsoftwareDbContext : DbContext
    {
        public _4ZsoftwareDbContext()
        {
        }

        public _4ZsoftwareDbContext(DbContextOptions<_4ZsoftwareDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TbClient> TbClients { get; set; }
        public virtual DbSet<TbEmployee> TbEmployees { get; set; }
        public virtual DbSet<TbTestimonial> TbTestimonials { get; set; }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//                optionsBuilder.UseSqlServer("Server=DESKTOP-ABVI0A5;Database=4ZsoftwareDb;Trusted_Connection=True;");
//            }
//        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<TbClient>(entity =>
            {
                entity.HasKey(e => e.ClentId);

                entity.Property(e => e.ClientImageName).HasMaxLength(450);

                entity.Property(e => e.ClientWebiteLink).HasMaxLength(450);

                entity.Property(e => e.CreatedBy).HasMaxLength(450);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Notes).HasMaxLength(450);

                entity.Property(e => e.UpdatedBy).HasMaxLength(450);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<TbEmployee>(entity =>
            {
                entity.HasKey(e => e.EmplyeeId);

                entity.Property(e => e.CreatedBy).HasMaxLength(450);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.EmployeeJob).HasMaxLength(450);

                entity.Property(e => e.EmployeeLinkedInLink).HasMaxLength(450);

                entity.Property(e => e.EmplyeeName).HasMaxLength(450);

                entity.Property(e => e.Notes).HasMaxLength(450);

                entity.Property(e => e.UpdatedBy).HasMaxLength(450);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<TbTestimonial>(entity =>
            {
                entity.HasKey(e => e.TestimonialId);

                entity.Property(e => e.CreatedBy).HasMaxLength(450);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Notes).HasMaxLength(450);

                entity.Property(e => e.TestimonialComment).HasMaxLength(450);

                entity.Property(e => e.TestimonialCommenter).HasMaxLength(450);

                entity.Property(e => e.TestimonialCommenterImage).HasMaxLength(450);

                entity.Property(e => e.UpdatedBy).HasMaxLength(450);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
