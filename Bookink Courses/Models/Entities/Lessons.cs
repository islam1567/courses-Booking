using System.ComponentModel.DataAnnotations.Schema;

namespace Bookink_Courses.Models.Entities
{
    public class Lessons
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public int Order_No { get; set; }
        [ForeignKey("Courses")]
        public int Course_Id { get; set; }
        public Courses Courses { get; set; }
    }
}
