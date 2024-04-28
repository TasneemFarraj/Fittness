using System.ComponentModel.DataAnnotations;

namespace Fittness.Data.Models
{
    public class PalateNutrition
    {
        [Key]
        public int Id { get; set; } 
        public string Fats { get; set; }
        public string protein { get; set;}
        public string carbohydrates { get; set; }
        public string calories { get; set; }


    }
}
