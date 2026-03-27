using OpenQA.Selenium;

namespace Lab8.Pages
{
    public class RegisterPage
    {
        private readonly IWebDriver _driver;

        // Locators [cite: 28]
        private readonly By FirstName = By.Id("customer.firstName");
        private readonly By LastName = By.Id("customer.lastName");
        private readonly By Address = By.Id("customer.address.street");
        private readonly By City = By.Id("customer.address.city");
        private readonly By State = By.Id("customer.address.state");
        private readonly By ZipCode = By.Id("customer.address.zipCode");
        private readonly By Phone = By.Id("customer.phoneNumber");
        private readonly By SSN = By.Id("customer.ssn");
        private readonly By Username = By.Id("customer.username");
        private readonly By Password = By.Id("customer.password");
        private readonly By Confirm = By.Id("repeatedPassword");
        private readonly By RegisterBtn = By.CssSelector("input[value='Register']");
        private readonly By SuccessMsg = By.XPath("//p[contains(text(), 'account was created successfully')]");

        public RegisterPage(IWebDriver driver) => _driver = driver;

       // Actions 
        public void FillRegistrationForm(dynamic user)
        {
            _driver.FindElement(FirstName).SendKeys(user.FirstName.ToString());
            _driver.FindElement(LastName).SendKeys(user.LastName.ToString());
            _driver.FindElement(Address).SendKeys(user.Address.ToString());
            _driver.FindElement(City).SendKeys(user.City.ToString());
            _driver.FindElement(State).SendKeys(user.State.ToString());
            _driver.FindElement(ZipCode).SendKeys(user.ZipCode.ToString());
            _driver.FindElement(Phone).SendKeys(user.Phone.ToString());
            _driver.FindElement(SSN).SendKeys(user.SSN.ToString());
            _driver.FindElement(Username).SendKeys(user.Username.ToString());
            _driver.FindElement(Password).SendKeys(user.Password.ToString());
            _driver.FindElement(Confirm).SendKeys(user.Password.ToString());
            _driver.FindElement(RegisterBtn).Click();
        }

        public string GetSuccessMessage() => _driver.FindElement(SuccessMsg).Text;

        public void Register(string fName, string lName, string addr, string city, string state, string zip, string phone, string ssn, string user, string pass, string confirm)
        {
            _driver.FindElement(By.Id("customer.firstName")).SendKeys(fName);
            _driver.FindElement(By.Id("customer.lastName")).SendKeys(lName);
            _driver.FindElement(By.Id("customer.address.street")).SendKeys(addr);
            _driver.FindElement(By.Id("customer.address.city")).SendKeys(city);
            _driver.FindElement(By.Id("customer.address.state")).SendKeys(state);
            _driver.FindElement(By.Id("customer.address.zipCode")).SendKeys(zip);
            _driver.FindElement(By.Id("customer.phoneNumber")).SendKeys(phone);
            _driver.FindElement(By.Id("customer.ssn")).SendKeys(ssn);
            _driver.FindElement(By.Id("customer.username")).SendKeys(user);
            _driver.FindElement(By.Id("customer.password")).SendKeys(pass);
            _driver.FindElement(By.Id("repeatedPassword")).SendKeys(confirm);
            _driver.FindElement(By.CssSelector("input[value='Register']")).Click();
        }
    }

}