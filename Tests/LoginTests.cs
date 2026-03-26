using System;
using System.IO;
using System.Dynamic;
using System.Collections.Generic;
using System.Text.Json;
using NUnit.Framework;

public class LoginTests : BaseTest
{
    // changed from `object` to `JsonHelper` so `Read` is a known member at compile time
    public JsonHelper JsonHelper { get; private set; }

    [SetUp]
    public void InitJsonHelper()
    {
        // initialize helper before each test
        JsonHelper = new JsonHelper();
    }

    [Test]
    public void TC_AUTH_05_Login_Valid()
    {
        var data = JsonHelper.Read("login", "TC05");

        var login = new LoginPage(driver);
        login.Login((string)data.username, (string)data.password);

        Assert.IsTrue(driver.PageSource.Contains("Accounts Overview"));
    }

    [Test]
    public void TC_AUTH_06_WrongPass()
    {
        var data = JsonHelper.Read("login", "TC06");

        var login = new LoginPage(driver);
        login.Login((string)data.username, (string)data.password);

        Assert.IsTrue(driver.PageSource.Contains("could not be verified"));
    }

    [Test]
    public void TC_AUTH_07_NotExist()
    {
        var data = JsonHelper.Read("login", "TC07");

        var login = new LoginPage(driver);
        login.Login((string)data.username, (string)data.password);

        Assert.IsTrue(driver.PageSource.Contains("could not be verified"));
    }

    [Test]
    public void TC_AUTH_08_Empty()
    {
        var data = JsonHelper.Read("login", "TC08");

        var login = new LoginPage(driver);
        login.Login((string)data.username, (string)data.password);

        Assert.IsTrue(driver.PageSource.Contains("Please enter"));
    }

    [Test]
    public void TC_AUTH_10_SQL()
    {
        var data = JsonHelper.Read("login", "TC10");

        var login = new LoginPage(driver);
        login.Login((string)data.username, (string)data.password);

        Assert.IsTrue(driver.PageSource.Contains("could not be verified"));
    }
}

// Minimal JsonHelper implementation.
// Place JSON files in a "TestData" folder adjacent to the test run directory.
// Example file layout: <test-run-dir>/TestData/login.json
// Example content of login.json:
// {
//   "TC05": { "username": "user1", "password": "pass1" },
//   "TC06": { "username": "user1", "password": "wrong" }
// }
public class JsonHelper
{
    // Returns a dynamic object (ExpandoObject) with properties matching the JSON object for the given caseId.
    // If the file or case is missing, returns an empty ExpandoObject.
    public dynamic Read(string section, string caseId)
    {
        var baseDir = AppContext.BaseDirectory ?? Environment.CurrentDirectory;
        var fileName = section + ".json";
        var path = Path.Combine(baseDir, "TestData", fileName);

        if (!File.Exists(path))
        {
            // try an alternate location (project root) to be more resilient during development
            var altPath = Path.Combine(Environment.CurrentDirectory, "TestData", fileName);
            if (File.Exists(altPath))
                path = altPath;
            else
                return new ExpandoObject();
        }

        try
        {
            var json = File.ReadAllText(path);
            using var doc = JsonDocument.Parse(json);
            if (!doc.RootElement.TryGetProperty(caseId, out var caseElement))
            {
                return new ExpandoObject();
            }

            var result = new ExpandoObject() as IDictionary<string, object>;

            if (caseElement.ValueKind == JsonValueKind.Object)
            {
                foreach (var prop in caseElement.EnumerateObject())
                {
                    // Favor string extraction; other kinds can be converted to string as needed.
                    switch (prop.Value.ValueKind)
                    {
                        case JsonValueKind.String:
                            result[prop.Name] = prop.Value.GetString();
                            break;
                        case JsonValueKind.Number:
                            if (prop.Value.TryGetInt64(out var l)) result[prop.Name] = l;
                            else if (prop.Value.TryGetDouble(out var d)) result[prop.Name] = d;
                            else result[prop.Name] = prop.Value.GetRawText();
                            break;
                        case JsonValueKind.True:
                        case JsonValueKind.False:
                            result[prop.Name] = prop.Value.GetBoolean();
                            break;
                        case JsonValueKind.Null:
                            result[prop.Name] = null;
                            break;
                        default:
                            // For arrays or nested objects, return raw JSON string
                            result[prop.Name] = prop.Value.GetRawText();
                            break;
                    }
                }
            }

            return result;
        }
        catch
        {
            // On any parse/read error return an empty object to avoid blowing up tests for missing data.
            return new ExpandoObject();
        }
    }
}