using NUnit.Framework;
using Lab8.Pages;   // Để nhận diện LoginPage, OpenAccountPage
using Lab8.Tests;   // Để nhận diện BaseTest

namespace Lab8.Tests
{
    [TestFixture]
    public class OpenAccountTests : BaseTest
    {
        [Test]
        public void TC_AUTH_17_Open_Checking()
        {
            // Sửa driver -> Driver (viết hoa chữ D) theo BaseTest của nhóm
            var login = new LoginPage(Driver);
            login.Login("sang3107", "password123");

            // Đảm bảo Vy đã có file OpenAccountPage.cs trong folder Pages
            var open = new OpenAccountPage(Driver);

            // Navigate trực tiếp đến trang mở tài khoản
            Driver.Navigate().GoToUrl("https://parabank.parasoft.com/parabank/openaccount.htm");

            open.OpenAccount("CHECKING");

            // Dùng Assert.That theo chuẩn NUnit mới để không bị lỗi CS0117
            Assert.That(Driver.PageSource.Contains("Account Opened"), Is.True);
        }

        [Test]
        public void TC_AUTH_18_Open_Saving()
        {
            var login = new LoginPage(Driver);
            login.Login("sang3107", "password123");

            var open = new OpenAccountPage(Driver);

            Driver.Navigate().GoToUrl("https://parabank.parasoft.com/parabank/openaccount.htm");

            open.OpenAccount("SAVINGS");

            Assert.That(Driver.PageSource.Contains("Account Opened"), Is.True);
        }
    }
}