using Microsoft.EntityFrameworkCore;
using fc_test_task.Data;
using fc_test_task.Interfaces.Reposiroties;
using fc_test_task.Repositories;
using fc_test_task.Interfaces.Helpers;
using fc_test_task.Helpers;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("ApplicationDbConnection") ?? throw new InvalidOperationException("Connection string not found.");

builder.Services.AddControllers();
builder.Services.AddDbContext<ApplicationContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddAutoMapper(typeof(AppMappingProfile));

builder.Services.AddScoped<IUsersRepository, UsersRepository>();
builder.Services.AddScoped<IUserHelper, UserHelper>();

builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
