using System.Reflection;

namespace MyClassesTest;

[TestClass]
public class TestBase
{
    protected string _GoodFileName = "";
    
    protected TestContext TestContext { get; set; }

    protected void WriteDescription(Type type)
    {
        string testName = TestContext.TestName;
        
        // Find the TestMethod currently executing
        MemberInfo method = type.GetMethod(testName);
        if (method != null)
        {
            // See if Description Attribute exist on this Method
            Attribute att = method.GetCustomAttribute(typeof(DescriptionAttribute));
            if (att != null)
            {
                // Cast attribute to DescriptionAttribute
                DescriptionAttribute dattr = (DescriptionAttribute)att;
                TestContext.WriteLine("Test Description: "+ dattr.Description);
            }
        }
    } 
    protected void SetGoodFileName()
    {
        _GoodFileName = TestContext.Properties["GoodFileName"]?.ToString();
        if (_GoodFileName.Contains("[AppPath]"))
        {
            _GoodFileName = _GoodFileName.Replace("[AppPath]",
                Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData));
        }
    }

}