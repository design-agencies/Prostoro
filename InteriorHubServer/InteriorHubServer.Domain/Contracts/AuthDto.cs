using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteriorHubServer.Domain.Contracts
{
    public class LoginModel
    {
        [Required(ErrorMessage = "User Name is required")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string? Password { get; set; }
    }
    public class RegisterModel
    {
        //[Required(ErrorMessage = "User Name is required")]
        public string? Username { get; set; }

        [EmailAddress]
        [Required(ErrorMessage = "Email is required")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string? Password { get; set; }

        [Required(ErrorMessage = "Role is required")]
        public string? Role { get; set; }
    }
    public class RegisterResponse
    {
        public string? Status { get; set; }
        public string? Message { get; set; }
    }
    public class LoginResponse
    {
        public string? Token { get; set; }
        public DateTime? ExpirationDate { get; set; }
    }
}
