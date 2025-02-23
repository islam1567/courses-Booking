namespace Bookink_Courses.Models.DTOs
{
    public class CourseDto
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime Create_Date { get; set; }
        public string Description { get; set; }
        public int Catagory_Id { get; set; }
        public int Trainer_Id { get; set; }
    }
}
