using OpenQA.Selenium;

public class TransferPage
{
    private IWebDriver driver;

    public TransferPage(IWebDriver driver)
    {
        this.driver = driver;
    }

    public void TransferMoney(string amount)
    {
        driver.FindElement(By.Id("amount")).SendKeys(amount);
        driver.FindElement(By.XPath("//input[@value='Transfer']")).Click();
    }
}