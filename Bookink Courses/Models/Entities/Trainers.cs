namespace Bookink_Courses.Models.Entities
{
    public class Trainers
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime Create_Date { get; set; }
        public string Phone { get; set; }
        public string Description { get; set; }
        public bool Is_Active { get; set; }
        public ICollection<Courses> Courses { get; set; }
        public ICollection<Course_Trainer> course_Trainers { get; set; }
    }
}
