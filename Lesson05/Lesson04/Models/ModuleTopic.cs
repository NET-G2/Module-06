﻿namespace Lesson05.Models
{
    public class ModuleTopic
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public int ModuleId { get; set; }
        public Module Module { get; set; }
    }
}
