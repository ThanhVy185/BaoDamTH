using NUnit.Framework;
using Lab8.Pages;
using Lab8.Utilities;

namespace Lab8.Tests
{
    [TestFixture]
    public class RegisterTests : BaseTest
    {
        [Test]
        public void TC_AUTH_01_Valid()
        {
            // Mở trang đăng ký trực tiếp từ Driver
            Driver.Navigate().GoToUrl("https://parabank.parasoft.com/parabank/register.htm");

            var page = new RegisterPage(Driver); // Sửa thành Driver (viết hoa)

            // Dùng hàm FillRegistrationForm mình đã viết ở các lượt trước
            // Hoặc nếu muốn truyền lẻ từng tham số, bạn phải sửa lại RegisterPage.cs
            page.FillRegistrationForm(new
            {
                FirstName = "Sang",
                LastName = "Tran",
                Address = "123 Ly Thuong Kiet",
                City = "HCM",
                State = "HCM",
                ZipCode = "577584374",
                Phone = "4673466448",
                SSN = "123456789",
                Username = "sang3107",
                Password = "password123"
            });

            Assert.That(Driver.PageSource.Contains("Your account was created successfully"), Is.True);
        }

        [Test]
        public void TC_AUTH_02_Empty()
        {
            Driver.Navigate().GoToUrl("https://parabank.parasoft.com/parabank/register.htm");
            var page = new RegisterPage(Driver);

            page.FillRegistrationForm(new
            {
                FirstName = "",
                LastName = "",
                Address = "",
                City = "",
                State = "",
                ZipCode = "",
                Phone = "",
                SSN = "",
                Username = "",
                Password = ""
            });

            Assert.That(Driver.PageSource.Contains("is required"), Is.True);
        }

        [Test]
        public void TC_AUTH_03_Invalid_SSN()
        {
            Driver.Navigate().GoToUrl("https://parabank.parasoft.com/parabank/register.htm");
            var page = new RegisterPage(Driver);

            page.FillRegistrationForm(new
            {
                FirstName = "Sang",
                LastName = "Tran",
                Address = "123",
                City = "HCM",
                State = "HCM",
                ZipCode = "123",
                Phone = "123",
                SSN = "abc",
                Username = "user1",
                Password = "123"
            });

            // ParaBank thường không báo lỗi ngay mà để server xử lý, 
            // nên check từ khóa "error" hoặc thông báo lỗi cụ thể
            Assert.That(Driver.PageSource.ToLower().Contains("error"), Is.True);
        }

    }
}