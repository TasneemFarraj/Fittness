using Fittness.Repository.IRepo;

namespace Fittness.UnitOfWork;
public interface IUOW
{
    public ICardRepository Card { get; set; }
    public IPalateIngredientRepository PalateIngredient { get; set; }
    public IUserRepository User { get; set; }

}
 