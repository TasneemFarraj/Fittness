using Fittness.Data;
using Fittness.Data.Models;
using Fittness.Repository.IRepo;
using Microsoft.EntityFrameworkCore;

namespace Fittness.Repository.Repo
{
    public class PalateIngredientRepository : IPalateIngredientRepository
    {

        private readonly AppDBContext _db;

        public PalateIngredientRepository(AppDBContext db)
        {
            _db = db;
        }
        public async Task AddPalateIngredient(PalateIngredient ingredient)
        {
            await _db.PalateIngredients.AddAsync(ingredient);
            await _db.SaveChangesAsync();
        }

        public async Task DeletePalateIngredient(int Id)
        {
            var data = await _db.PalateIngredients.FindAsync(Id);
            if (data != null)
            {
                _db.PalateIngredients.Remove(data);
                await _db.SaveChangesAsync();
            }
        }

        public async Task<PalateIngredient> GetAsync(int Id)
        {
            var data = await _db.PalateIngredients.FindAsync(Id);
            return data;
        }

        public async Task<List<PalateIngredient>> GetListAsync()
        {
            throw new NotImplementedException();
        }

        public async Task UpdatePalateIngredient(PalateIngredient ingredient)
        {
            var data = await _db.PalateIngredients.FindAsync(ingredient.Id);
            if (data != null)
            {
                data.Id = ingredient.Id;
                data.item_1 = ingredient.item_1;
                data.item_2 = ingredient.item_2;
                data.item_3 = ingredient.item_3;
                data.item_4 = ingredient.item_4;
                data.item_5 = ingredient.item_5;
                data.item_6 = ingredient.item_6;
                data.item_7 = ingredient.item_7;

                _db.PalateIngredients.Update(data);
                _db.SaveChanges();
            }
        }
    }
}
