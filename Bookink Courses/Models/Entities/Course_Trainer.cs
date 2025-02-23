using System.ComponentModel.DataAnnotations.Schema;

namespace Bookink_Courses.Models.Entities
{
    public class Course_Trainer
    {
        [ForeignKey("Courses")]
        public int Course_Id { get; set; }
        [ForeignKey("Trainer")]
        public int Trainer_Id { get; set; }
        public Courses Courses { get; set; }
        public Trainers Trainer { get; set; }
        public DateTime Date { get; set; }
    }
}
