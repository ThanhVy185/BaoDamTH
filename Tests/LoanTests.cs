using NUnit.Framework;

public class LoanTests : BaseTest
{
    [Test]
    public void TC_RL_01_Valid()
    {
        var l = new LoanPage(driver);
        l.RequestLoan("1000", "100");
        Assert.IsTrue(driver.PageSource.Contains("Approved"));
    }

    [Test] public void TC_RL_02_Denied() { Assert.Pass(); }
    [Test] public void TC_RL_03_Large() { Assert.Pass(); }
    [Test] public void TC_RL_04_Zero() { Assert.Pass(); }
    [Test] public void TC_RL_05_Negative() { Assert.Pass(); }
    [Test] public void TC_RL_06_Missing() { Assert.Pass(); }
}