using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Project1Model;

public partial class Traineedb6Context : DbContext
{
    public Traineedb6Context()
    {
    }

    public Traineedb6Context(DbContextOptions<Traineedb6Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Department1> Department1s { get; set; }

    public virtual DbSet<Employee1> Employee1s { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=WIN-390Q81UT43Q\\SQLEXPRESS2017;Database=traineedb6;User Id=traineedb6;Password=Jir0Dgs3OacFX49M;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Department1>(entity =>
        {
            entity.HasKey(e => e.DeptId);

            entity.ToTable("department1");

            entity.Property(e => e.DeptId).HasColumnName("Dept_Id");
            entity.Property(e => e.DeptName).HasColumnName("Dept_Name");
        });

        modelBuilder.Entity<Employee1>(entity =>
        {
            entity.HasKey(e => e.EmpId);

            entity.ToTable("Employee1");

            entity.HasIndex(e => e.DeptId, "IX_Employee1_DeptId").HasFillFactor(80);

            entity.Property(e => e.EmpId).HasColumnName("Emp_Id");
            entity.Property(e => e.EmpName)
                .HasMaxLength(25)
                .HasColumnName("Emp_Name");
            entity.Property(e => e.EmpSalary).HasColumnName("Emp_Salary");

            entity.HasOne(d => d.Dept).WithMany(p => p.Employee1s).HasForeignKey(d => d.DeptId);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
