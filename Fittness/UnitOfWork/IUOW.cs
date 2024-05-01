using Fittness.Repository.IRepo;

namespace Fittness.UnitOfWork;
public interface IUOW
{
    public ICardRepository Card { get; set; }
}
