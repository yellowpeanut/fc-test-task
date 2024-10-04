using System.Text.Json;

namespace FcTestTask.Tests.InitialData.User;

public class InitialUsers
{
    public static IEnumerable<fc_test_task.User> GetList()
    {
        var json = File.ReadAllText(Environment.CurrentDirectory + "../../../../" + 
            "./InitialData/User/users.json");
        var data = JsonSerializer.Deserialize<List<fc_test_task.User>>(json);
        if(data == null)
        {
            throw new Exception("File users.json is not valid");
        }

        return data;
    }
}
