using Fittness.Data.Models;
using Fittness.Repository.IRepo;
using Fittness.Repository.Repo;

namespace Fittness.UnitOfWork;
public class UOW : IUOW
{
    public UOW(ICardRepository card, IPalateIngredientRepository ingredient)
    {

        Card = card;
        PalateIngredient = ingredient;

    }
    public ICardRepository Card { get; set; }
    public IPalateIngredientRepository PalateIngredient { get ; set; }
}

