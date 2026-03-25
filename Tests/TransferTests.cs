using NUnit.Framework;
using OpenQA.Selenium;
using Lab8.Pages;
using Lab8.Utilities;

namespace Lab8.Tests
{
    public class TransferTests
    {
        IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = DriverFactory.GetDriver();
            driver.Navigate().GoToUrl("https://parabank.parasoft.com/parabank/index.htm");

            LoginPage login = new LoginPage(driver);
            login.Login("john", "demo");
        }

        [Test]
        public void Transfer_100()
        {
            string status = "PASS";
            string screenshot = "";

            try
            {
                TransferFundsPage transfer = new TransferFundsPage(driver);
                transfer.Transfer("100");
            }
            catch
            {
                status = "FAIL";
            }

            screenshot = ScreenshotHelper.TakeScreenshot(driver, "Transfer_100");
            ExcelHelper.WriteResult("Transfer_100", status, screenshot);

            Assert.IsTrue(true);
        }

        [Test]
        public void Transfer_50()
        {
            string status = "PASS";
            string screenshot = "";

            try
            {
                TransferFundsPage transfer = new TransferFundsPage(driver);
                transfer.Transfer("50");
            }
            catch
            {
                status = "FAIL";
            }

            screenshot = ScreenshotHelper.TakeScreenshot(driver, "Transfer_50");
            ExcelHelper.WriteResult("Transfer_50", status, screenshot);

            Assert.IsTrue(true);
        }

        [Test]
        public void Transfer_10()
        {
            string status = "PASS";
            string screenshot = "";

            try
            {
                TransferFundsPage transfer = new TransferFundsPage(driver);
                transfer.Transfer("10");
            }
            catch
            {
                status = "FAIL";
            }

            screenshot = ScreenshotHelper.TakeScreenshot(driver, "Transfer_10");
            ExcelHelper.WriteResult("Transfer_10", status, screenshot);

            Assert.IsTrue(true);
        }

        [TearDown]
        public void TearDown()
        {
            try { driver.Quit(); } catch { }
            try { driver.Dispose(); } catch { }
        }
    }
}