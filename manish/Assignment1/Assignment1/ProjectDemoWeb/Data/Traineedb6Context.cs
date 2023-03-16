using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ProjectDemoWeb.Data;

public partial class Traineedb6Context : DbContext
{
    public Traineedb6Context()
    {
    }

    public Traineedb6Context(DbContextOptions<Traineedb6Context> options)
        : base(options)
    {
    }

    public virtual DbSet<EmployeeFullName> EmployeeFullNames { get; set; }

    public virtual DbSet<EmployeeMain> EmployeeMains { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=WIN-390Q81UT43Q\\SQLEXPRESS2017;Database=traineedb6;User Id=traineedb6;Password=Jir0Dgs3OacFX49M;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<EmployeeFullName>(entity =>
        {
            entity.HasKey(e => e.EmployeeNoId).HasName("PK__Employee__8128592CCB94F8D0");

            entity.ToTable("EmployeeFullName");

            entity.Property(e => e.FirstName)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.Emp).WithMany(p => p.EmployeeFullNames)
                .HasForeignKey(d => d.EmpId)
                .HasConstraintName("FK__EmployeeF__EmpId__467D75B8");
        });

        modelBuilder.Entity<EmployeeMain>(entity =>
        {
            entity.HasKey(e => e.EmpId).HasName("PK__Employee__AF2DBB9947E35C0C");

            entity.ToTable("EmployeeMain");

            entity.Property(e => e.Address)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.CompanyLocation)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
