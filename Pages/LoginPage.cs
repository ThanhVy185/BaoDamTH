using OpenQA.Selenium;

public class LoginPage
{
    IWebDriver driver;

    public LoginPage(IWebDriver driver)
    {
        this.driver = driver;
    }

    public void Login(string username, string password)
    {
        driver.FindElement(By.Name("username")).SendKeys(username);
        driver.FindElement(By.Name("password")).SendKeys(password);
        driver.FindElement(By.CssSelector("input[value='Log In']")).Click();
    }
}