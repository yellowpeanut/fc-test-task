using Microsoft.EntityFrameworkCore;
using FcTestTask.Data;
using FcTestTask.Application.Interfaces.Helpers;
using FcTestTask.Application.Interfaces.Repositories;
using FcTestTask.Data.Repositories;
using FcTestTask.Data.Helpers;
using FcTestTask.Application.Mappers;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("ApplicationDbConnection") ?? throw new InvalidOperationException("Connection string not found.");

builder.Services.AddControllers();
builder.Services.AddDbContext<ApplicationContext>(options =>
    {
        if (!builder.Environment.IsDevelopment())
        {
            var user = Environment.GetEnvironmentVariable("MSSQL_SA_USER");
            var password = Environment.GetEnvironmentVariable("MSSQL_SA_PASSWORD");
            connectionString = string.Format(connectionString, user, password);
        }
        options.UseSqlServer(connectionString);
    });
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
