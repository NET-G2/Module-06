namespace Lesson07.Models
{
    internal abstract class Student : Person
    {
        public decimal AverageGrade { get; set; }
        public int Semester { get; set; }
        public string Status { get; set; }
    }
}
