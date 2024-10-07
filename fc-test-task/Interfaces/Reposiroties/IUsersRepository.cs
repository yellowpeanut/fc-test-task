using FcTestTask.Application.DTO.User.Requests;
using FcTestTask.Domain.Users.Entities;

namespace FcTestTask.Interfaces.Reposiroties;

public interface IUsersRepository
{
    Task<User?> AddAsync(User user);
    Task<IEnumerable<User>?> GetAllAsync(UserFindRequest query);
    Task<User?> GetByIdAsync(int id);
    Task<bool> Exists(User user);
}