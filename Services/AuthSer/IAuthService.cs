using Backend_almog.DTO;

namespace Backend_almog.Services.AuthSer
{
    public interface IAuthService
    {
        Task<string?> RegisterAsync(RegisterDTO registerDTO);
        Task<string?> LoginAsync(LoginDTO loginDTO);
        Task<UserProfileDTO> GetUserProfile(string username);
    }
}
