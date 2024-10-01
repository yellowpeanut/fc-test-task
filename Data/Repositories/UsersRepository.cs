using FcTestTask.Application.DTO.User.Requests;
using FcTestTask.Application.Interfaces.Repositories;
using FcTestTask.Domain.Users.Entities;
using Microsoft.EntityFrameworkCore;

namespace FcTestTask.Data.Repositories;

public class UsersRepository : IUsersRepository
{
    private readonly ApplicationContext _context;

    public UsersRepository(ApplicationContext context)
    {
        _context = context;
    }
    public async Task<User?> AddAsync(User user)
    {
        var check = await _context.Users.Where(e => e.Email == user.Email).FirstOrDefaultAsync();
        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();
        return user;
    }

    public async Task<User?> GetByIdAsync(int id)
    {
        var res = await _context.Users.Where(e => e.Id == id).FirstOrDefaultAsync();
        return res;
    }
    public async Task<IEnumerable<User>?> GetAllAsync(UserFindRequest query)
    {
        var data = _context.Users.AsQueryable();

        if (!string.IsNullOrEmpty(query.LastName))
        {
            data.Where(e => e.LastName == query.LastName);
        }
        if (!string.IsNullOrEmpty(query.FirstName))
        {
            data.Where(e => e.FirstName == query.FirstName);
        }
        if (!string.IsNullOrEmpty(query.MiddleName))
        {
            data.Where(e => e.MiddleName == query.MiddleName);
        }
        if (!string.IsNullOrEmpty(query.PhoneNumber))
        {
            data.Where(e => e.PhoneNumber == query.PhoneNumber);
        }
        if (!string.IsNullOrEmpty(query.Email))
        {
            data.Where(e => e.Email == query.Email);
        }

        return await data.ToListAsync();
    }


}
