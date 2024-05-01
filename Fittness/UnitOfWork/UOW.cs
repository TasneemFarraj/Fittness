using Fittness.Repository.IRepo;

namespace Fittness.UnitOfWork;
public class UOW : IUOW
{
    public UOW(ICardRepository card)
    {

        Card = card;

    }
    public ICardRepository Card { get; set; }

}

