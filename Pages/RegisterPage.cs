using OpenQA.Selenium;

public class RegisterPage
{
    IWebDriver driver;

    public RegisterPage(IWebDriver driver)
    {
        this.driver = driver;
    }

    public void GoToRegister()
    {
        driver.FindElement(By.LinkText("Register")).Click();
    }

    public void Register(string first, string last, string address,
        string city, string state, string zip,
        string phone, string ssn,
        string username, string password, string confirm)
    {
        driver.FindElement(By.Id("customer.firstName")).SendKeys(first);
        driver.FindElement(By.Id("customer.lastName")).SendKeys(last);
        driver.FindElement(By.Id("customer.address.street")).SendKeys(address);
        driver.FindElement(By.Id("customer.address.city")).SendKeys(city);
        driver.FindElement(By.Id("customer.address.state")).SendKeys(state);
        driver.FindElement(By.Id("customer.address.zipCode")).SendKeys(zip);
        driver.FindElement(By.Id("customer.phoneNumber")).SendKeys(phone);
        driver.FindElement(By.Id("customer.ssn")).SendKeys(ssn);
        driver.FindElement(By.Id("customer.username")).SendKeys(username);
        driver.FindElement(By.Id("customer.password")).SendKeys(password);
        driver.FindElement(By.Id("repeatedPassword")).SendKeys(confirm);

        driver.FindElement(By.CssSelector("input[value='Register']")).Click();
    }
}