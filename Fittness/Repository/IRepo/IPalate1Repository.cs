using Fittness.Data.Models;

namespace Fittness.Repository.IRepo
{
    public interface IPalate1Repository
    {

        Task<Palate1> GetAsync(int Id);
        Task<List<Palate1>> GetListAsync();
        Task AddPalate1(Palate1 palate1);
        Task UpdatePalate1(Palate1 palate1);
        Task DeletePalate1(int Id);
    }
}

