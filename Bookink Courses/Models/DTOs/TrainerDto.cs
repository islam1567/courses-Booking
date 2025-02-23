namespace Bookink_Courses.Models.DTOs
{
    public class TrainerDto
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime Create_Date { get; set; }
        public string Phone { get; set; }
        public string Description { get; set; }
        public bool Is_Active { get; set; }
    }
}
