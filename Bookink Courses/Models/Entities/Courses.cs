using System.ComponentModel.DataAnnotations.Schema;

namespace Bookink_Courses.Models.Entities
{
    public class Courses
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime Create_Date { get; set; }
        public string Description { get; set; }
        [ForeignKey("Catagory")]
        public int Catagory_Id { get; set; }
        [ForeignKey("Trainer")]
        public int Trainer_Id { get; set; }
        public Catagory Catagory { get; set; }
        public Trainers Trainer { get; set; }
        public ICollection<Lessons> Lessons { get; set; }
        public ICollection<Course_Trainer> course_Trainers { get; set; }
    }
}
