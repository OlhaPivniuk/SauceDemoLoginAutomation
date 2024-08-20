using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SauceDemoLoginAutomation.Models;

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
            _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
        }

        private IWebElement UsernameField => _driver.FindElement(By.CssSelector("#user-name"));
        private IWebElement PasswordField => _driver.FindElement(By.CssSelector("#password"));
        private IWebElement LoginButton => _driver.FindElement(By.CssSelector("#login-button"));
        private IWebElement ErrorMessage => _driver.FindElement(By.CssSelector(".error-message-container.error"));

        public void OpenLoginPage() => _driver.Navigate().GoToUrl(_url);
        public void InputCredentials(UserCredentials credentials)
        {
            UsernameField.SendKeys(credentials.Username);
            PasswordField.SendKeys(credentials.Password);
        }
        public void ClickLogin() => LoginButton.Click();
        public string GetErrorMessage() => ErrorMessage.Text;
        public string FetchDashboardTitle()
        {
            IWebElement DashboardTitle = _driver.FindElement(By.CssSelector(".app_logo"));
            return DashboardTitle.Text;
        }
        public void ClearAllFields()
        {
            while (!UsernameField.GetAttribute("value").Equals(""))
            {
                UsernameField.SendKeys(Keys.Backspace);
            }
            ClearPasswordField();
        }
        public void ClearPasswordField()
        {
            while (!PasswordField.GetAttribute("value").Equals(""))
            {
                PasswordField.SendKeys(Keys.Backspace);
            }
        }
    }
}
