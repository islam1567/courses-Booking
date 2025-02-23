namespace Bookink_Courses.Models.Entities
{
    public class Catagory
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public ICollection<Courses> Courses { get; set; }
    }
}
