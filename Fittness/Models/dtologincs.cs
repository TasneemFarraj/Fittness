using System.ComponentModel.DataAnnotations;

namespace Fittness.Models
{
    
        public class dtologin
        {
            [Required]
            public string userName { get; set; }
            [Required]
            public string Password { get; set; }
        }
    }


