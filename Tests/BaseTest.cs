using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

public class BaseTest
{
    protected IWebDriver? driver;

    [SetUp]
    public void Setup()
    {
        driver = new ChromeDriver();
        driver.Manage().Window.Maximize();
        driver.Navigate().GoToUrl("https://parabank.parasoft.com/");
    }

    [TearDown]
    public void TearDown()
    {
        try
        {
            driver?.Quit();
        }
        finally
        {
            driver?.Dispose();
            driver = null;
        }
    }
}