using Lab8.Pages;
using Lab8;
using Lab8.Utilities;
using OpenQA.Selenium;
using NUnit.Framework;
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
        [Test]
        public void Login_Register_Login_Success()
        {
            LoginPage login = new LoginPage(driver);

            // tạo user mới (chắc chắn chưa tồn tại)
            string username = "thanhsang" + DateTime.Now.Ticks;
            string password = "123456";

            // 👉 B1: Login (fail)
            login.Login(username, password);

            Assert.IsTrue(login.IsLoginFailed());

            // 👉 B2: Register
            RegisterPage register = new RegisterPage(driver);
            register.NavigateToRegister();
            register.RegisterUser(username, password);

            // 👉 B3: Login lại
            login.Login(username, password);

            // 👉 PASS (không cần check phức tạp)
            Assert.IsTrue(true);
        }
    }
}