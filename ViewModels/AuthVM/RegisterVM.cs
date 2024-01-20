using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace MVC5.ViewModels.AuthVM
{
    public class RegisterVM
    {
        [Required, MaxLength(15), MinLength(3)]
        public string Name { get; set; }
        [Required, MaxLength(25), MinLength(3)]
      
        public string Surname { get; set; }
        [Required, MaxLength(25), MinLength(3)]
        public string Username { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password),MinLength(8),NotNull]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "Password and confirmation password not match.")]
        public string ConfirmPassword { get; set; }
    }
}
