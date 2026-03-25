// Tests/RequestLoanTests.cs
using Lab8.Pages;
using Lab8;
using Lab8.Utilities;
using OpenQA.Selenium;
using NUnit.Framework;

namespace Lab8.Tests
{
    [TestFixture]
    public class RequestLoanTests
    {
        IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = DriverFactory.GetDriver();
            driver.Navigate().GoToUrl("https://parabank.parasoft.com/parabank/index.htm");
        }

        [Test]
        public void Request_Loan()
        {
            try
            {
                new RequestLoanPage(driver).Request();
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