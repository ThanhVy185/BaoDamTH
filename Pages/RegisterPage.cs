using OpenQA.Selenium;
using Lab8.Utilities;

namespace Lab8.Pages
{
    public class RegisterPage
    {
        private IWebDriver driver;

        public RegisterPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        // Locators
        private By registerLink = By.LinkText("Register");
        private By firstName = By.Id("customer.firstName");
        private By lastName = By.Id("customer.lastName");
        private By address = By.Id("customer.address.street");
        private By city = By.Id("customer.address.city");
        private By state = By.Id("customer.address.state");
        private By zipCode = By.Id("customer.address.zipCode");
        private By phone = By.Id("customer.phoneNumber");
        private By ssn = By.Id("customer.ssn");
        private By username = By.Id("customer.username");
        private By password = By.Id("customer.password");
        private By confirmPassword = By.Id("repeatedPassword");
        private By registerBtn = By.XPath("//input[@value='Register']");
        private By successMsg = By.XPath("//h1[contains(text(),'Welcome')]");

        // Actions
        public void NavigateToRegister()
        {
            driver.FindElement(registerLink).Click();
        }

        public void RegisterUser(string user, string pass)
        {
            driver.FindElement(firstName).SendKeys("Sang");
            DelayHelper.Sleep(300);
            driver.FindElement(lastName).SendKeys("Tran");
            DelayHelper.Sleep(300);
            driver.FindElement(address).SendKeys("HCM"); 
            DelayHelper.Sleep(300);
            driver.FindElement(city).SendKeys("HCM"); 
            DelayHelper.Sleep(300);
            driver.FindElement(state).SendKeys("HCM");
            DelayHelper.Sleep(300);
            driver.FindElement(zipCode).SendKeys("70000");
            DelayHelper.Sleep(300);
            driver.FindElement(phone).SendKeys("0123456789");
            DelayHelper.Sleep(300);
            driver.FindElement(ssn).SendKeys("123");
            DelayHelper.Sleep(300);

            driver.FindElement(username).SendKeys(user);
            driver.FindElement(password).SendKeys(pass);
            driver.FindElement(confirmPassword).SendKeys(pass);

            driver.FindElement(registerBtn).Click();
        }

        public bool IsRegisterSuccess()
        {
            return driver.FindElement(successMsg).Displayed;
        }
    }
}