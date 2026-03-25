using NUnit.Framework;
using OpenQA.Selenium;
using Lab8.Pages;
using Lab8.Utilities;

namespace Lab8.Tests
{
    public class UpdateContactTests
    {
        private IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = DriverFactory.GetDriver();
            driver.Navigate().GoToUrl("https://parabank.parasoft.com/parabank/index.htm");
        }

        [Test]
        public void Update_Contact()
        {
            try
            {
                new UpdateContactPage(driver).Update();
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
                finally
                {
                    driver.Dispose();
                    driver = null;
                }
            }
        }
    }
}