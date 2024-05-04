using Fittness.Data;
using Fittness.Data.Models;
using Fittness.Repository.IRepo;
using Microsoft.EntityFrameworkCore;

namespace Fittness.Repository.Repo;

    public class Palate1Repository : IPalate1Repository
    {
        private readonly AppDBContext _db;

        public Palate1Repository(AppDBContext db)
        {
            _db = db;
        }
        public async Task AddPalate1(Palate1 palate1)
        {
            await _db.Palates1.AddAsync(palate1);
            await _db.SaveChangesAsync();

        }

        public async Task DeletePalate1(int Id)
        {
            var data = await _db.Palates1.FindAsync(Id);
            if (data != null)
            {
                _db.Palates1.Remove(data);
                await _db.SaveChangesAsync();
            }
        }

        public async Task<Palate1> GetAsync(int Id)
        {
            var data = await _db.Palates1.FindAsync(Id);
            return data;
        }

        public async Task<List<Palate1>> GetListAsync()
        {
            var data = await _db.Palates1.ToListAsync();
            return data;
        }

        public async Task UpdatePalate1(Palate1 palate1)
        {

            var data = await _db.Palates1.FindAsync(palate1.Id);
            if (data != null)
            {
                data.Id = palate1.Id;
                data.Name = palate1.Name;
                data.Img = palate1.Img;
                _db.Palates1.Update(data);
                _db.SaveChanges();
            }
        }
    }

