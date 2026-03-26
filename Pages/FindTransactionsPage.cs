using OpenQA.Selenium;

public class FindTransactionPage
{
    private IWebDriver driver;

    public FindTransactionPage(IWebDriver driver)
    {
        this.driver = driver;
    }

    public void SearchByDate(string date)
    {
        driver.FindElement(By.Id("criteria.onDate")).SendKeys(date);
        driver.FindElement(By.XPath("//button[contains(text(),'Find')]")).Click();
    }
}