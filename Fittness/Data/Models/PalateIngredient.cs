using System.ComponentModel.DataAnnotations;

namespace Fittness.Data.Models
{
    public class PalateIngredient
    {
      
            [Key]
          public int Id { get; set; }
          public string item_1 { get; set; }
          public string item_2 { get; set; }
          public string item_3 { get; set; }
          public string item_4 { get; set; }
          public string item_5 { get; set; }
          public string item_6 { get; set; }
          public string item_7 { get; set; }

    }
}
