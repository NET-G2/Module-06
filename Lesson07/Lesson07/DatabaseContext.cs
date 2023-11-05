using Lesson07.Models;
using Microsoft.EntityFrameworkCore;

namespace Lesson07
{
    internal class DatabaseContext : DbContext
    {
        public virtual DbSet<Person> Persons { get; set; }
        public virtual DbSet<Teacher> Teachers { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<FullTimeStudent> FullTimeStudents { get; set; }
        public virtual DbSet<PartTimeStudent> PartTimeStudents { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Security> Securities { get; set; }

        public DatabaseContext()
        {
            // Database.Migrate();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Data Source=MIRAZIZ\\SQLEXPRESS;Initial Catalog=Lesson07;Integrated Security=True;TrustServerCertificate=True;");

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // TPH
            //modelBuilder.Entity<Person>()
            //    .UseTphMappingStrategy()
            //    .HasDiscriminator<string>("person_type")
            //    .HasValue<Teacher>("person_teacher")
            //    .HasValue<Student>("person_student")
            //    .HasValue<FullTimeStudent>("person_student_full_time")
            //    .HasValue<PartTimeStudent>("person_student_part_time")
            //    .HasValue<Employee>("person_employee")
            //    .HasValue<Security>("person_security");

            // TPT
            //modelBuilder.Entity<Person>()
            //    .ToTable(nameof(Person));
            //modelBuilder.Entity<Teacher>()
            //    .ToTable(nameof(Teacher));
            //modelBuilder.Entity<Student>()
            //    .ToTable(nameof(Student));
            //modelBuilder.Entity<PartTimeStudent>()
            //    .ToTable(nameof(PartTimeStudent));
            //modelBuilder.Entity<FullTimeStudent>()
            //    .ToTable(nameof(FullTimeStudent));
            //modelBuilder.Entity<Employee>()
            //    .ToTable(nameof(Employee));
            //modelBuilder.Entity<Security>()
            //    .ToTable(nameof(Security));

            // TPC
            modelBuilder.Entity<Person>()
                .UseTpcMappingStrategy();

            base.OnModelCreating(modelBuilder);
        }
    }
}
