using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace depertment.Entities
{
    public partial class Angular_Developer_ProgramContext : DbContext
    {
        public Angular_Developer_ProgramContext()
        {
        }

        public Angular_Developer_ProgramContext(DbContextOptions<Angular_Developer_ProgramContext> options)
            : base(options)
        {
        }

        public virtual DbSet<DepartmentModel> DepartmentModels { get; set; } = null!;
        public virtual DbSet<StudentModel> StudentModels { get; set; } = null!;
        public virtual DbSet<UserRegister> UserRegisters { get; set; } = null!;
        public virtual DbSet<Userlogin> Userlogins { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=KANINI-LTP-910\\sqlexpress;Initial Catalog=Angular_Developer_Program;Persist Security Info=False;User ID=sa;Password=Admin@123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=True;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DepartmentModel>(entity =>
            {
                entity.HasKey(e => e.DepartmentId)
                    .HasName("PK__Departme__B2079BCD339D8B83");

                entity.ToTable("DepartmentModel");

                entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");

                entity.Property(e => e.DepartmentName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<StudentModel>(entity =>
            {
                entity.HasKey(e => e.StudentId)
                    .HasName("PK__StudentM__32C52A79854A3428");

                entity.ToTable("StudentModel");

                entity.Property(e => e.StudentId).HasColumnName("StudentID");

                entity.Property(e => e.Course)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Percentage).HasColumnName("percentage");

                entity.Property(e => e.Specialization)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.StudentName)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.StudentModels)
                    .HasForeignKey(d => d.DepartmentId)
                    .HasConstraintName("FK__StudentMo__Depar__38996AB5");
            });

            modelBuilder.Entity<UserRegister>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__UserRegi__1788CC4CCD4722DC");

                entity.ToTable("UserRegister");

                entity.Property(e => e.EmailAddress)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MobileNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Userlogin>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__Userlogi__1788CC4C2E024F15");

                entity.ToTable("Userlogin");

                entity.Property(e => e.EmailAddress)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
