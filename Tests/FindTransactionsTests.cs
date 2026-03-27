using NUnit.Framework;
using Lab8.Pages;

namespace Lab8.Tests
{
    [TestFixture]
    public class FindTransactionsTests : BaseTest
    {
        [Test]
        public void TC_FT_01_SearchByAmount()
        {
            // 1. Đăng nhập
            var login = new LoginPage(Driver);
            login.Login("sang3107", "password123");

            // 2. Chuyển hướng đúng trang (QUAN TRỌNG)
            Driver.Navigate().GoToUrl("https://parabank.parasoft.com/parabank/findtrans.htm");

            // 3. Thực hiện tìm kiếm
            var findPage = new FindTransactionsPage(Driver);
            findPage.FindByAmount("100");

            // 4. Kiểm tra kết quả
            Assert.That(Driver.PageSource, Does.Contain("Transaction Results"));

            // Dừng lại 3 giây để Vy xem bảng kết quả hiện ra
            System.Threading.Thread.Sleep(3000);
        }
    }
}