using NUnit.Framework;

public class OpenAccountTests : BaseTest
{
    [Test]
    public void TC_AUTH_17_Open_Checking()
    {
        var login = new LoginPage(driver);
        login.Login("sang3107", "password123");

        var open = new OpenAccountPage(driver);
        open.OpenAccount("CHECKING");

        Assert.IsTrue(driver.PageSource.Contains("Account Opened"));
    }

    [Test]
    public void TC_AUTH_18_Open_Saving()
    {
        var login = new LoginPage(driver);
        login.Login("sang3107", "password123");

        var open = new OpenAccountPage(driver);
        open.OpenAccount("SAVINGS");

        Assert.IsTrue(driver.PageSource.Contains("Account Opened"));
    }
}