using System.ComponentModel.DataAnnotations;

namespace Fittness.Data.Models
{
    public class Frequently_question
    {
        [Key]
        public int Id { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }
    }
}
