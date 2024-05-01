using Fittness.Data.Models;

namespace Fittness.Repository.IRepo;
public interface ICardRepository
{
    Task<Card> GetAsync(int Id);
    Task<List<Card>> GetListAsync();
    Task AddCard(Card card);
    Task UpdateCard(Card card);
    Task DeleteCard(int Id);
}
