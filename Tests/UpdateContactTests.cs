using NUnit.Framework;
using Lab8.Pages;
using Lab8.Utilities;
using System.Collections.Generic;

namespace Lab8.Tests
{
    [TestFixture]
    public class UpdateContactTests : BaseTest
    {
        [Test]
        public void TC_UP_01_ValidUpdate()
        {
            // Login và vào trang Update
            new LoginPage(Driver).Login("sang3107", "password123");
            Driver.Navigate().GoToUrl("https://parabank.parasoft.com/parabank/updateprofile.htm");

            // Đọc dữ liệu từ JSON (Không dùng dynamic)
            Dictionary<string, string> data = JsonHelper.ReadData("updateContact.json", "TC_UP_01");

            var page = new UpdateContactPage(Driver);

            // Truy xuất dữ liệu theo Key
            page.UpdateInfo(
                data["FirstName"],
                data["Address"],
                data["City"],
                data["Phone"]
            );

            Assert.That(Driver.PageSource.Contains("Profile Updated Successfully"), Is.True);
        }
    }
}