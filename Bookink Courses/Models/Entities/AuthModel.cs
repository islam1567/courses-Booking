namespace Bookink_Courses.Models.Entities
{
    public class AuthModel
    {
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Message { get; set; }
        public string Token { get; set; }
        public bool IsAuthantication { get; set; }
        public DateTime ExpireOn { get; set; }
    }
}
