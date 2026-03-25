using OpenQA.Selenium;
using Lab8.Utilities;

namespace Lab8.Pages
{
    public class RequestLoanPage
    {
        IWebDriver driver;

        public RequestLoanPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void Request()
        {
            driver.FindElement(By.LinkText("Request Loan")).Click();
            driver.FindElement(By.Id("amount")).SendKeys("100");
            driver.FindElement(By.Id("downPayment")).SendKeys("10");

            driver.FindElement(By.XPath("//input[@value='Apply Now']")).Click();
        }
    }
}