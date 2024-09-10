using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Input_Forms.Models;

public partial class InputFormsContext : DbContext
{
    public InputFormsContext()
    {
    }

    public InputFormsContext(DbContextOptions<InputFormsContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TblStudent> TblStudents { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TblStudent>(entity =>
        {
            entity.ToTable("tblStudent");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.SchoolName)
                .HasMaxLength(20)
                .HasColumnName("School Name");
            entity.Property(e => e.StudentGender)
                .HasMaxLength(50)
                .HasColumnName("Student Gender");
            entity.Property(e => e.StudentName)
                .HasMaxLength(20)
                .HasColumnName("Student Name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
