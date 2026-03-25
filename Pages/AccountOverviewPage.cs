using OpenQA.Selenium;
using Lab8.Utilities;

namespace Lab8.Pages
{
    public class AccountOverviewPage
    {
        private IWebDriver driver;

        public AccountOverviewPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        private By accountTable = By.Id("accountTable");

        public bool IsAccountTableDisplayed()
        {
            return driver.FindElement(accountTable).Displayed;
        }
    }
}