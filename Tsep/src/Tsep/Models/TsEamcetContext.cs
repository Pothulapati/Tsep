using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Tsep.Models
{
    public partial class TsEamcetContext : DbContext
    {
        public virtual DbSet<CollegeGroups> CollegeGroups { get; set; }
        public virtual DbSet<Colleges> Colleges { get; set; }
        public virtual DbSet<Groups> Groups { get; set; }
        public virtual DbSet<Tseamcetdata> Tseamcetdata { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            #warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
            optionsBuilder.UseSqlServer(@"data source=DESKTOP-5BP7CEK;initial catalog=TsEamcet;persist security info=True;Integrated Security=SSPI;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CollegeGroups>(entity =>
            {
                entity.HasKey(e => e.CollegeGroup)
                    .HasName("PK_CollegeGroups_CollegeGroup");

                entity.Property(e => e.CollegeGroup).HasColumnType("varchar(10)");

                entity.Property(e => e.CollegeCode)
                    .IsRequired()
                    .HasColumnType("varchar(6)");

                entity.Property(e => e.GroupCode)
                    .IsRequired()
                    .HasColumnType("char(3)");

                entity.HasOne(d => d.CollegeCodeNavigation)
                    .WithMany(p => p.CollegeGroups)
                    .HasForeignKey(d => d.CollegeCode)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__CollegeGr__Colle__3D5E1FD2");

                entity.HasOne(d => d.GroupCodeNavigation)
                    .WithMany(p => p.CollegeGroups)
                    .HasForeignKey(d => d.GroupCode)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__CollegeGr__Group__3E52440B");
            });

            modelBuilder.Entity<Colleges>(entity =>
            {
                entity.HasKey(e => e.Code)
                    .HasName("PK_Colleges_CollegeCode");

                entity.Property(e => e.Code).HasColumnType("varchar(6)");

                entity.Property(e => e.Address).HasColumnType("varchar(max)");

                entity.Property(e => e.Affliation).HasColumnType("varchar(10)");

                entity.Property(e => e.Aided).HasColumnType("varchar(8)");

                entity.Property(e => e.CoEd)
                    .HasColumnName("CoED")
                    .HasColumnType("varchar(6)");

                entity.Property(e => e.District).HasColumnType("varchar(30)");

                entity.Property(e => e.Email).HasColumnType("varchar(max)");

                entity.Property(e => e.Hostel).HasColumnType("varchar(40)");

                entity.Property(e => e.Minority).HasColumnType("varchar(5)");

                entity.Property(e => e.Name).HasColumnType("varchar(100)");

                entity.Property(e => e.PhoneNo).HasColumnType("varchar(20)");

                entity.Property(e => e.Place).HasColumnType("varchar(30)");

                entity.Property(e => e.Region).HasColumnType("char(2)");

                entity.Property(e => e.Type).HasColumnType("varchar(5)");

                entity.Property(e => e.Website).HasColumnType("varchar(30)");
            });

            modelBuilder.Entity<Groups>(entity =>
            {
                entity.HasKey(e => e.GroupCode)
                    .HasName("Pk_Groups_GroupCode");

                entity.Property(e => e.GroupCode).HasColumnType("char(3)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("varchar(60)");
            });

            modelBuilder.Entity<Tseamcetdata>(entity =>
            {
                entity.HasKey(e => e.RowKey)
                    .HasName("Pk_tseamcetdatahall");

                entity.ToTable("tseamcetdata");

                entity.Property(e => e.RowKey).ValueGeneratedNever();

                entity.Property(e => e.Caste).HasColumnType("varchar(4)");

                entity.Property(e => e.CombinedScore).HasColumnType("decimal");

                entity.Property(e => e.EamcetW).HasColumnType("decimal");

                entity.Property(e => e.FathersName).HasColumnType("varchar(50)");

                entity.Property(e => e.GroupTotal).HasColumnType("varchar(50)");

                entity.Property(e => e.InterPercent).HasColumnType("decimal");

                entity.Property(e => e.InterW).HasColumnType("decimal");

                entity.Property(e => e.Name).HasColumnType("varchar(50)");

                entity.Property(e => e.Region).HasColumnType("char(2)");

                entity.Property(e => e.Result).HasColumnType("varchar(30)");

                entity.Property(e => e.Sex).HasColumnType("char(1)");

                entity.Property(e => e.Stream).HasColumnType("char(11)");

                entity.Property(e => e.Timestamp).HasColumnType("varchar(50)");
            });
        }
    }
}