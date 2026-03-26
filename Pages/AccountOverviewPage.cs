using OpenQA.Selenium;

public class AccountOverviewPage
{
    IWebDriver driver;

    public AccountOverviewPage(IWebDriver driver)
    {
        this.driver = driver;
    }

    public void GoToOverview()
    {
        driver.FindElement(By.LinkText("Accounts Overview")).Click();
    }

    public string GetBalance()
    {
        return driver.FindElement(By.XPath("//table//tr[1]/td[2]")).Text;
    }
}