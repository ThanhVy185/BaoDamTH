using OpenQA.Selenium;

namespace Lab8.Pages
{
    public class UpdateContactPage
    {
        private readonly IWebDriver _driver;

        // Locators cho các trường thông tin
        private readonly By FirstNameInput = By.Id("customer.firstName");
        private readonly By AddressInput = By.Id("customer.address.street");
        private readonly By CityInput = By.Id("customer.address.city");
        private readonly By PhoneInput = By.Id("customer.phoneNumber");
        private readonly By UpdateProfileBtn = By.CssSelector("input[value='Update Profile']");

        // Locators cho thông báo lỗi
        private readonly By SuccessMsg = By.XPath("//h1[text()='Update Profile']");
        private readonly By ErrorMsg = By.ClassName("error");

        public UpdateContactPage(IWebDriver driver) => _driver = driver;

        public void UpdateInfo(string fName, string addr, string city, string phone)
        {
            _driver.FindElement(FirstNameInput).Clear();
            _driver.FindElement(FirstNameInput).SendKeys(fName);

            _driver.FindElement(AddressInput).Clear();
            _driver.FindElement(AddressInput).SendKeys(addr);

            _driver.FindElement(CityInput).Clear();
            _driver.FindElement(CityInput).SendKeys(city);

            _driver.FindElement(PhoneInput).Clear();
            _driver.FindElement(PhoneInput).SendKeys(phone);

            _driver.FindElement(UpdateProfileBtn).Click();
        }

        public string GetResultText() => _driver.FindElement(SuccessMsg).Text;
    }
}