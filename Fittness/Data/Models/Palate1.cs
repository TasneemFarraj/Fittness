using System.ComponentModel.DataAnnotations;

namespace Fittness.Data.Models
{
    public class Palate1
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Img { get; set; }

    }
}
