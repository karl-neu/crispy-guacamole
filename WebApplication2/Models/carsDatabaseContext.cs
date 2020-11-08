using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebApplication2.Models
{
    public partial class carsDatabaseContext : DbContext
    {
        public carsDatabaseContext()
        {
        }

        public carsDatabaseContext(DbContextOptions<carsDatabaseContext> options)
            : base(options)
        {
            ChangeTracker.LazyLoadingEnabled = false;
        }

        public virtual DbSet<Car> Car { get; set; }
        public virtual DbSet<Engine> Engine { get; set; }
        public virtual DbSet<Manufacturer> Manufacturer { get; set; }
        public virtual DbSet<Owner> Owner { get; set; }
        public virtual DbSet<OwnerManufacturer> OwnerManufacturer { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseLazyLoadingProxies().UseSqlServer("Server = tcp:mysqlserver699.database.windows.net, 1433; Initial Catalog = carsDatabase; Persist Security Info = False; User ID = azureuser; Password = Abc131289!; MultipleActiveResultSets = False; Encrypt = True; TrustServerCertificate = False; Connection Timeout = 30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>(entity =>
            {
                entity.HasIndex(e => e.EngineId)
                    .HasName("UQ__Car__7BBCE905DB6E4422")
                    .IsUnique();

                entity.Property(e => e.Color)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.Model)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.HasOne(d => d.Engine)
                    .WithOne(p => p.Car)
                    .HasForeignKey<Car>(d => d.EngineId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Car_Engine");

                entity.HasOne(d => d.Manufacturer)
                    .WithMany(p => p.Car)
                    .HasForeignKey(d => d.ManufacturerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Car_Manufacturer");
            });

            modelBuilder.Entity<Engine>(entity =>
            {
                entity.Property(e => e.Series)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(30);
            });

            modelBuilder.Entity<Manufacturer>(entity =>
            {
                entity.Property(e => e.Headquarters)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Owner>(entity =>
            {
                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.PhoneNumber).HasMaxLength(30);
            });

            modelBuilder.Entity<OwnerManufacturer>(entity =>
            {
                entity.HasNoKey();

                entity.HasOne(d => d.Manufacturer)
                    .WithMany()
                    .HasForeignKey(d => d.ManufacturerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OwnerManufacturer_Manufacturer");

                entity.HasOne(d => d.Owner)
                    .WithMany()
                    .HasForeignKey(d => d.OwnerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OwnerManufacturer_Owner");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
