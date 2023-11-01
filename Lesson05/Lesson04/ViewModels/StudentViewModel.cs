using Lesson05.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Lesson05.ViewModels
{
    public class StudentViewModel
    {
        public List<Student> Students { get; set; }
        public List<SelectListItem> Groups { get; set; }
        public string Group { get; set; }
    }
}
