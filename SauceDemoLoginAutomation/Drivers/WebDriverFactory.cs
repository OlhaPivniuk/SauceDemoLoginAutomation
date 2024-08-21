using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;

namespace SauceDemoLoginAutomation.Drivers
{
    public static class WebDriverFactory
    {
        public static IWebDriver GetDriver(string browser)
        {
            IWebDriver driver;
            switch (browser.ToLower())
            {
                case "firefox":
                    driver = new FirefoxDriver();
                    break;
                case "edge":
                    driver = new EdgeDriver();
                    break;
                default:
                    driver = new EdgeDriver();
                    break;
            }
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            return driver;
        }

    }
}