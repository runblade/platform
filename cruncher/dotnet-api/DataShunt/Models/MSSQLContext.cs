using System;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DataShunt.Models
{
    public partial class MSSQLContext : DbContext
    {
        public MSSQLContext(DbContextOptions<MSSQLContext> options)
            : base(options)
        {
            Console.WriteLine("MSSQLContext called...");
        }

        public virtual DbSet<SampleGovernment> SampleGovernment { get; set; }
        public virtual DbSet<SampleTransport> SampleTransport { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                //optionsBuilder.UseSqlServer("Server=127.0.0.1;Database=MSSQL;User Id=USERID;Password=YOURPASSWORDHERE!");
                //Changed to DbContext injection
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SampleGovernment>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("SAMPLE_GOVERNMENT");

                entity.Property(e => e.Category)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Location)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LocationType)
                    .IsRequired()
                    .HasColumnName("Location_Type")
                    .HasMaxLength(50);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Notes).HasMaxLength(100);

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<SampleTransport>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("SAMPLE_TRANSPORT");

                entity.Property(e => e.Address).HasMaxLength(1);

                entity.Property(e => e.DocksInService).HasColumnName("Docks_in_Service");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Location)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.StationName)
                    .IsRequired()
                    .HasColumnName("Station_Name")
                    .HasMaxLength(50);

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.TotalDocks).HasColumnName("Total_Docks");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
