namespace Lesson03.Models
{
    public class CourseGroup
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly? ExpectedFinishDate { get; set; }
        public DateOnly? ActualFinishDate { get; set; }

        public int SubjectId { get; set; }
        public Subject Subject { get; set; }

        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }

        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
}
