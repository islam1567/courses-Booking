using Bookink_Courses.Models.Context;
using Bookink_Courses.Models.DTOs;
using Bookink_Courses.Models.Entities;
using Bookink_Courses.Models.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Bookink_Courses.Models.Services
{
    public class AuthService : IAuth
    {
        private readonly UserManager<ApplicationUser> manager;

        public AuthService(UserManager<ApplicationUser> manager)
        {
            this.manager = manager;
        }

        public async Task<AuthModel> LoginAsync(LoginDto LoginDto)
        {
            var user = await manager.FindByEmailAsync(LoginDto.Email);
            if (user is null || !await manager.CheckPasswordAsync(user, LoginDto.Password))
                return new AuthModel { Message = "Email Or Password Incorrecy" };

            var jwtsecuritytoken = await CreateToken(user);
            return new AuthModel
            {
                Email = user.Email,
                UserName = user.UserName,
                IsAuthantication = true,
                Token = new JwtSecurityTokenHandler().WriteToken(jwtsecuritytoken),
                ExpireOn = jwtsecuritytoken.ValidTo
            };
        }

        public async Task<AuthModel> RegisterAsync(RegisterDto registerDto)
        {
            if (await manager.FindByEmailAsync(registerDto.Email) is not null)
                return new AuthModel { Message = "Email Alraedy Exist" };
            if (await manager.FindByNameAsync(registerDto.UserName) is not null)
                return new AuthModel { Message = "UserName Alraedy Exist" };

            var user = new ApplicationUser
            {
                UserName = registerDto.UserName,
                Email = registerDto.Email,
                Address = registerDto.Address,
                PasswordHash = registerDto.Password
            };
            var result = await manager.CreateAsync(user, registerDto.Password);
            if (!result.Succeeded)
                return new AuthModel { Message = "Something Is Wronge" };

            var jwtsecuritykoken = await CreateToken(user);
            return new AuthModel
            {
                Email = user.Email,
                UserName = user.UserName,
                IsAuthantication = true,
                Token = new JwtSecurityTokenHandler().WriteToken(jwtsecuritykoken),
                ExpireOn = jwtsecuritykoken.ValidTo
            };
        }

        private async Task<JwtSecurityToken> CreateToken(ApplicationUser user)
        {
            var claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Name, user.UserName));
            claims.Add(new Claim(ClaimTypes.NameIdentifier, user.Id));
            claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));

            var roles = await manager.GetRolesAsync(user);
            foreach (var role in roles)
                claims.Add(new Claim(ClaimTypes.Role, role));

            var securitykey = new SymmetricSecurityKey
                (Encoding.UTF8.GetBytes
                ("GFFKHHgsgdfgdeggyu67YFDSSDGJhhhdjshfjkdkjvbioUdmfslkfjdlkfnsLKJKJHGgbcvfjhdsfbhjdgeubcjbdjksjkj0059nfdsnfkk"));

            var signincred = new SigningCredentials
                (securitykey, SecurityAlgorithms.HmacSha256);

            var jwt = new JwtSecurityToken(
                issuer: "",
                audience: "",
                expires: DateTime.Now.AddHours(1),
                claims : claims,
                signingCredentials : signincred 
                );
            return jwt;
        }
    }
}
