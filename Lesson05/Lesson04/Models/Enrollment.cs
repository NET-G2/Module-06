using Lesson05.Models.Enums;

namespace Lesson05.Models
{
    public class Enrollment
    {
        public int Id { get; set; }
        public StudentStatus Status { get; set; }

        public int StudentId { get; set; }
        public Student Student { get; set; }

        public int GroupId { get; set; }
        public CourseGroup Group { get; set; }
    }
}
