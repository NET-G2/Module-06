using Lesson03.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Lesson03.ViewModels
{
    public class StudentViewModel
    {
        public List<Student> Students { get; set; }
        public List<SelectListItem> Groups { get; set; }
        public string Group { get; set; }
    }
}
