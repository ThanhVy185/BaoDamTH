using OpenQA.Selenium;
using Lab8.Utilities;

namespace Lab8.Pages
{
    public class TransferFundsPage
    {
        private IWebDriver driver;

        public TransferFundsPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        private By transferLink = By.LinkText("Transfer Funds");
        private By amount = By.Id("amount");
        private By transferBtn = By.XPath("//input[@value='Transfer']");
        private By successMsg = By.XPath("//h1[contains(text(),'Transfer Complete')]");

        public void Transfer(string money)
        {
            driver.FindElement(transferLink).Click();
            ScreenshotHelper.TakeScreenshot(driver, "Step1_Click");

            driver.FindElement(amount).SendKeys(money);
            ScreenshotHelper.TakeScreenshot(driver, "Step2_Input");

            driver.FindElement(transferBtn).Click();
            ScreenshotHelper.TakeScreenshot(driver, "Step3_Submit");
        }

        public bool IsTransferSuccessful()
        {
            return driver.FindElement(successMsg).Displayed;
        }
    }
}