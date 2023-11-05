using Bogus;
using Lesson07.Models;
using Microsoft.EntityFrameworkCore;
using System.Runtime.ExceptionServices;

namespace Lesson07
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // UpdateUniversityData();

            LoadUniversityData();
        }

        static void UpdateUniversityData()
        {
            using var context = new DatabaseContext();
            var faker = new Faker();

            //context.Persons.Add(new Models.Person
            //{
            //    FirstName = faker.Person.FirstName,
            //    LastName = faker.Person.LastName,
            //    Address = faker.Address.FullAddress(),
            //    Birthdate = faker.Person.DateOfBirth,
            //    PhoneNumber = faker.Person.Phone
            //});

            context.Teachers.Add(new Teacher
            {
                FirstName = faker.Person.FirstName,
                LastName = faker.Person.LastName,
                Address = faker.Address.FullAddress(),
                Birthdate = faker.Person.DateOfBirth,
                PhoneNumber = faker.Person.Phone,
                Experience = 3,
                HourlyRate = 12
            });

            //context.Students.Add(new Student
            //{
            //    FirstName = faker.Person.FirstName,
            //    LastName = faker.Person.LastName,
            //    Address = faker.Address.FullAddress(),
            //    Birthdate = faker.Person.DateOfBirth,
            //    PhoneNumber = faker.Person.Phone,
            //    AverageGrade = 4.2m,
            //    Semester = 3,
            //    Status = "Active"
            //});

            context.PartTimeStudents.Add(new PartTimeStudent
            {
                FirstName = faker.Person.FirstName,
                LastName = faker.Person.LastName,
                Address = faker.Address.FullAddress(),
                Birthdate = faker.Person.DateOfBirth,
                PhoneNumber = faker.Person.Phone,
                AverageGrade = 3.2m,
                Semester = 2,
                Status = "Active",
                StudyDays = 3
            });

            context.FullTimeStudents.Add(new FullTimeStudent
            {
                FirstName = faker.Person.FirstName,
                LastName = faker.Person.LastName,
                Address = faker.Address.FullAddress(),
                Birthdate = faker.Person.DateOfBirth,
                PhoneNumber = faker.Person.Phone,
                AverageGrade = 4.2m,
                Semester = 5,
                Status = "Deactivated",
                Smena = 2
            });

            context.Employees.Add(new Employee
            {
                FirstName = faker.Person.FirstName,
                LastName = faker.Person.LastName,
                Address = faker.Address.FullAddress(),
                Birthdate = faker.Person.DateOfBirth,
                PhoneNumber = faker.Person.Phone,
                Salary = faker.Random.Decimal(100, 1000),
                Hiredate = DateTime.Now.AddYears(-2)
            });

            context.Securities.Add(new Security
            {
                FirstName = faker.Person.FirstName,
                LastName = faker.Person.LastName,
                Address = faker.Address.FullAddress(),
                Birthdate = faker.Person.DateOfBirth,
                PhoneNumber = faker.Person.Phone,
                Salary = faker.Random.Decimal(100, 1000),
                Hiredate = DateTime.Now.AddYears(-2),
                Smena = 2
            });

            context.SaveChanges();
        }

        static void LoadUniversityData()
        {
            using var context = new DatabaseContext();

            var persons = context.Persons.Where(x => x.FirstName.Contains("a"));
            var teachers = context.Teachers.Where(x => x.FirstName.Contains("a"));
            var students = context.Students.Where(x => x.FirstName.Contains("a"));
            var optimaLStudents = context.Students.Select(x => new
            {
                x.Id,
                x.FirstName,
                x.LastName,
                x.Birthdate,
                x.Address,
                x.PhoneNumber,
                x.AverageGrade,
                x.Status,
                x.Semester
            });
            var partime = context.PartTimeStudents.Where(x => x.FirstName.Contains("a"));
            var fulltime = context.FullTimeStudents.Where(x => x.FirstName.Contains("a"));
            var employee = context.Employees.Where(x => x.FirstName.Contains("a"));
            var securities = context.Securities.Where(x => x.FirstName.Contains("a"));

            var personsQuery = persons.ToQueryString();
            var teachersQuery = teachers.ToQueryString();
            var studentsQuery = students.ToQueryString();
            var optimalQuery = optimaLStudents.ToQueryString();
            var parttimeQuery = partime.ToQueryString();
            var fullTimeQuery = fulltime.ToQueryString();
            var employeeQuery = employee.ToQueryString();
            var secQuery = securities.ToQueryString();

            int g = 0;
        }
    }
}