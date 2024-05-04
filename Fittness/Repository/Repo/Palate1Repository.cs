using Fittness.Data;
using Fittness.Data.Models;
using Fittness.Repository.IRepo;

namespace Fittness.Repository.Repo
{
    public class Palate1Repository : IPalate1Repository
    {
        private readonly AppDBContext _db;

        public Palate1Repository(AppDBContext db)
        {
            _db = db;
        }
        public async Task AddPalate1(Palate1 palate1)
        {
            throw new NotImplementedException();
        }

        public Task DeletePalate1(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<Palate1> GetAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Palate1>> GetListAsync()
        {
            throw new NotImplementedException();
        }

        public Task UpdatePalate1(Palate1 palate1)
        {
            throw new NotImplementedException();
        }
    }
}
