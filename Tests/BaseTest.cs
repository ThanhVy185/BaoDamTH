using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

// CẤU HÌNH ĐỂ BẤM RUN ALL KHÔNG BỊ LỖI (Chạy lần lượt từng cái)
[assembly: LevelOfParallelism(1)]
[assembly: Parallelizable(ParallelScope.Fixtures)]

namespace Lab8.Tests
{
    public class BaseTest
    {
        protected IWebDriver Driver;

        [SetUp]
        public void Init()
        {
            // Tắt các dòng log dư thừa của Chrome cho sạch máy
            var options = new ChromeOptions();
            options.AddArgument("--silent");
            options.AddArgument("disable-infobars");

            Driver = new ChromeDriver(options);
            Driver.Manage().Window.Maximize();
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);

            // Luôn bắt đầu từ trang chủ
            Driver.Navigate().GoToUrl("https://parabank.parasoft.com/parabank/index.htm");
        }

        [TearDown]
        public void CleanUp()
        {
            // Kiểm tra xem Test vừa chạy có bị lỗi (Fail) không
            if (TestContext.CurrentContext.Result.Outcome.Status == NUnit.Framework.Interfaces.TestStatus.Failed)
            {
                // Nếu lỗi, gọi cái ScreenshotHelper của Vy để chụp lại màn hình lúc đó
                string testName = TestContext.CurrentContext.Test.Name;
                string path = Utilities.ScreenshotHelper.TakeScreenshot(Driver, testName);

                // In đường dẫn ra màn hình console để Vy dễ tìm ảnh
                Console.WriteLine($"Test FAILED! Ảnh chụp màn hình tại: {path}");
            }

            if (Driver != null)
            {
                Driver.Quit();
                Driver.Dispose();
            }
        }
    }
}