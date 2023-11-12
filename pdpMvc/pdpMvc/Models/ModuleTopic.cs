namespace pdpMvc.Models
{
    public class ModuleTopic
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Descrtiption { get; set; }

        public int ModuleId { get; set; }
        public Module Module { get; set; }
    }
}
