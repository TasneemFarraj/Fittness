using System.ComponentModel.DataAnnotations;

namespace Fittness.Data.Models
{
    public class Palate1
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(50)]
        public string Name { get; set; }
        public byte []? Image { get; set; }

    }
}
