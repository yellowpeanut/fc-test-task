using Microsoft.EntityFrameworkCore;

namespace fc_test_task.Data;

public class ApplicationContext : DbContext
{
    public ApplicationContext(DbContextOptions<ApplicationContext> options)
        : base(options)
    {
        Database.EnsureCreated();
    }

    public virtual DbSet<User> Users { get; set; }
}
