using SauceDemoLoginAutomation.Models;
using Xunit;

namespace SauceDemoLoginAutomation.Utilities
{
    public static class LoginDataProvider
    {
        public static TheoryData<UserCredentials, string> LoginTestData => new()
        {
            { new UserCredentials { Username = "", Password = "" }, "Username is required" },
            { new UserCredentials { Username = "standard_user", Password = "" }, "Password is required" },
            { new UserCredentials { Username = "standard_user", Password = "secret_sauce" }, "Swag Labs" }
        };
    }
}
