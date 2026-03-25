using OpenQA.Selenium;
using Lab8.Utilities;

namespace Lab8.Pages
{
    public class BillPayPage
    {
        IWebDriver driver;

        public BillPayPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void PayBill()
        {
            driver.FindElement(By.LinkText("Bill Pay")).Click();

            driver.FindElement(By.Name("payee.name")).SendKeys("Test");
            DelayHelper.Sleep(300);
            driver.FindElement(By.Name("payee.address.street")).SendKeys("HCM");
            DelayHelper.Sleep(300);
            driver.FindElement(By.Name("payee.address.city")).SendKeys("HCM");
            DelayHelper.Sleep(300);
            driver.FindElement(By.Name("payee.address.state")).SendKeys("HCM"); 
            DelayHelper.Sleep(300);
            driver.FindElement(By.Name("payee.address.zipCode")).SendKeys("70000");
            DelayHelper.Sleep(300);
            driver.FindElement(By.Name("payee.phoneNumber")).SendKeys("0123");
            DelayHelper.Sleep(300);
            driver.FindElement(By.Name("payee.accountNumber")).SendKeys("123");
            DelayHelper.Sleep(300);
            driver.FindElement(By.Name("verifyAccount")).SendKeys("123");
            DelayHelper.Sleep(300);
            driver.FindElement(By.Name("amount")).SendKeys("10");
            DelayHelper.Sleep(300);

            driver.FindElement(By.XPath("//input[@value='Send Payment']")).Click();
        }
    }
}