using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SauceDemoLoginAutomation.PageObjects
{
    public class LoginPageObject
    {
        private readonly IWebDriver _driver;
        private readonly string _url = "https://www.saucedemo.com/";
        private readonly WebDriverWait _wait;

        public LoginPageObject(IWebDriver driver)
        {
            _driver = driver;
            _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        private IWebElement UsernameField => _driver.FindElement(By.CssSelector("#user-name"));
        private IWebElement PasswordField => _driver.FindElement(By.CssSelector("#password"));
        private IWebElement LoginButton => _driver.FindElement(By.CssSelector("#login-button"));
        private IWebElement ErrorMessage => _driver.FindElement(By.CssSelector(".error-message-container.error"));

        public void OpenLoginPage() => _driver.Navigate().GoToUrl(_url);

        public void InputUsername(string username)
        {
            _wait.Until(d => UsernameField.Displayed);
            UsernameField.Clear();
            UsernameField.SendKeys(username);
        }

        public void InputPassword(string password)
        {
            _wait.Until(d => PasswordField.Displayed);
            PasswordField.Clear();
            PasswordField.SendKeys(password);
        }

        public void ClickLogin()
        {
            _wait.Until(d => LoginButton.Enabled);
            LoginButton.Click();
        }

        public string GetErrorMessage()
        {
            _wait.Until(d => ErrorMessage.Displayed);
            return ErrorMessage.Text;
        }

        public string FetchDashboardTitle()
        {
            IWebElement DashboardTitle = _driver.FindElement(By.CssSelector(".app_logo"));
            return DashboardTitle.Text;
        }

        public void ClearAllFields()
        {
            ClearField("username");
            ClearField("password");
        }

        public void ClearField(string fieldName)
        {
            if (fieldName.ToLower() == "username")
            {
                UsernameField.Clear();
            }
            else if (fieldName.ToLower() == "password")
            {
                PasswordField.Clear();
            }
        }
    }
}
