using OpenQA.Selenium;
using SauceDemoLoginAutomation.PageObjects;
using SauceDemoLoginAutomation.Models;
using TechTalk.SpecFlow;
using FluentAssertions;
using SauceDemoLoginAutomation.Utilities;

namespace SauceDemoLoginAutomation.StepDefinitions
{
    [Binding]
    public class LoginSteps
    {
        private readonly LoginPageObject _loginPage;
        private readonly UserCredentials _credentials;

        public LoginSteps(IWebDriver driver)
        {
            _loginPage = new LoginPageObject(driver);
            _credentials = new UserCredentials();
        }

        [Given(@"I open the login page")]
        public void GivenIOpenTheLoginPage()
        {
            LoggerUtility.Log("Opening the login page.");
            _loginPage.OpenLoginPage();
            LoggerUtility.Log("Login page opened.");
        }

        [When(@"I clear the ""(.*)"" and ""(.*)"" fields")]
        public void WhenIClearTheFields(string username, string password)
        {
            LoggerUtility.Log($"Clearing fields: Username='{username}', Password='{password}'");
            _loginPage.ClearAllFields();
            LoggerUtility.Log("Fields cleared.");
        }

        [When(@"I enter ""(.*)"" as the username")]
        public void WhenIEnterAsTheUsername(string username)
        {
            _credentials.Username = username;
            LoggerUtility.Log($"Entering username: {username}");
            _loginPage.InputUsername(username);
            LoggerUtility.Log("Username entered.");
        }

        [When(@"I enter ""(.*)"" as the password")]
        public void WhenIEnterAsThePassword(string password)
        {
            _credentials.Password = password;
            LoggerUtility.Log($"Entering password: {password}");
            _loginPage.InputPassword(password);
            LoggerUtility.Log("Password entered.");
        }

        [When(@"I clear the ""(.*)"" field")]
        public void WhenIClearTheField(string field)
        {
            LoggerUtility.Log($"Clearing the {field} field.");
            _loginPage.ClearField(field);
            LoggerUtility.Log($"{field} field cleared.");
        }

        [When(@"I click the ""(.*)"" button")]
        public void WhenIClickTheButton(string button)
        {
            LoggerUtility.Log($"Clicking the {button} button.");
            if (button.ToLower() == "login")
            {
                _loginPage.ClickLogin();
                LoggerUtility.Log("Login button clicked.");
            }
        }

        [Then(@"I should see an error message saying ""(.*)""")]
        public void ThenIShouldSeeAnErrorMessageSaying(string expectedMessage)
        {
            var actualMessage = _loginPage.GetErrorMessage();
            LoggerUtility.Log($"Verifying error message: Expected='{expectedMessage}', Actual='{actualMessage}'");
            actualMessage.Should().Contain(expectedMessage);
            LoggerUtility.Log("Error message verified.");
        }

        [Then(@"I should see the dashboard title ""(.*)""")]
        public void ThenIShouldSeeTheDashboardTitle(string expectedTitle)
        {
            var actualTitle = _loginPage.FetchDashboardTitle();
            LoggerUtility.Log($"Verifying dashboard title: Expected='{expectedTitle}', Actual='{actualTitle}'");
            actualTitle.Should().Be(expectedTitle);
            LoggerUtility.Log("Dashboard title verified.");
        }
    }
}
