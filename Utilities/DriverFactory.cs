using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;


namespace Lab8.Utilities // Đảm bảo có namespace để các class khác tìm thấy [cite: 40, 41]
{
    public class DriverFactory
    {
        private static IWebDriver driver;

        // Đổi tên thành CreateDriver để khớp với các file Test bạn đang viết
        public static IWebDriver CreateDriver()
        {
            if (driver == null)
            {
                driver = new ChromeDriver();
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10); // Thêm đợi ngầm định để tránh lỗi không tìm thấy element [cite: 68]
                driver.Manage().Window.Maximize();
            }
            return driver;
        }

        public static void QuitDriver()
        {
            if (driver != null)
            {
                driver.Quit();
                driver = null;
            }
        }
    }
}