using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuiteRx.Interface.Application.Dto
{
    public class RegistrationDto
    {
        public int Id { get; set; }

        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Full Name is required.")]
        public string FullName { get; set; }

        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Email is required.")]
        [System.ComponentModel.DataAnnotations.EmailAddress(ErrorMessage = "Invalid Email Address.")]
        public string Email { get; set; }

        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Password is required.")]
        [System.ComponentModel.DataAnnotations.MinLength(6, ErrorMessage = "Password must be at least 6 characters long.")]
        public string PasswordHash { get; set; }

        public string PhoneNumber { get; set; }

        public string Role { get; set; }

        public bool IsActive { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
