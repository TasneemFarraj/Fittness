using System.ComponentModel.DataAnnotations;

namespace Fittness.Models
{
    public class mdlCrafts
    {
        [MaxLength(50)]
        public string Name { get; set; }

        public IFormFile Image { get; set; }

    }
}
