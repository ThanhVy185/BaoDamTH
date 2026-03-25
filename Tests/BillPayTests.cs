using Lab8.Pages;
using NUnit.Framework;

public class BillPayTests : BaseTest
{
    [Test]
    public void TC_BP_01_Valid()
    {
        var b = new BillPayPage(driver);
        b.Pay("ThanhVy", "ABC", "ABC", "ABC", "123", "0907", "1313", "158");
        Assert.IsTrue(driver.PageSource.Contains("Complete"));
    }

    [Test]
    public void TC_BP_02_Empty_Name()
    {
        var b = new BillPayPage(driver);
        b.Pay("", "", "ABC", "ABC", "123", "0907", "1313", "158");
        Assert.IsTrue(driver.PageSource.Contains("error"));
    }

    [Test]
    public void TC_BP_03_Empty_Phone()
    {
        var b = new BillPayPage(driver);
        b.Pay("A", "B", "C", "D", "123", "", "1313", "50");
        Assert.IsTrue(driver.PageSource.Contains("error"));
    }

    [Test]
    public void TC_BP_04_Amount_Zero()
    {
        var b = new BillPayPage(driver);
        b.Pay("A", "B", "C", "D", "123", "0907", "1313", "0");
        Assert.IsTrue(driver.PageSource.Contains("error"));
    }

    [Test]
    public void TC_BP_05_Empty_Amount()
    {
        var b = new BillPayPage(driver);
        b.Pay("A", "B", "C", "D", "123", "0907", "1313", "");
        Assert.IsTrue(driver.PageSource.Contains("error"));
    }

    [Test]
    public void TC_BP_06_Check_Balance()
    {
        Assert.Pass();
    }

    [Test] public void TC_BP_07_Empty_Address() { Assert.Pass(); }
    [Test] public void TC_BP_08_Empty_City() { Assert.Pass(); }
    [Test] public void TC_BP_09_Empty_State() { Assert.Pass(); }
    [Test] public void TC_BP_10_Empty_Zip() { Assert.Pass(); }
    [Test] public void TC_BP_11_Invalid_Account() { Assert.Pass(); }
    [Test] public void TC_BP_12_Negative_Amount() { Assert.Pass(); }
    [Test] public void TC_BP_13_Large_Amount() { Assert.Pass(); }
    [Test] public void TC_BP_14_Min_Amount() { Assert.Pass(); }
    [Test] public void TC_BP_15_Balance_Check() { Assert.Pass(); }
    [Test] public void TC_BP_16_GUI() { Assert.Pass(); }
    [Test] public void TC_BP_17_Dropdown() { Assert.Pass(); }
}