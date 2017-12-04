using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebApplication1
{
    public partial class kindergartenContext : DbContext
    {
        public virtual DbSet<Educators> Educators { get; set; }
        public virtual DbSet<Groups> Groups { get; set; }
        public virtual DbSet<Pupils> Pupils { get; set; }
        public virtual DbSet<TypesOfGroups> TypesOfGroups { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(@"Server=ADMIN-PC\SQLEXPRESS;Database=kindergarten;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Educators>(entity =>
            {
                entity.ToTable("educators");

                entity.Property(e => e.EducatorsId).HasColumnName("educators_id");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasColumnType("nchar(10)");

                entity.Property(e => e.Awards)
                    .IsRequired()
                    .HasColumnType("nchar(10)");

                entity.Property(e => e.Fio)
                    .IsRequired()
                    .HasColumnName("FIO")
                    .HasColumnType("nchar(10)");
            });

            modelBuilder.Entity<Groups>(entity =>
            {
                entity.ToTable("groups");

                entity.Property(e => e.GroupsId).HasColumnName("groups_id");

                entity.Property(e => e.EducatorsId).HasColumnName("educators_id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(10);

                entity.Property(e => e.NumberOfChildren).HasColumnName("number_of_children");

                entity.Property(e => e.TypesOfGroupsId).HasColumnName("types_of_groups_id");

                entity.Property(e => e.YearOfCreation)
                    .HasColumnName("year_of_creation")
                    .HasColumnType("date");

                entity.HasOne(d => d.Educators)
                    .WithMany(p => p.Groups)
                    .HasForeignKey(d => d.EducatorsId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_groups_educators");

                entity.HasOne(d => d.TypesOfGroups)
                    .WithMany(p => p.Groups)
                    .HasForeignKey(d => d.TypesOfGroupsId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_groups_types_of_groups");
            });

            modelBuilder.Entity<Pupils>(entity =>
            {
                entity.ToTable("pupils");

                entity.Property(e => e.PupilsId).HasColumnName("pupils_id");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasColumnName("address")
                    .HasMaxLength(25);

                entity.Property(e => e.AttendanceGroup)
                    .IsRequired()
                    .HasColumnName("attendance_group")
                    .HasMaxLength(25);

                entity.Property(e => e.DateOfBirth)
                    .HasColumnName("date_of_birth")
                    .HasColumnType("date");

                entity.Property(e => e.Fio)
                    .IsRequired()
                    .HasColumnName("FIO")
                    .HasMaxLength(25);

                entity.Property(e => e.FioFather)
                    .IsRequired()
                    .HasColumnName("FIO_father")
                    .HasMaxLength(25);

                entity.Property(e => e.FioMather)
                    .IsRequired()
                    .HasColumnName("FIO_mather")
                    .HasMaxLength(25);

                entity.Property(e => e.GroupsId).HasColumnName("groups_id");

                entity.Property(e => e.Info)
                    .IsRequired()
                    .HasColumnName("info")
                    .HasMaxLength(25);

                entity.HasOne(d => d.Groups)
                    .WithMany(p => p.Pupils)
                    .HasForeignKey(d => d.GroupsId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_pupils_groups");
            });

            modelBuilder.Entity<TypesOfGroups>(entity =>
            {
                entity.ToTable("types_of_groups");

                entity.Property(e => e.TypesOfGroupsId).HasColumnName("Types_of_groups_id");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });
        }
    }
}
