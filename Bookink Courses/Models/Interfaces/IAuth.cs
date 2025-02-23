using Bookink_Courses.Models.DTOs;
using Bookink_Courses.Models.Entities;

namespace Bookink_Courses.Models.Interfaces
{
    public interface IAuth
    {
        public Task<AuthModel> RegisterAsync(RegisterDto registerDto);
        public Task<AuthModel> LoginAsync(LoginDto LoginDto);
    }
}
