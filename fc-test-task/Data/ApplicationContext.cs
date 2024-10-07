using FcTestTask.Data.Configurations;
using FcTestTask.Domain.Users.Entities;
using Microsoft.EntityFrameworkCore;

namespace FcTestTask.Data;

public class ApplicationContext : DbContext
{
    public ApplicationContext(DbContextOptions<ApplicationContext> options)
        : base(options)
    {
        Database.EnsureCreated();
    }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // modelBuilder.ApplyConfiguration<User>(new UserConfiguration());
    }
}
