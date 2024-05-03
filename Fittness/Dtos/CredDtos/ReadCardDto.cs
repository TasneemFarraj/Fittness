
namespace Fittness.Dtos.CredDtos;

public class ReadCardDto
{
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
public class ReadPalateIngredientDto
{
    public int Id { get; set; }
    public string item_1 { get; set; }
    public string item_2 { get; set; }
    public string item_3 { get; set; }
    public string item_4 { get; set; }
    public string item_5 { get; set; }
    public string item_6 { get; set; }
    public string item_7 { get; set; }
}

