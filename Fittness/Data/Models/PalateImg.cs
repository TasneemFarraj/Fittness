using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations;

namespace Fittness.Data.Models
{
    public class PalateImg
    {

    [Key] 
    public int Id { get; set; }
    public byte[]? Image { get; set; }
    }
}
