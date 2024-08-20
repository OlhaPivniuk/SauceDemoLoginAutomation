using OpenQA.Selenium;
using SauceDemoLoginAutomation.Drivers;
using SauceDemoLoginAutomation.Models;
using SauceDemoLoginAutomation.Utilities;
using SauceDemoLoginAutomation.PageObjects;
using Xunit;
using FluentAssertions;

namespace SauceDemoLoginAutomation.Tests
{
    [Collection("ParallelTestCollection1")]
    public class LoginTestsWithInvalidCredentials : IDisposable
    {
        private readonly IWebDriver _driver;
        private readonly LoginPageObject _loginPage;
        private readonly UserCredentials _credentials;

        public LoginTestsWithInvalidCredentials()
        {
            _driver = DriverFactory.GetDriver("edge");
            _loginPage = new LoginPageObject(_driver);
            _loginPage.OpenLoginPage();
            LoggerUtility.Log("Login page is opened.");

            _credentials = new UserCredentials
            {
                Username = "standard_user",
                Password = "secret_sauce"
            };
        }
        private void LogTestStart(string testName)
        {
            LoggerUtility.Log($"Test {testName} started.");
        }

        [Theory]
        [InlineData("Username is required")]
        public void TestLoginForm_EmptyFields_UsernameIsRequiredError(string expectedMessage)
        {
            try
            {
                LoggerUtility.Log("Testing login with empty inputs");
                _loginPage.InputCredentials(new UserCredentials { Username = "", Password = "" });
                _loginPage.ClearAllFields();
                _loginPage.ClickLogin();

                _loginPage.GetErrorMessage().Should().Contain(expectedMessage);
                LoggerUtility.Log($"Error message: {expectedMessage}.");
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

        [Theory]
        [InlineData("standard_user", "Password is required")]
        public void TestLoginForm_EmptyPassword_PasswordIsRequiredError(string username, string expectedMessage)
        {
            try
            {
                LoggerUtility.Log($"Testing login with Username: {username} and empty password");
                _loginPage.InputCredentials(new UserCredentials { Username = username, Password = "" });
                _loginPage.ClickLogin();

                _loginPage.GetErrorMessage().Should().Contain(expectedMessage);
                LoggerUtility.Log($"Error message: {expectedMessage}.");
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
