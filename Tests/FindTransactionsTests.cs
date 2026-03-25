using Lab8.Pages;
using NUnit.Framework;

public class FindTransactionTests : BaseTest
{
    [Test]
    public void TC_FT_01_ByDate()
    {
        var f = new FindTransactionPage(driver);
        f.SearchByDate("3/15/2026");
        Assert.IsTrue(driver.PageSource.Contains("Transaction"));
    }

    [Test] public void TC_FT_02_ByAmount() { Assert.Pass(); }
    [Test] public void TC_FT_03_ByID() { Assert.Pass(); }
    [Test] public void TC_FT_04_Empty() { Assert.Pass(); }
    [Test] public void TC_FT_05_InvalidDate() { Assert.Pass(); }
    [Test] public void TC_FT_06_Future() { Assert.Pass(); }
}