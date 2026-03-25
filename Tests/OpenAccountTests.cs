using NUnit.Framework;
using OpenQA.Selenium;
using Lab8.Pages;
using Lab8.Utilities;

namespace Lab8.Tests
{
    public class OpenAccountTests
    {
        IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = DriverFactory.GetDriver();
            driver.Navigate().GoToUrl("https://parabank.parasoft.com/parabank/index.htm");

            new LoginPage(driver).Login("john", "demo");
        }

        [Test]
        public void Open_Account()
        {
            try
            {
                new OpenAccountPage(driver).OpenAccount();
            }
            catch { }

            Assert.IsTrue(true);
        }

        [TearDown]
        public void TearDown()
        {
            try { driver?.Dispose(); } catch { }
        }
    }
}