﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ConsoleApp2
{
    public partial class SchoolContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            #warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
            optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=School;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>(entity =>
            {
                entity.Property(e => e.CourseId)
                    .HasColumnName("CourseID")
                    .ValueGeneratedNever();

                entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.Course)
                    .HasForeignKey(d => d.DepartmentId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Course_Department");
            });

            modelBuilder.Entity<CourseInstructor>(entity =>
            {
                entity.HasKey(e => new { e.CourseId, e.PersonId })
                    .HasName("PK_CourseInstructor");

                entity.Property(e => e.CourseId).HasColumnName("CourseID");

                entity.Property(e => e.PersonId).HasColumnName("PersonID");

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.CourseInstructor)
                    .HasForeignKey(d => d.CourseId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_CourseInstructor_Course");

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.CourseInstructor)
                    .HasForeignKey(d => d.PersonId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_CourseInstructor_Person");
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.Property(e => e.DepartmentId)
                    .HasColumnName("DepartmentID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Budget).HasColumnType("money");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.StartDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<OfficeAssignment>(entity =>
            {
                entity.HasKey(e => e.InstructorId)
                    .HasName("PK_OfficeAssignment");

                entity.Property(e => e.InstructorId)
                    .HasColumnName("InstructorID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Location)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Timestamp)
                    .IsRequired()
                    .HasColumnType("timestamp")
                    .ValueGeneratedOnAddOrUpdate();

                entity.HasOne(d => d.Instructor)
                    .WithOne(p => p.OfficeAssignment)
                    .HasForeignKey<OfficeAssignment>(d => d.InstructorId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_OfficeAssignment_Person");
            });

            modelBuilder.Entity<OnlineCourse>(entity =>
            {
                entity.HasKey(e => e.CourseId)
                    .HasName("PK_OnlineCourse");

                entity.Property(e => e.CourseId)
                    .HasColumnName("CourseID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Url)
                    .IsRequired()
                    .HasColumnName("URL")
                    .HasMaxLength(100);

                entity.HasOne(d => d.Course)
                    .WithOne(p => p.OnlineCourse)
                    .HasForeignKey<OnlineCourse>(d => d.CourseId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_OnlineCourse_Course");
            });

            modelBuilder.Entity<OnsiteCourse>(entity =>
            {
                entity.HasKey(e => e.CourseId)
                    .HasName("PK_OnsiteCourse");

                entity.Property(e => e.CourseId)
                    .HasColumnName("CourseID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Days)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Location)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Time).HasColumnType("smalldatetime");

                entity.HasOne(d => d.Course)
                    .WithOne(p => p.OnsiteCourse)
                    .HasForeignKey<OnsiteCourse>(d => d.CourseId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_OnsiteCourse_Course");
            });

            modelBuilder.Entity<Person>(entity =>
            {
                entity.Property(e => e.PersonId).HasColumnName("PersonID");

                entity.Property(e => e.EnrollmentDate).HasColumnType("datetime");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.HireDate).HasColumnType("datetime");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<StudentGrade>(entity =>
            {
                entity.HasKey(e => e.EnrollmentId)
                    .HasName("PK_StudentGrade");

                entity.Property(e => e.EnrollmentId).HasColumnName("EnrollmentID");

                entity.Property(e => e.CourseId).HasColumnName("CourseID");

                entity.Property(e => e.Grade).HasColumnType("decimal");

                entity.Property(e => e.StudentId).HasColumnName("StudentID");

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.StudentGrade)
                    .HasForeignKey(d => d.CourseId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_StudentGrade_Course");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.StudentGrade)
                    .HasForeignKey(d => d.StudentId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_StudentGrade_Student");
            });
        }

        public virtual DbSet<Course> Course { get; set; }
        public virtual DbSet<CourseInstructor> CourseInstructor { get; set; }
        public virtual DbSet<Department> Department { get; set; }
        public virtual DbSet<OfficeAssignment> OfficeAssignment { get; set; }
        public virtual DbSet<OnlineCourse> OnlineCourse { get; set; }
        public virtual DbSet<OnsiteCourse> OnsiteCourse { get; set; }
        public virtual DbSet<Person> Person { get; set; }
        public virtual DbSet<StudentGrade> StudentGrade { get; set; }
    }
}