using OpenQA.Selenium;
using System;
using System.IO;

namespace Lab8.Utilities
{
    public class ScreenshotHelper
    {
        public static string TakeScreenshot(IWebDriver driver, string testName)
        {
            string folder = @"C:\Users\NITRO5\OneDrive - Ho Chi Minh City University of Foreign Languages and Information Technology - HUFLIT\Pictures\baodam";

            Directory.CreateDirectory(folder);

            string fileName = $"{testName}_{DateTime.Now.Ticks}.png";
            string path = Path.Combine(folder, fileName);

            Screenshot screenshot = ((ITakesScreenshot)driver).GetScreenshot();
            screenshot.SaveAsFile(path);

            return path;
        }
    }
}