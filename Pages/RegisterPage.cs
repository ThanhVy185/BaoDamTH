using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace Lab8.Pages
{
    public class RegisterPage
    {
        IWebDriver driver;

        public RegisterPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void Register(string user, string pass)
        {
            driver.FindElement(By.LinkText("Register")).Click();

            driver.FindElement(By.Name("customer.firstName")).SendKeys("Vy");
            driver.FindElement(By.Name("customer.lastName")).SendKeys("Thanh");

            driver.FindElement(By.Name("customer.username")).SendKeys(user);
            driver.FindElement(By.Name("customer.password")).SendKeys(pass);
            driver.FindElement(By.Name("repeatedPassword")).SendKeys(pass);

            driver.FindElement(By.CssSelector("input[value='Register']")).Click();
        }
    }
}
