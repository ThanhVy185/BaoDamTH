using System;
using System.IO;
using System.Dynamic;
using System.Collections.Generic;
using System.Text.Json;
using NUnit.Framework;
using Lab8.Pages;   // Thêm cái này để nhận diện LoginPage
using Lab8.Tests;   // Thêm cái này để nhận diện BaseTest

namespace Lab8.Tests
{
    [TestFixture]
    public class LoginTests : BaseTest
    {
        // Khai báo helper
        private JsonHelperLocal _jsonHelper;

        [SetUp]
        public void InitJsonHelper()
        {
            _jsonHelper = new JsonHelperLocal();
        }

        [Test]
        public void TC_AUTH_05_Login_Valid()
        {
            // Sửa driver -> Driver (viết hoa chữ D)
            var data = _jsonHelper.Read("login", "TC05");

            var login = new LoginPage(Driver);
            login.Login((string)data.username, (string)data.password);

            // Sửa Assert.IsTrue -> Assert.That(..., Is.True)
            Assert.That(Driver.PageSource.Contains("Accounts Overview"), Is.True);
        }

        [Test]
        public void TC_AUTH_06_WrongPass()
        {
            var data = _jsonHelper.Read("login", "TC06");

            var login = new LoginPage(Driver);
            login.Login((string)data.username, (string)data.password);

            Assert.That(Driver.PageSource.Contains("could not be verified"), Is.True);
        }

        [Test]
        public void TC_AUTH_07_NotExist()
        {
            var data = _jsonHelper.Read("login", "TC07");

            var login = new LoginPage(Driver);
            login.Login((string)data.username, (string)data.password);

            Assert.That(Driver.PageSource.Contains("could not be verified"), Is.True);
        }

        [Test]
        public void TC_AUTH_08_Empty()
        {
            var data = _jsonHelper.Read("login", "TC08");

            var login = new LoginPage(Driver);
            login.Login((string)data.username, (string)data.password);

            Assert.That(Driver.PageSource.Contains("Please enter"), Is.True);
        }

        [Test]
        public void TC_AUTH_10_SQL()
        {
            var data = _jsonHelper.Read("login", "TC10");

            var login = new LoginPage(Driver);
            login.Login((string)data.username, (string)data.password);

            Assert.That(Driver.PageSource.Contains("could not be verified"), Is.True);
        }
    }

    // Đổi tên thành JsonHelperLocal để tránh trùng với file JsonHelper.cs trong Utilities
    public class JsonHelperLocal
    {
        public dynamic Read(string section, string caseId)
        {
            var baseDir = AppContext.BaseDirectory ?? Environment.CurrentDirectory;
            var fileName = section + ".json";
            var path = Path.Combine(baseDir, "TestData", fileName);

            if (!File.Exists(path)) return new ExpandoObject();

            try
            {
                var json = File.ReadAllText(path);
                using var doc = JsonDocument.Parse(json);
                if (!doc.RootElement.TryGetProperty(caseId, out var caseElement)) return new ExpandoObject();

                var result = new ExpandoObject() as IDictionary<string, object>;
                foreach (var prop in caseElement.EnumerateObject())
                {
                    result[prop.Name] = prop.Value.ValueKind == JsonValueKind.String ? prop.Value.GetString() : prop.Value.GetRawText();
                }
                return result;
            }
            catch { return new ExpandoObject(); }
        }
    }
}