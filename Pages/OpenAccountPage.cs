using OpenQA.Selenium;
using Lab8.Utilities;

namespace Lab8.Pages
{
    public class OpenAccountPage
    {
        IWebDriver driver;

        public OpenAccountPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        private By openAccountLink = By.LinkText("Open New Account");
        private By openBtn = By.XPath("//input[@value='Open New Account']");

        public void OpenAccount()
        {
            driver.FindElement(openAccountLink).Click();
            DelayHelper.Sleep(300);
            driver.FindElement(openBtn).Click();
            DelayHelper.Sleep(300);
        }
    }
}