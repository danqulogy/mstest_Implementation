using System.Text.RegularExpressions;

namespace MyClassesTest;

[TestClass]
public class StringAssertClassTest
{
    
    [TestMethod]
    public void IsAllLowerCaseTest()
    {
        Regex regex = new Regex(@"^([^A-Z])+$");
        StringAssert.Matches("all are lower case", regex);
    }

    [TestMethod]
    public void StartsWithTest()
    {
        var name = "Bernard Danquah White";
        StringAssert.StartsWith(name, "Be");
    }
    
    [TestMethod]
    public void ContainsTest()
    {
        var name = "Bernard Danquah White";
        StringAssert.Contains(name, "white", StringComparison.CurrentCultureIgnoreCase);
    }
}