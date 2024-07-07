using AutoMapper;
using Backend_almog.DTO;
using Backend_almog.Helpers;
using Backend_almog.Models;
using Microsoft.AspNetCore.Identity;


namespace Backend_almog.Services.AuthSer
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<User> _userManager;
        private readonly JwtHandler _jwtHandler;

        public AuthService(UserManager<User> userManager, JwtHandler jwtHandler)
        {
            _userManager = userManager;
            _jwtHandler = jwtHandler;
            
        }

        public async Task<UserProfileDTO> GetUserProfile(string username)
        {
            var user = await _userManager.FindByNameAsync(username);
            if (user == null) return null;

            return new UserProfileDTO
            {
                UserName = user.UserName,
                Email = user.Email,
                FirstName = user.Firstname,
                LastName = user.Lastname,
            };
        }

        public async Task<string?> LoginAsync(LoginDTO loginDTO)
        {
            var user = await _userManager.FindByNameAsync(loginDTO.UserName);
            if(user != null && await _userManager.CheckPasswordAsync(user, loginDTO.Password))
            {
                return _jwtHandler.GenerateJwtToken(user!);
            }
            return null;
        }

        public async Task<string?> RegisterAsync(RegisterDTO registerDTO)
        {
            if (registerDTO.Password != registerDTO.ConfirmedPassword) return null;
            var user = new User
            {
                UserName = registerDTO.UserName,
                Email = registerDTO.Email,
                Firstname = registerDTO.FirstName,
                Lastname = registerDTO.LastName,
            };
            var result = await _userManager.CreateAsync(user,registerDTO.Password);
            if (result.Succeeded)
            {
                return _jwtHandler.GenerateJwtToken(user);
            }

            return null;
        }
    }
}
