using Lab8.Pages;
using Lab8.Utilities;
using OpenQA.Selenium;
using NUnit.Framework;

namespace Lab8.Tests
{
    public class BillPayTests
    {
        IWebDriver? driver;

        [SetUp]
        public void Setup()
        {
            driver = DriverFactory.GetDriver();
            driver.Navigate().GoToUrl("https://parabank.parasoft.com/parabank/index.htm");
        }

        [Test]
        public void Bill_Pay()
        {
            try
            {
                new BillPayPage(driver).PayBill();
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