using NUnit.Framework;
using OpenQA.Selenium;
using Lab8.Pages;
using Lab8.Utilities;

namespace Lab8.Tests
{
    public class AccountOverviewTests
    {
        IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = DriverFactory.GetDriver();
            driver.Navigate().GoToUrl("https://parabank.parasoft.com/parabank/index.htm");

            // login trước
            LoginPage login = new LoginPage(driver);
            login.Login("john", "demo");
        }

        [Test]
        public void View_Account_Overview_Success()
        {
            AccountOverviewPage page = new AccountOverviewPage(driver);

            Assert.IsTrue(page.IsAccountTableDisplayed());
        }

        [TearDown]
        public void TearDown()
        {
            // Ensure the IWebDriver is disposed in a TearDown method to satisfy NUnit1032.
            try
            {
                driver?.Quit();
            }
            finally
            {
                driver?.Dispose();
                driver = null;
            }
        }
    }
}

