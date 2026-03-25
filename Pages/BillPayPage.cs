using OpenQA.Selenium;

public class BillPayPage
{
    private IWebDriver driver;

    public BillPayPage(IWebDriver driver)
    {
        this.driver = driver;
    }

    public void Pay(string name, string addr, string city, string state, string zip, string phone, string acc, string amount)
    {
        driver.FindElement(By.Name("payee.name")).SendKeys(name);
        driver.FindElement(By.Name("payee.address.street")).SendKeys(addr);
        driver.FindElement(By.Name("payee.address.city")).SendKeys(city);
        driver.FindElement(By.Name("payee.address.state")).SendKeys(state);
        driver.FindElement(By.Name("payee.address.zipCode")).SendKeys(zip);
        driver.FindElement(By.Name("payee.phoneNumber")).SendKeys(phone);
        driver.FindElement(By.Name("payee.accountNumber")).SendKeys(acc);
        driver.FindElement(By.Name("amount")).SendKeys(amount);

        driver.FindElement(By.XPath("//input[@value='Send Payment']")).Click();
    }
}