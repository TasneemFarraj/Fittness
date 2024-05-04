using Fittness.Data;
using Fittness.Data.Models;
using Fittness.Repository.IRepo;
using Microsoft.EntityFrameworkCore;

namespace Fittness.Repository.Repo;

public class UserRepository : IUserRepository
{
    private readonly AppDBContext _db;

    public UserRepository(AppDBContext db)
    {
        _db = db;
    }

    public async Task AddUser(User user)
    {
        await _db.User.AddAsync(user);
        await _db.SaveChangesAsync();
    }

    public async Task DeleteUser(int Id)
    {
        var data = await _db.User.FindAsync(Id);
        if (data != null)
        {
            _db.User.Remove(data);
            await _db.SaveChangesAsync();
        }
    }

    public async Task<User> GetAsync(int Id)
    {
        var data = await _db.User.FindAsync(Id);
        return data;
    }

    public async Task<List<User>> GetListAsync()
    {
        var data = await _db.User.ToListAsync();
        return data;
    }

    public async Task<User> LoginUser(User user)
    {
        var data = _db.User.ToList().Where(x=>x.Password==user.Password &&x.UserName==user.UserName).SingleOrDefault();
        return data;
    }

    public async Task UpdateUser(User user)
    {
        var data = await _db.User.FindAsync(user.Id);
        if (data != null)
        {
            data.Id = user.Id;
            data.UserName = user.UserName;
            data.UserType = user.UserType;
            data.Password = user.Password;
            data.PasswordConfirm = user.PasswordConfirm;
           
            _db.User.Update(data);
            _db.SaveChanges();
        }
    }
}

