using OpenQA.Selenium;

public class ProfilePage
{
    private IWebDriver driver;

    public ProfilePage(IWebDriver driver)
    {
        this.driver = driver;
    }

    public void UpdateProfile(string first, string last, string addr, string city, string state, string zip, string phone)
    {
        driver.FindElement(By.Id("customer.firstName")).SendKeys(first);
        driver.FindElement(By.Id("customer.lastName")).SendKeys(last);
        driver.FindElement(By.Id("customer.address.street")).SendKeys(addr);
        driver.FindElement(By.Id("customer.address.city")).SendKeys(city);
        driver.FindElement(By.Id("customer.address.state")).SendKeys(state);
        driver.FindElement(By.Id("customer.address.zipCode")).SendKeys(zip);
        driver.FindElement(By.Id("customer.phoneNumber")).SendKeys(phone);

        driver.FindElement(By.XPath("//input[@value='Update Profile']")).Click();
    }
}