using Fittness.Repository.IRepo;
using Fittness.Repository.Repo;

namespace Fittness.UnitOfWork;
public interface IUOW
{ 
    public IUserRepository User { get; set; }
    public ICardRepository Card { get; set; }
    public IPalateIngredientRepository PalateIngredient { get; set; }
   
    public IPalate1Repository Palate1 { get; set; }


}
