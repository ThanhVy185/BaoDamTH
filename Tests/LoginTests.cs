using Lab8.Pages;
using Lab8;
using OpenQA.Selenium;
using NUnit.Framework;
using OpenQA.Selenium;
using System.Threading;

namespace Lab8.Tests
{
    public class LoginTests
    {
        IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = DriverFactory.GetDriver();
            driver.Navigate().GoToUrl("https://parabank.parasoft.com/parabank/index.htm");
        }

        [Test]
        public void Login_Success()
        {
            LoginPage login = new LoginPage(driver);
            login.Login("john", "demo");

            Thread.Sleep(2000);

            Assert.That(driver.PageSource.Contains("Accounts Overview"), Is.True);
        }

        //[Test]
        //public void Login_Fail()
        //{
        //    LoginPage login = new LoginPage(driver);
        //    login.Login("Thanh Vy", "123456");

        //    Thread.Sleep(2000);

        //    Assert.That(driver.PageSource.Contains("Error"), Is.True);
        //}

        [TearDown]
        public void TearDown()
        {
            DriverFactory.QuitDriver();

        }
    }
}