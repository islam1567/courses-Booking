using Microsoft.AspNetCore.Identity;

namespace Bookink_Courses.Models.Context
{
    public class ApplicationUser : IdentityUser
    {
        public string Address { get; set; }
    }
}
