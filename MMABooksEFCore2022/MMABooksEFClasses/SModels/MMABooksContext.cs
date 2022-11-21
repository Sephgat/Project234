using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MMABooksEFClasses.SModels
{
    public partial class MMABooksContext : DbContext
    {
        public MMABooksContext()
        {
        }

        public MMABooksContext(DbContextOptions<MMABooksContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Supplier> Suppliers { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
              optionsBuilder.UseMySql("server=127.0.0.1;uid=root;pwd=Wwefan@22;database=SuppliersFramework", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.31-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8mb4_0900_ai_ci")
                .HasCharSet("utf8mb4");

            modelBuilder.Entity<Supplier>(entity =>
            {
                entity.ToTable("suppliers");

                entity.Property(e => e.SupplierId).HasColumnName("SupplierID");

                entity.Property(e => e.Address).HasMaxLength(50);

                entity.Property(e => e.ConcurrencyId)
                    .HasColumnName("ConcurrencyID")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .HasColumnName("email");

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(15)
                    .IsFixedLength();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
