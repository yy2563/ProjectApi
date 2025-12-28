using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace project.Customer.Dto
{
    public class UserDto
    {
        public class registerDto
        {
            [MaxLength(50),Required]
            public string? Name { get; set; }
            [EmailAddress]
            public string? Email { get; set; }
            [MaxLength(50),Required]
            public string? UserName { get; set; }
            [PasswordPropertyText,Required]
            public string? Password { get; set; }
            [MaxLength(10),Required]
            public string? Phone { get; set; }
            public DateTime? CreatedAt { get; set; }
            //public string? Role { get; set; }

        }
        public class loginDto
        {
            [MaxLength(50), Required]

            public string? UserName { get; set; }
            [PasswordPropertyText, Required]
            public string? Password { get; set; } 
        }
        public class getUserDto
        {
            public string? Name { get; set; }
            public string? Email { get; set; }
            public string? UserName { get; set; }
            public string? Phone { get; set; }
        }
    }
}
