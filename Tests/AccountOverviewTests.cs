using NUnit.Framework;

public class AccountOverviewTests : BaseTest
{
    [Test]
    public void TC_AUTH_13_ViewBalance()
    {
        var login = new LoginPage(driver);
        login.Login("sang3107", "password123");

        var page = new AccountOverviewPage(driver);
        page.GoToOverview();

        Assert.IsTrue(page.GetBalance().Length > 0);
    }
}