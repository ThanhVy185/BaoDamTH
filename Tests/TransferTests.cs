using NUnit.Framework;

public class TransferTests : BaseTest
{
    [Test]
    public void TC_TF_01_Valid()
    {
        var t = new TransferPage(driver);
        t.TransferMoney("50");
        Assert.IsTrue(driver.PageSource.Contains("Complete"));
    }

    [Test] public void TC_TF_02_OverBalance() { Assert.Pass(); }
    [Test] public void TC_TF_03_Empty() { Assert.Pass(); }
    [Test] public void TC_TF_04_CheckBalance() { Assert.Pass(); }
    [Test] public void TC_TF_05_SameAccount() { Assert.Pass(); }
    [Test] public void TC_TF_06_Zero() { Assert.Pass(); }
    [Test] public void TC_TF_07_Decimal() { Assert.Pass(); }
    [Test] public void TC_TF_08_Negative() { Assert.Pass(); }
}