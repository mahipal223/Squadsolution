using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace assignment2.Models;

public partial class Traineedb16Context : DbContext
{


    public Traineedb16Context(DbContextOptions<Traineedb16Context> options) : base(options)
    {
    }

    public virtual DbSet<Employeee> Employeees { get; set; }

    public virtual DbSet<Hr> Hrs { get; set; }

    public virtual DbSet<Location> Locations { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employeee>(entity =>
        {
            entity.HasKey(e => e.EmpId);

            entity.ToTable("Employeee");

            entity.Property(e => e.EmpId)
                .ValueGeneratedNever()
                .HasColumnName("empId");
            entity.Property(e => e.ContactNo).HasColumnName("contactNo");
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("firstName");
            entity.Property(e => e.HomeAddress)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("homeAddress");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("lastName");
            entity.Property(e => e.WorkLocation)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("workLocation");
        });

        modelBuilder.Entity<Hr>(entity =>
        {
            entity.ToTable("Hr");

            entity.Property(e => e.HrId).HasColumnName("hrId");
            entity.Property(e => e.EmpId).HasColumnName("empId");
            entity.Property(e => e.EmpPayrollInfo)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("empPayrollInfo");
            entity.Property(e => e.Salary).HasColumnName("salary");
            entity.Property(e => e.SocialSecurityNo).HasColumnName("socialSecurityNo");

            entity.HasOne(d => d.Emp).WithMany(p => p.Hrs)
                .HasForeignKey(d => d.EmpId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Hr_Employeee");
        });

        modelBuilder.Entity<Location>(entity =>
        {
            entity.ToTable("location");

            entity.Property(e => e.LocationId).HasColumnName("locationId");
            entity.Property(e => e.Address)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("address");
            entity.Property(e => e.BuildingId).HasColumnName("buildingId");
            entity.Property(e => e.ManagerName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("managerName");
            entity.Property(e => e.ZipCode).HasColumnName("zipCode");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
