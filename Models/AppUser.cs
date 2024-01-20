using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace MVC5.Models
{
    public class AppUser : IdentityUser
    {
        [Required, MaxLength(15), MinLength(3)]
        public string Name { get; set; }
        [Required, MaxLength(25), MinLength(3)]
        public string Surname { get; set; }
    }
}
