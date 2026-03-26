using NUnit.Framework;

public class ProfileTests : BaseTest
{
    [Test]
    public void TC_AUTH_01_Valid_Update()
    {
        var p = new ProfilePage(driver);
        p.UpdateProfile("ThanhVy", "Nguyen", "123", "ABC", "ABC", "123", "123");
        Assert.IsTrue(driver.PageSource.Contains("Profile Updated"));
    }

    [Test]
    public void TC_AUTH_02_Empty_All()
    {
        var p = new ProfilePage(driver);
        p.UpdateProfile("", "", "", "", "", "", "");
        Assert.IsTrue(driver.PageSource.Contains("error"));
    }

    [Test]
    public void TC_AUTH_03_Special_Name()
    {
        var p = new ProfilePage(driver);
        p.UpdateProfile("Thanh@@", "Nguyen", "123", "ABC", "ABC", "123", "123");
        Assert.IsTrue(driver.PageSource.Contains("error"));
    }

    [Test]
    public void TC_AUTH_04_Max_Phone()
    {
        var p = new ProfilePage(driver);
        p.UpdateProfile("ThanhVy", "Nguyen", "123", "ABC", "ABC", "123", "999999999999");
        Assert.IsTrue(driver.PageSource.Contains("error"));
    }

    [Test]
    public void TC_AUTH_05_Alpha_Phone()
    {
        var p = new ProfilePage(driver);
        p.UpdateProfile("ThanhVy", "Nguyen", "123", "ABC", "ABC", "123", "0123abc");
        Assert.IsTrue(driver.PageSource.Contains("error"));
    }

    [Test]
    public void TC_AUTH_06_Special_Phone()
    {
        var p = new ProfilePage(driver);
        p.UpdateProfile("ThanhVy", "Nguyen", "123", "ABC", "ABC", "123", "123@");
        Assert.IsTrue(driver.PageSource.Contains("error"));
    }

    [Test]
    public void TC_AUTH_07_Empty_Phone()
    {
        var p = new ProfilePage(driver);
        p.UpdateProfile("ThanhVy", "Nguyen", "123", "ABC", "ABC", "123", "");
        Assert.IsTrue(driver.PageSource.Contains("error"));
    }

    [Test]
    public void TC_AUTH_08_Invalid_City()
    {
        var p = new ProfilePage(driver);
        p.UpdateProfile("ThanhVy", "Nguyen", "123", "ABC123", "ABC", "123", "123");
        Assert.IsTrue(driver.PageSource.Contains("error"));
    }
}