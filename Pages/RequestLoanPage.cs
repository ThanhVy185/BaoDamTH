using OpenQA.Selenium;

namespace Lab8.Pages
{
    public class RequestLoanPage
    {
        private readonly IWebDriver _driver;

        private readonly By LoanAmountInput = By.Id("amount");
        private readonly By DownPaymentInput = By.Id("downPayment");
        private readonly By ApplyNowBtn = By.CssSelector("input[value='Apply Now']");
        private readonly By LoanStatus = By.Id("loanStatus"); // Hiển thị Approved hoặc Denied

        public RequestLoanPage(IWebDriver driver) => _driver = driver;

        public void ApplyForLoan(string amount, string downPayment)
        {
            _driver.FindElement(LoanAmountInput).SendKeys(amount);
            _driver.FindElement(DownPaymentInput).SendKeys(downPayment);
            _driver.FindElement(ApplyNowBtn).Click();
        }

        public string GetLoanStatus() => _driver.FindElement(LoanStatus).Text;
    }
}