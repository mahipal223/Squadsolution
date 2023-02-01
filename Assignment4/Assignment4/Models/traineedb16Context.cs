﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Assignment4.Models
{
    public partial class traineedb16Context : DbContext
    {

        public traineedb16Context(DbContextOptions<traineedb16Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Department1> Department1s { get; set; } = null!;
        public virtual DbSet<Designation1> Designation1s { get; set; } = null!;
        public virtual DbSet<Employee1> Employee1s { get; set; } = null!;
        public virtual DbSet<HaveKnowledge1> HaveKnowledge1s { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department1>(entity =>
            {
                entity.HasKey(e => e.DepId);

                entity.ToTable("Department1");

                entity.Property(e => e.DepId).HasColumnName("depId");

                entity.Property(e => e.DepartmentName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("departmentName");
            });

            modelBuilder.Entity<Designation1>(entity =>
            {
                entity.HasKey(e => e.DesId);

                entity.ToTable("Designation1");

                entity.Property(e => e.DesName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Employee1>(entity =>
            {
                entity.HasKey(e => e.EmpId);

                entity.ToTable("Employee1");

                entity.Property(e => e.EmpId).HasColumnName("empId");

                entity.Property(e => e.DepartmentId).HasColumnName("departmentId");

                entity.Property(e => e.DesignationId).HasColumnName("designationId");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("firstName");

                entity.Property(e => e.HaveKnow)
                    .IsUnicode(false)
                    .HasColumnName("haveKnow");

                entity.Property(e => e.JoiningDate)
                    .HasColumnType("date")
                    .HasColumnName("joiningDate");

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("lastName");

                entity.Property(e => e.Salary).HasColumnName("salary");

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.Employee1s)
                    .HasForeignKey(d => d.DepartmentId)
                    .HasConstraintName("FK_Employee1_Department1");

                entity.HasOne(d => d.Designation)
                    .WithMany(p => p.Employee1s)
                    .HasForeignKey(d => d.DesignationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Employee1_Designation1");
            });

            modelBuilder.Entity<HaveKnowledge1>(entity =>
            {
                entity.HasKey(e => e.HaveKnowId);

                entity.ToTable("HaveKnowledge1");

                entity.Property(e => e.HaveKnowId).HasColumnName("haveKnowId");

                entity.Property(e => e.HaveKnowName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("haveKnowNAme");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
