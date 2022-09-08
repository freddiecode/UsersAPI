using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;
using RequiredAttribute = System.ComponentModel.DataAnnotations.RequiredAttribute;

namespace UsersAPI.Models
{
    public class User
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required(AllowEmptyStrings = false, ErrorMessage = "The email address can not be empty")]
        public string Email { get; set; } = String.Empty;

        [Required(AllowEmptyStrings = false, ErrorMessage = "The password can not be empty")]
        public string Password { get; set; } = String.Empty;

        public DateTime DateTime { get; set; } = DateTime.Now; 
 
    }
}
