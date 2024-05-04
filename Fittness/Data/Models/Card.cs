using System.ComponentModel.DataAnnotations;

namespace Fittness.Data.Models
{
    public class Card
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Specialty { get; set; }
        public string Phone { get; set; }
        public string Addrres { get; set; }
        public string Email { get; set; }
        public string WorkingDay { get; set; }
        public string Rating { get; set; }
        public string Img { get; set; }

        internal int Count()
        {
            throw new NotImplementedException();
        }
    }
}

