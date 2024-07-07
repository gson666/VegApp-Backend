using System.ComponentModel.DataAnnotations;

namespace Backend_almog.DTO
{
    public class RegisterDTO
    {
        public required string FirstName { get; set; } = string.Empty;

        public required string LastName { get; set; } = string.Empty;

        public required string UserName { get; set; } = string.Empty;

        public required string Password { get; set; } = string.Empty;

        public required string ConfirmedPassword { get; set; } = string.Empty;
        [EmailAddress]
        public required string Email { get; set; } = string.Empty;
    }
}
