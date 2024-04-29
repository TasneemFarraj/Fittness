using System.ComponentModel.DataAnnotations;

namespace Fittness.Data.Models
{
    public class Home
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
