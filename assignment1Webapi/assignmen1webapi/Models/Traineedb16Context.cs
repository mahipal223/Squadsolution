using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace assignmen1webapi.Models;

public partial class Traineedb16Context : DbContext
{

    public Traineedb16Context(DbContextOptions<Traineedb16Context> options) : base(options)
    {

    }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.DepId);
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.EmpId);

            entity.HasOne(d => d.Dep).WithMany(p => p.Employees).HasForeignKey(d => d.DepId);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
