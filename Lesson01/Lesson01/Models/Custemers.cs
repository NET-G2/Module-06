namespace Lesson01.Models
{
    public class Custemers
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int PhoneNumber { get; set; }
        List<Product> Products { get; set; }
            
    }
}
