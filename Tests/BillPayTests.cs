using NUnit.Framework;
using Lab8.Pages;

namespace Lab8.Tests
{
    [TestFixture]
   
    public class BillPayTests : BaseTest // Kế thừa để dùng chung Driver đã được xử lý TearDown [cite: 30]
    {
        
        [Test]
        public void TC_BP_01_PayBillSuccessfully()
        {
            // 1. Đăng nhập (Rất quan trọng)
            var login = new LoginPage(Driver);
            login.Login("sang3107", "password123");

            // 2. Phải chuyển hướng đến trang Bill Pay
            Driver.Navigate().GoToUrl("https://parabank.parasoft.com/parabank/billpay.htm");

            // 3. Thực hiện thanh toán
            var billPage = new BillPayPage(Driver);
            billPage.PayBill("Electric Co", "123 Street", "HCM", "HCM", "70000", "0123456", "13545", "100");
           
          

            // 4. Kiểm tra thông báo thành công
            Assert.That(Driver.PageSource, Does.Contain("Bill Payment Complete"));
            // Dừng lại 3 giây để Vy tận mắt nhìn thấy các ô đã được điền xong
               System.Threading.Thread.Sleep(3000);
        }
    }
}