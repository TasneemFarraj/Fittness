using Fittness.Data;
using Fittness.Data.Models;
using Fittness.Repository.IRepo;
using Microsoft.EntityFrameworkCore;

namespace Fittness.Repository.Repo;

public class CardRepository : ICardRepository
{
    private readonly AppDBContext _db;

    public CardRepository(AppDBContext db)
    {
        _db = db;
    }
    public async Task AddCard(Card card)
    {
        await _db.Cards.AddAsync(card);
        await _db.SaveChangesAsync();

    }

    public async Task DeleteCard(int Id)
    {
        var data = await _db.Cards.FindAsync(Id);
        if (data != null)
        {
            _db.Cards.Remove(data);
            await _db.SaveChangesAsync();
        }
    }

    public async Task<Card> GetAsync(int Id)
    {
        var data = await _db.Cards.FindAsync(Id);
        return data;
    }

    public async Task<List<Card>> GetListAsync()
    {
        var data = await _db.Cards.ToListAsync();
        return data;
    }

    public async Task UpdateCard(Card card)
    {
        var data = await _db.Cards.FindAsync(card.Id);
        if (data != null)
        {
            data.Id = card.Id;
            data.Name = card.Name;
            data.Specialty = card.Specialty;
            data.Phone = card.Phone;
            data.Addrres = card.Addrres;
            data.Email = card.Email;
            data.WorkingDay = card.WorkingDay;
            data.Rating = card.Rating;
            data.Img = card.Img;
           _db.Cards.Update(data);
           _db.SaveChanges();
        }
    }
}

