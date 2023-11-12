using Lesson03.Models;

namespace pdpMvc.Models
{
    public class Module
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Number { get; set; }
        public string Description { get; set; }

        public int SubjectId { get; set; }
        public Subject Subject { get; set; }

        public virtual ICollection<ModuleTopic> ModuleTopics { get; set; }
    }
}
