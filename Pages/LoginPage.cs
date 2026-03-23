using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
namespace Lab8.Pages

{
    public class LoginPage
    {
        IWebDriver driver;

        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        By username = By.Name("username");
        By password = By.Name("password");
        By loginBtn = By.CssSelector("input[type='submit']");

        public void Login(string user, string pass)
        {
            driver.FindElement(username).SendKeys(user);
            driver.FindElement(password).SendKeys(pass);
            driver.FindElement(loginBtn).Click();
        }
    }
}