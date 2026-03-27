using NUnit.Framework;
using Lab8.Pages;

namespace Lab8.Tests
{
    [TestFixture]
    public class RequestLoanTests : BaseTest
    {
        [Test]
        public void TC_RL_01_RequestLoanApproved()
        {
            var loginPage = new LoginPage(Driver);
            loginPage.Login("john", "demo");

            Driver.Navigate().GoToUrl("https://parabank.parasoft.com/parabank/requestloan.htm");

            var loanPage = new RequestLoanPage(Driver);
            loanPage.ApplyForLoan("1000", "100");

            // Kiểm tra trạng thái duyệt vay [cite: 54]
            Assert.That(loanPage.GetLoanStatus(), Is.EqualTo("Approved"));
        }
    }
}