using FcTestTask;
using FcTestTask.Data.Enums;
using FcTestTask.Application.Interfaces.Repositories;
using FcTestTask.Domain.Users.Entities;
using FcTestTask.Tests.InitialData.User;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Http.Json;

namespace FcTestTask.Tests.Controllers;

public class UsersControllerTests
{
    private FcTestTaskWebApplicationFactory _factory;
    private HttpClient _client;
    private IEnumerable<User> _initUsers;
    private readonly string route;
    public UsersControllerTests()
    {
        _initUsers = InitialUsers.GetList();
        route = "/api/Users/";
    }
    [SetUp]
    public void Setup()
    {
        _factory = new FcTestTaskWebApplicationFactory();
        _client = _factory.CreateClient();
    }
    [TearDown]
    public void TearDown()
    {
        _client.Dispose();
        _factory.Dispose();
    }

    [Test]
    public async Task GetTest()
    {
        using (var scope = _factory.Services.CreateScope())
        {
            var usersRepository = scope.ServiceProvider.GetRequiredService<IUsersRepository>();
            var user = _initUsers.First();
            user.Id = default;
            user = await usersRepository.AddAsync(user);
            Assert.NotNull(user);

            var response = await _client.GetAsync(route + $"{user.Id}");
            response.EnsureSuccessStatusCode();

            var resData = await response.Content.ReadFromJsonAsync<User>();

            Assert.IsNotNull(resData);
            UsersEqual(resData, user);
        }

    }

    [Test]
    public async Task GetAllTest()
    {
        using (var scope = _factory.Services.CreateScope())
        {
            var usersRepository = scope.ServiceProvider.GetRequiredService<IUsersRepository>();
            var userList = new List<User?>();
            foreach (var u in _initUsers)
            {
                u.Id = default;
                userList.Add(await usersRepository.AddAsync(u));
            }
            CollectionAssert.AllItemsAreNotNull(userList);

            var response = await _client.GetAsync(route);
            response.EnsureSuccessStatusCode();

            var resData = await response.Content.ReadFromJsonAsync<List<User>>();

            Assert.IsNotNull(resData);
            CollectionAssert.AllItemsAreNotNull(resData);
            CollectionAssert.AllItemsAreUnique(resData);
            CollectionAssert.AreEqual(resData, userList);
        }

    }

    [Test]
    public async Task CreateTest()
    {
        var user = _initUsers.First();

        Assert.Multiple(async () =>
        {
            foreach (var device in Devices.ListAll)
            {
                _client.DefaultRequestHeaders.Add("x-Device", device);

                var response = await _client.PostAsJsonAsync(route, user);
                response.EnsureSuccessStatusCode();

                var resData = await response.Content.ReadFromJsonAsync<User>();

                Assert.IsNotNull(resData);
                Assert.Positive(resData!.Id);
                user.Id = resData!.Id;
                UsersEqual(resData, user);
            }
        });

    }

    private void UsersEqual(User user1, User user2)
    {
        Assert.Multiple(() =>
        {
            Assert.That(user1.Id, Is.EqualTo(user2.Id));
            Assert.That(user1.LastName, Is.EqualTo(user2.LastName));
            Assert.That(user1.FirstName, Is.EqualTo(user2.FirstName));
            Assert.That(user1.MiddleName, Is.EqualTo(user2.MiddleName));
            Assert.That(user1.Birthday, Is.EqualTo(user2.Birthday));
            Assert.That(user1.Passport, Is.EqualTo(user2.Passport));
            Assert.That(user1.BirthAddress, Is.EqualTo(user2.BirthAddress));
            Assert.That(user1.PhoneNumber, Is.EqualTo(user2.PhoneNumber));
            Assert.That(user1.Email, Is.EqualTo(user2.Email));
            Assert.That(user1.RegistrationAddress, Is.EqualTo(user2.RegistrationAddress));
            Assert.That(user1.ResidentialAddress, Is.EqualTo(user2.ResidentialAddress));
        });

    }
}
