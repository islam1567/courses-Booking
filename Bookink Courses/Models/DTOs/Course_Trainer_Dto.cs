using System.ComponentModel.DataAnnotations.Schema;

namespace Bookink_Courses.Models.DTOs
{
    public class Course_Trainer_Dto
    {
        public int Course_Id { get; set; }
        public int Trainer_Id { get; set; }
    }
}
