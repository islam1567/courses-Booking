using System.ComponentModel.DataAnnotations.Schema;

namespace Bookink_Courses.Models.DTOs
{
    public class LessonDto
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public int Order_No { get; set; }
        public int Course_Id { get; set; }
    }
}
