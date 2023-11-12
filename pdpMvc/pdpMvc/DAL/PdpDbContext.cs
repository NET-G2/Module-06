using Lesson03.Models;
using Microsoft.EntityFrameworkCore;
using pdpMvc.Models;
using pdpMvc.Models.Enums;

namespace Lesson03.DAL
{
    public class PdpDbContext : DbContext
    {
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Teacher> Teachers { get; set; }
        public virtual DbSet<Subject> Subjects { get; set; }
        public virtual DbSet<Enrollment> Enrollments { get; set; }
        public virtual DbSet<Assignment> Assignments { get; set; }
        public virtual DbSet<CourseGroup> Groups { get; set; }
        public virtual DbSet<Module> Modules { get; set; }
        public virtual DbSet<ModuleTopic> ModuleTopics { get; set; }


        public PdpDbContext(DbContextOptions<PdpDbContext> options)
            : base(options)
        {
            Database.Migrate();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Student
            modelBuilder.Entity<Student>()
                .ToTable(nameof(Student));
            modelBuilder.Entity<Student>()
                .HasKey(s => s.Id);
            modelBuilder.Entity<Student>()
                .Property(s => s.FullName)
                .HasMaxLength(255);
            modelBuilder.Entity<Student>()
                .Property(s => s.Balance)
                .HasColumnType("money");
            modelBuilder.Entity<Student>()
                .Property(s => s.PhoneNumber)
                .HasColumnName("Phone");
            modelBuilder.Entity<Student>()
                .HasMany(s => s.Enrollments)
                .WithOne(e => e.Student)
                .HasForeignKey(e => e.StudentId)
                .HasConstraintName("Student_Enrollment_FK");
            #endregion

            #region Teacher
            modelBuilder.Entity<Teacher>()
                .ToTable(nameof(Teacher));
            modelBuilder.Entity<Teacher>()
                .HasKey(t => t.Id);
            modelBuilder.Entity<Teacher>()
                .Property(t => t.FirstName)
                .HasMaxLength(255);
            modelBuilder.Entity<Teacher>()
                .Property(t => t.LastName)
                .HasMaxLength(255);
            modelBuilder.Entity<Teacher>()
                .Property(t => t.PhoneNumber)
                .HasColumnName("Phone");
            modelBuilder.Entity<Teacher>()
                .Property(t => t.HourlyRate)
                .HasColumnType("money");
            modelBuilder.Entity<Teacher>()
                .HasMany(t => t.Assignments)
                .WithOne(a => a.Teacher)
                .HasForeignKey(a => a.TeacherId)
                .HasConstraintName("Teacher_Assignment_FK");
            modelBuilder.Entity<Teacher>()
                .HasMany(t => t.Courses)
                .WithOne(cg => cg.Teacher)
                .HasForeignKey(cg => cg.TeacherId)
                .HasConstraintName("Teacher_Course_FK");
            #endregion

            #region Subject
            modelBuilder.Entity<Subject>()
                .ToTable(nameof(Subject));
            modelBuilder.Entity<Subject>()
                .HasKey(t => t.Id);
            modelBuilder.Entity<Subject>()
                .Property(s => s.Price)
                .HasColumnType("money");
            modelBuilder.Entity<Subject>()
                .Property(s => s.Title)
                .HasMaxLength(255);
            modelBuilder.Entity<Subject>()
                .Property(s => s.Description)
                .HasMaxLength(500);
            modelBuilder.Entity<Subject>()
                .HasMany(s => s.Courses)
                .WithOne(e => e.Subject)
                .HasForeignKey(e => e.SubjectId)
                .HasConstraintName("Subject_Course_FK");
            modelBuilder.Entity<Subject>()
                .HasMany(s => s.Assignments)
                .WithOne(a => a.Subject)
                .HasForeignKey(a => a.SubjectId)
                .HasConstraintName("Subject_Assignment_FK");
            #endregion

            #region Enrollment
            modelBuilder.Entity<Enrollment>()
                .ToTable(nameof(Enrollment));
            modelBuilder.Entity<Enrollment>()
                .HasAlternateKey(e => new
                {
                    e.GroupId,
                    e.StudentId
                });
            modelBuilder.Entity<Enrollment>()
                .Property(e => e.CourseStatus)
                .HasDefaultValue(CourseStatus.Active);
            modelBuilder.Entity<Enrollment>()
                .HasOne(e => e.Group)
                .WithMany(g => g.Enrollments)
                .HasForeignKey(e => e.GroupId)
                .HasConstraintName("Enrollment_Course_FK");
            #endregion Enrollment

            #region CourseGroup
            modelBuilder.Entity<CourseGroup>()
                .ToTable("Course_Group");
            modelBuilder.Entity<CourseGroup>()
                .HasKey(cg => cg.Id);
            modelBuilder.Entity<CourseGroup>()
                .Property(cg => cg.Name)
                .HasMaxLength(255);
            modelBuilder.Entity<CourseGroup>()
                .Property(cg => cg.StartDate)
                .HasColumnType("date");
            modelBuilder.Entity<CourseGroup>()
                .Property(cg => cg.ExpectedFinishDate)
                .HasColumnType("date")
                .IsRequired(false);
            modelBuilder.Entity<CourseGroup>()
                .Property(cg => cg.ActualFinishDate)
                .HasColumnType("date")
                .IsRequired(false);
            #endregion

            #region Assignment
            modelBuilder.Entity<Assignment>()
                .ToTable("Assignment");
            modelBuilder.Entity<Assignment>()
                .HasKey(a => a.Id);
            #endregion

            #region Module
            modelBuilder.Entity<Module>()
                .ToTable("Module");
            modelBuilder.Entity<Module>()
                .HasKey(m => m.Id);
            modelBuilder.Entity<Module>()
                .Property(m => m.Name)
                .HasMaxLength(255);
            modelBuilder.Entity<Module>()
                .Property(m => m.Description) 
                .HasMaxLength(500);
            modelBuilder.Entity<Module>()
                .Property(m => m.Number)
                .HasDefaultValue(1);
            modelBuilder.Entity<Module>()
                .HasOne(m => m.Subject)
                .WithMany(s => s.Modules)
                .HasForeignKey(m => m.SubjectId)
                .HasConstraintName("Module_subject_FK");
            #endregion

            #region ModuleTopic
            modelBuilder.Entity<ModuleTopic>()
                .ToTable("Module Topic");
            modelBuilder.Entity<ModuleTopic>()
                .HasKey(mt => mt.Id);
            modelBuilder.Entity<ModuleTopic>()
                .Property(mt => mt.Name)
                .HasMaxLength(255);
            modelBuilder.Entity<ModuleTopic>()
                .Property(mt => mt.Descrtiption)
                .HasMaxLength(500);
            modelBuilder.Entity<ModuleTopic>()
                .HasOne(mt => mt.Module)
                .WithMany(m => m.ModuleTopics)
                .HasForeignKey(mt => mt.ModuleId)
                .HasConstraintName("ModuleTopic_Module_FK");
            #endregion

            base.OnModelCreating(modelBuilder);
        }
    }
}
