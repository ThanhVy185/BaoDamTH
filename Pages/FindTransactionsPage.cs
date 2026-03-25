using OpenQA.Selenium;
using Lab8.Utilities;

namespace Lab8.Pages
{
    public class FindTransactionsPage
    {
        IWebDriver driver;

        public FindTransactionsPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void Find()
        {
            driver.FindElement(By.LinkText("Find Transactions")).Click();
            DelayHelper.Sleep(300);
            driver.FindElement(By.Name("amount")).SendKeys("10");
            DelayHelper.Sleep(300);
            driver.FindElement(By.XPath("//button[contains(text(),'Find Transactions')]")).Click();
            DelayHelper.Sleep(300);
        }
    }
}