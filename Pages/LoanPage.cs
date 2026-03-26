using OpenQA.Selenium;

public class LoanPage
{
    private IWebDriver driver;

    public LoanPage(IWebDriver driver)
    {
        this.driver = driver;
    }

    public void RequestLoan(string amount, string down)
    {
        driver.FindElement(By.Id("amount")).SendKeys(amount);
        driver.FindElement(By.Id("downPayment")).SendKeys(down);
        driver.FindElement(By.XPath("//input[@value='Apply Now']")).Click();
    }
}