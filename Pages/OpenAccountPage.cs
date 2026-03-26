using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

public class OpenAccountPage
{
    IWebDriver driver;

    public OpenAccountPage(IWebDriver driver)
    {
        this.driver = driver;
    }

    public void OpenAccount(string type)
    {
        driver.FindElement(By.LinkText("Open New Account")).Click();

        var accountType = new SelectElement(driver.FindElement(By.Id("type")));
        accountType.SelectByText(type);

        driver.FindElement(By.CssSelector("input[value='Open New Account']")).Click();
    }
}