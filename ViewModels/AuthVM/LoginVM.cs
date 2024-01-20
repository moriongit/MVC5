using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace MVC5.ViewModels.AuthVM
{
    public class LoginVM
    {
        public string UsernameOrEmail { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
      
    }
}
