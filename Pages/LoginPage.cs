using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using Lab8.Utilities;
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
            DelayHelper.Sleep(300);
            driver.FindElement(password).SendKeys(pass);
            DelayHelper.Sleep(300);
            driver.FindElement(loginBtn).Click();
            DelayHelper.Sleep(300);
        }
        private By errorMsg = By.XPath("//p[@class='error']");

        public bool IsLoginFailed()
        {
            try
            {
                return driver.FindElement(errorMsg).Displayed;
            }
            catch
            {
                return false;
            }
        }
    }
}