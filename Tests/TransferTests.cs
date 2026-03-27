using NUnit.Framework;
using Lab8.Pages; // Đảm bảo using đúng folder Pages [cite: 36]
using OpenQA.Selenium;

namespace Lab8.Tests
{
    [TestFixture]
    
    public class TransferTests : BaseTest // Quan trọng: Phải có ": BaseTest" [cite: 31]
    {
        [Test]
        public void TC_TF_01_TransferSuccess()
        {
           // Mở trang chủ ParaBank 
            Driver.Navigate().GoToUrl("https://parabank.parasoft.com/parabank/index.htm");

            // Tạo object LoginPage và đăng nhập 
            var loginPage = new LoginPage(Driver);
            loginPage.Login("username_cua_vy", "password_123");

            // Điều hướng đến chức năng Vy phụ trách 
            Driver.Navigate().GoToUrl("https://parabank.parasoft.com/parabank/transfer.htm");

            var transferPage = new TransferFundsPage(Driver);
            transferPage.TransferMoney("100", "13542", "13542");

            // Cách viết mới để tránh lỗi CS0117
             Assert.That(transferPage.GetResultTitle(), Is.EqualTo("Transfer Complete!")); 
        }
    }
}