using OpenQA.Selenium;
using System.Threading;

namespace Lab8.Pages
{
    public class FindTransactionsPage
    {
        private readonly IWebDriver _driver;

        // CHỈ GIỮ LẠI MỘT BỘ BIẾN DUY NHẤT DƯỚI ĐÂY
        private readonly By AmountInput = By.Id("criteria.amount");
        private readonly By FindByAmountBtn = By.XPath("//button[@ng-click=\"findTransactions('AMOUNT')\"]");

        public FindTransactionsPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public void FindByAmount(string amount)
        {
            // Xóa trắng ô nhập trước khi điền
            _driver.FindElement(AmountInput).Clear();
            _driver.FindElement(AmountInput).SendKeys(amount);

            // Dừng 2 giây để Vy đọc kịp số tiền đã điền
            Thread.Sleep(2000);

            // Nhấn nút Tìm kiếm
            _driver.FindElement(FindByAmountBtn).Click();
        }
    }
}