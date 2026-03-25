using NUnit.Framework;

public class RegisterTests : BaseTest
{
    [Test]
    public void TC_AUTH_01_Valid()
    {
        var page = new RegisterPage(driver);
        page.GoToRegister();

        page.Register("Sang", "Tran", "123 Ly Thuong Kiet",
            "HCM", "HCM", "577584374",
            "4673466448", "123456789",
            "sang3107", "password123", "password123");

        Assert.IsTrue(driver.PageSource.Contains("Your account was created successfully"));
    }

    [Test]
    public void TC_AUTH_02_Empty()
    {
        var page = new RegisterPage(driver);
        page.GoToRegister();

        page.Register("", "", "", "", "", "", "", "", "", "", "");

        Assert.IsTrue(driver.PageSource.Contains("is required"));
    }

    [Test]
    public void TC_AUTH_03_Invalid_SSN()
    {
        var page = new RegisterPage(driver);
        page.GoToRegister();

        page.Register("Sang", "Tran", "123",
            "HCM", "HCM", "123",
            "123", "abc",
            "user1", "123", "123");

        Assert.IsTrue(driver.PageSource.Contains("error"));
    }

    [Test]
    public void TC_AUTH_04_Invalid_Phone()
    {
        var page = new RegisterPage(driver);
        page.GoToRegister();

        page.Register("Sang", "Tran", "123",
            "HCM", "HCM", "123",
            "abc@@@", "123",
            "user2", "123", "123");

        Assert.IsTrue(driver.PageSource.Contains("error"));
    }
}