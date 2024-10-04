using fc_test_task.Queries.User;

namespace fc_test_task.Interfaces.Reposiroties;

public interface IUsersRepository
{
    Task<User?> AddAsync(User user);
    Task<IEnumerable<User>?> GetAllAsync(UserFindQuery query);
    Task<User?> GetByIdAsync(int id);
}