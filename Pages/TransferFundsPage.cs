using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Lab8.Pages
{
    public class TransferFundsPage
    {
        private readonly IWebDriver _driver;

        // 1. Locators (Nằm trong page) [cite: 28]
        private By AmountInput = By.Id("amount");
        private By FromAccountId = By.Id("fromAccountId");
        private By ToAccountId = By.Id("toAccountId");
        private By TransferButton = By.CssSelector("input[value='Transfer']");
        private By SuccessMessage = By.XPath("//h1[text()='Transfer Complete!']");

        public TransferFundsPage(IWebDriver driver)
        {
            _driver = driver;
        }

        // 2. Actions (Nằm trong page) [cite: 29]
        public void TransferMoney(string amount, string fromAccount, string toAccount)
        {
            _driver.FindElement(AmountInput).SendKeys(amount);

            // Đợi dropdown load xong rồi chọn account
            new SelectElement(_driver.FindElement(FromAccountId)).SelectByText(fromAccount);
            new SelectElement(_driver.FindElement(ToAccountId)).SelectByText(toAccount);

            _driver.FindElement(TransferButton).Click();
        }

        public string GetResultTitle() => _driver.FindElement(SuccessMessage).Text;
    }
}