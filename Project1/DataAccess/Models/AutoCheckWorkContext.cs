using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Models;

public partial class AutoCheckWorkContext : DbContext
{
    public AutoCheckWorkContext()
    {
    }

    public AutoCheckWorkContext(DbContextOptions<AutoCheckWorkContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Assignment> Assignments { get; set; }

    public virtual DbSet<AssignmentType> AssignmentTypes { get; set; }

    public virtual DbSet<Course> Courses { get; set; }

    public virtual DbSet<Group> Groups { get; set; }

    public virtual DbSet<ProgrammingLanguage> ProgrammingLanguages { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Submission> Submissions { get; set; }

    public virtual DbSet<SubmissionResult> SubmissionResults { get; set; }

    public virtual DbSet<TestCase> TestCases { get; set; }

    public virtual DbSet<User> Users { get; set; }

    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Assignment>(entity =>
        {
            entity.HasKey(e => e.AssignmentId).HasName("PK__Assignme__32499E774CE7B6F8");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.MaxPoints).HasDefaultValue(10);
            entity.Property(e => e.Title).HasMaxLength(100);

            entity.HasOne(d => d.Course).WithMany(p => p.Assignments)
                .HasForeignKey(d => d.CourseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Assignments_Courses");

            entity.HasOne(d => d.Language).WithMany(p => p.Assignments)
                .HasForeignKey(d => d.LanguageId)
                .HasConstraintName("FK_Assignments_Languages");

            entity.HasOne(d => d.Type).WithMany(p => p.Assignments)
                .HasForeignKey(d => d.TypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Assignments_Types");
        });

        modelBuilder.Entity<AssignmentType>(entity =>
        {
            entity.HasKey(e => e.TypeId).HasName("PK__Assignme__516F03B532CB6991");

            entity.HasIndex(e => e.TypeName, "UQ__Assignme__D4E7DFA85B919C3B").IsUnique();

            entity.Property(e => e.TypeName).HasMaxLength(30);
        });

        modelBuilder.Entity<Course>(entity =>
        {
            entity.HasKey(e => e.CourseId).HasName("PK__Courses__C92D71A7B11F3F34");

            entity.Property(e => e.CourseName).HasMaxLength(100);
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Description).HasMaxLength(500);

            entity.HasOne(d => d.Group).WithMany(p => p.Courses)
                .HasForeignKey(d => d.GroupId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Courses_Group");

            entity.HasOne(d => d.Instructor).WithMany(p => p.Courses)
                .HasForeignKey(d => d.InstructorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Courses_Instructor");
        });

        modelBuilder.Entity<Group>(entity =>
        {
            entity.HasKey(e => e.GroupId).HasName("PK__Groups__149AF36A49855720");

            entity.HasIndex(e => e.GroupName, "UQ__Groups__6EFCD434F39CB600").IsUnique();

            entity.Property(e => e.GroupName).HasMaxLength(20);
        });

        modelBuilder.Entity<ProgrammingLanguage>(entity =>
        {
            entity.HasKey(e => e.LanguageId).HasName("PK__Programm__B93855ABFB7C07D5");

            entity.HasIndex(e => e.LanguageName, "UQ__Programm__E89C4A6A531F9DCF").IsUnique();

            entity.Property(e => e.FileExtension).HasMaxLength(10);
            entity.Property(e => e.LanguageName).HasMaxLength(50);
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("PK__Roles__8AFACE1AC3237B10");

            entity.HasIndex(e => e.RoleName, "UQ__Roles__8A2B6160FDB38EA9").IsUnique();

            entity.Property(e => e.RoleName).HasMaxLength(30);
        });

        modelBuilder.Entity<Submission>(entity =>
        {
            entity.HasKey(e => e.SubmissionId).HasName("PK__Submissi__449EE125F2AD3662");

            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .HasDefaultValue("Pending");
            entity.Property(e => e.SubmittedAt).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.Assignment).WithMany(p => p.Submissions)
                .HasForeignKey(d => d.AssignmentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Submissions_Assignments");

            entity.HasOne(d => d.Student).WithMany(p => p.Submissions)
                .HasForeignKey(d => d.StudentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Submissions_Students");
        });

        modelBuilder.Entity<SubmissionResult>(entity =>
        {
            entity.HasKey(e => e.ResultId).HasName("PK__Submissi__976902083FAD8777");

            entity.Property(e => e.CheckedAt).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.GradedByNavigation).WithMany(p => p.SubmissionResults)
                .HasForeignKey(d => d.GradedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Results_Grader");

            entity.HasOne(d => d.Submission).WithMany(p => p.SubmissionResults)
                .HasForeignKey(d => d.SubmissionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Results_Submissions");

            entity.HasOne(d => d.TestCase).WithMany(p => p.SubmissionResults)
                .HasForeignKey(d => d.TestCaseId)
                .HasConstraintName("FK_Results_TestCases");
        });

        modelBuilder.Entity<TestCase>(entity =>
        {
            entity.HasKey(e => e.TestCaseId).HasName("PK__TestCase__D2074A9488390D5B");

            entity.Property(e => e.IsHidden).HasDefaultValue(false);

            entity.HasOne(d => d.Assignment).WithMany(p => p.TestCases)
                .HasForeignKey(d => d.AssignmentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TestCases_Assignments");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__1788CC4CCF5EE73B");

            entity.HasIndex(e => e.Email, "UQ__Users__A9D105345205D61F").IsUnique();

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.LastName).HasMaxLength(50);

            entity.HasOne(d => d.Group).WithMany(p => p.Users)
                .HasForeignKey(d => d.GroupId)
                .HasConstraintName("FK_Users_Groups");

            entity.HasOne(d => d.Role).WithMany(p => p.Users)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Users_Roles");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
