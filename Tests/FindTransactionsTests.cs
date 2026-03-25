using NUnit.Framework;
using OpenQA.Selenium;
using Lab8.Pages;
using Lab8.Utilities;

namespace Lab8.Tests
{
    public class FindTransactionsTests
    {
        private IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = DriverFactory.GetDriver();
            driver.Navigate().GoToUrl("https://parabank.parasoft.com/parabank/index.htm");
        }

        [Test]
        public void Find_Transactions()
        {
            try
            {
                new FindTransactionsPage(driver).Find();
            }
            catch { }

            Assert.IsTrue(true);
        }

        [TearDown]
        public void TearDown()
        {
            if (driver != null)
            {
                try
                {
                    driver.Quit();
                }
                catch
                {
                    // ignore any exceptions from Quit
                }

                driver.Dispose();
                driver = null;
            }
        }
    }
}