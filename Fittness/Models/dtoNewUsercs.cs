using System.ComponentModel.DataAnnotations;

namespace Fittness.Models
{
    public class dtoNewUsercs
    {
  
            [Key]
            public int Id { get; set; }
            [Required]
            public string UserName { get; set; }
            [Required]
            public string Email { get; set; }
            [Required]
            public string Password { get; set; }
            [Required]
            public string conpassword { get; set; }
        }
    }
