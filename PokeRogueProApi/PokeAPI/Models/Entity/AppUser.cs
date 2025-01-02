using Microsoft.AspNetCore.Identity;

namespace PokeAPI.Models.Entity
{
    public class AppUser : IdentityUser
    {
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
