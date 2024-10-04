namespace fc_test_task.Data.Enums;

public record Devices
{
    public const string MAIL = "mail";
    public const string MOBILE = "mobile";
    public const string WEB = "web";

    public static readonly List<string> ListAll = [
        MAIL,
        MOBILE,
        WEB
    ];

    public static bool Contains(string? value)
    {
        if (value == MAIL) return true;
        if (value == MOBILE) return true;
        if (value == WEB) return true;
        return false;
    }
};
