using System.ComponentModel.DataAnnotations;

namespace Backend_almog.DTO
{
    public class LoginDTO
    {
        [Required(ErrorMessage = "User Name Required")]
        public string UserName { get; set; } = string.Empty;
        [Required(ErrorMessage = "Password Required")]
        public string Password { get; set; } = string.Empty;
    }
}
