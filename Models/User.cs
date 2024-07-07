using Microsoft.AspNetCore.Identity;

namespace Backend_almog.Models
{
    public class User : IdentityUser
    {
        public string Firstname { get; set; } = string.Empty;
        public string Lastname { get; set; } = string.Empty;
    }
}
