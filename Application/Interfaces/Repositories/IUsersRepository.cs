using FcTestTask.Domain.Users.Entities;
using FcTestTask.Application.DTO.User.Requests;

namespace FcTestTask.Application.Interfaces.Repositories;

public interface IUsersRepository
{
    Task<User?> AddAsync(User user);
    Task<IEnumerable<User>?> GetAllAsync(UserFindRequest query);
    Task<User?> GetByIdAsync(int id);
}