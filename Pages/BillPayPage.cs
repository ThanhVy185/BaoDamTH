using OpenQA.Selenium;

namespace Lab8.Pages
{
    public class BillPayPage
    {
        private readonly IWebDriver _driver;

        // Locators cho các trường thông tin người thụ hưởng (Payee)
        private By PayeeNameInput = By.Name("payee.name");
        private By AddressInput = By.Name("payee.address.street");
        private By CityInput = By.Name("payee.address.city");
        private By StateInput = By.Name("payee.address.state");
        private By ZipCodeInput = By.Name("payee.address.zipCode");
        private By PhoneInput = By.Name("payee.phoneNumber");
        private By AccountInput = By.Name("payee.accountNumber");
        private By VerifyAccountInput = By.Name("verifyAccount");
        private By AmountInput = By.Name("amount");
        private By SendPaymentButton = By.CssSelector("input[value='Send Payment']");
        private By SuccessMsg = By.XPath("//h1[text()='Bill Payment Complete']");

        public BillPayPage(IWebDriver driver) => _driver = driver;

        public void PayBill(string name, string address, string city, string state, string zip, string phone, string acc, string amount)
        {
            _driver.FindElement(PayeeNameInput).SendKeys(name);
            _driver.FindElement(AddressInput).SendKeys(address);
            _driver.FindElement(CityInput).SendKeys(city);
            _driver.FindElement(StateInput).SendKeys(state);
            _driver.FindElement(ZipCodeInput).SendKeys(zip);
            _driver.FindElement(PhoneInput).SendKeys(phone);
            _driver.FindElement(AccountInput).SendKeys(acc);
            _driver.FindElement(VerifyAccountInput).SendKeys(acc);
            _driver.FindElement(AmountInput).SendKeys(amount);

            // CHỖ NÀY NÈ VY! Dừng lại 5 giây để Vy check thông tin vừa điền xong
            System.Threading.Thread.Sleep(1000);

            // Sau khi hết 5 giây nó mới bấm nút này để tiếp tục
            _driver.FindElement(SendPaymentButton).Click();

            //_driver.FindElement(SendPaymentButton).Click();
        }

        public string GetResultText() => _driver.FindElement(SuccessMsg).Text;
    }
}