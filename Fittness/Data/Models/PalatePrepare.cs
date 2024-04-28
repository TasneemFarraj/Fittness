using System.ComponentModel.DataAnnotations;

namespace Fittness.Data.Models
{
    public class PalatePrepare
    {
        [Key]
        public int Id { get; set; }
        public string step_1 { get; set; }
        public string step_2 { get; set; }
        public string step_3 { get; set; }
        public string step_4 { get; set; }
        public string step_5 { get; set; }
        public string step_6 { get; set; }
        public string step_7 { get; set; }
       
    }
}
