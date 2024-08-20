using OpenQA.Selenium;
using SauceDemoLoginAutomation.Drivers;
using SauceDemoLoginAutomation.Models;
using SauceDemoLoginAutomation.Utilities;
using SauceDemoLoginAutomation.PageObjects;
using Xunit;
using FluentAssertions;

namespace SauceDemoLoginAutomation.Tests
{
    [Collection("LoginTestCollection2")]
    public class LoginTestsWithValidCredentials : IDisposable
    {
        private readonly IWebDriver _driver;
        private readonly LoginPageObject _loginPage;

        public LoginTestsWithValidCredentials()
        {
            _driver = DriverFactory.GetDriver("edge");
            _loginPage = new LoginPageObject(_driver);
            _loginPage.OpenLoginPage();
            LoggerUtility.Log("Login page is opened.");
        }

        [Theory]
        [InlineData("standard_user", "secret_sauce", "Swag Labs")]
        public void TestLoginForm_AcceptedCredentials_DashboardContainsSwagLabs(string username, string password, string expectedMessage)
        {
            try
            {
                LoggerUtility.Log($"Testing login with Username: {username} and Password: {password}");
                _loginPage.InputCredentials(new UserCredentials { Username = username, Password = password });
                _loginPage.ClickLogin();
                _loginPage.FetchDashboardTitle().Should().Be(expectedMessage);
                LoggerUtility.Log($"Dashboard title: {expectedMessage}.");
                LoggerUtility.Log("Test passed.");
            }
            catch (Exception ex)
            {
                LoggerUtility.Log($"Test failed with exception: {ex.Message}");
                LoggerUtility.Log($"Stack Trace: {ex.StackTrace}");

                throw;
            }
            finally
            {
                LoggerUtility.Log("Test is completed.");
            }
        }

        public void Dispose()
        {
            _driver.Quit();
            LoggerUtility.Log("Browser is closed.\n");

            GC.SuppressFinalize(this);
        }
    }
}
