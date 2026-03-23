using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace Lab8.Pages
{
    public class TransferFundsPage
    {
        IWebDriver driver;

        public TransferFundsPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void Transfer(string amount)
        {
            driver.FindElement(By.LinkText("Transfer Funds")).Click();
            driver.FindElement(By.Id("amount")).SendKeys(amount);
            driver.FindElement(By.CssSelector("input[value='Transfer']")).Click();
        }
    }
}
