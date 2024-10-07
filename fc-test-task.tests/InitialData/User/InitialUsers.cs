using System.Text.Json;

namespace FcTestTask.Tests.InitialData.User;

public class InitialUsers
{
    public static IEnumerable<Domain.Users.Entities.User> GetList()
    {
        var json = File.ReadAllText(Environment.CurrentDirectory + "../../../../" + 
            "./InitialData/User/users.json");
        var data = JsonSerializer.Deserialize<List<Domain.Users.Entities.User>>(json);
        if(data == null)
        {
            throw new Exception("File users.json is not valid");
        }

        return data;
    }
}
