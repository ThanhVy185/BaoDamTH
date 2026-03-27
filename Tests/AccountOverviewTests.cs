using NUnit.Framework;
using Lab8.Pages;   // Để nhận diện LoginPage, AccountOverviewPage
using Lab8.Tests;   // QUAN TRỌNG: Để nhận diện BaseTest

namespace Lab8.Tests
{
    [TestFixture]
    public class AccountOverviewTests : BaseTest
    {
        [Test]
        public void TC_AUTH_13_ViewBalance()
        {
            // Sửa driver thành Driver (viết hoa chữ D) để khớp với BaseTest
            var login = new LoginPage(Driver);
            login.Login("sang3107", "password123");

            // Đảm bảo bạn đã có file AccountOverviewPage.cs trong folder Pages
            var page = new AccountOverviewPage(Driver);

            // Navigate trực tiếp nếu Page chưa có hàm GoTo
            Driver.Navigate().GoToUrl("https://parabank.parasoft.com/parabank/overview.htm");

            // Kiểm tra số dư hiển thị (Dùng Assert.That theo chuẩn mới)
            Assert.That(page.GetBalance().Length, Is.GreaterThan(0));
        }
    }
}