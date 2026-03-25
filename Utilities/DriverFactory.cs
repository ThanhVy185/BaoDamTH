using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Lab8.Utilities
{
    public class DriverFactory
    {
        public static IWebDriver GetDriver()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            return driver;
        }
    }
}