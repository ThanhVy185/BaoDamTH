using OpenQA.Selenium;
using Lab8.Utilities;

namespace Lab8.Pages
{
    public class UpdateContactPage
    {
        IWebDriver driver;

        public UpdateContactPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void Update()
        {
            driver.FindElement(By.LinkText("Update Contact Info")).Click();
            driver.FindElement(By.Id("customer.address.city")).Clear();
            driver.FindElement(By.Id("customer.address.city")).SendKeys("HCM Updated");

            driver.FindElement(By.XPath("//input[@value='Update Profile']")).Click();
        }
    }
}