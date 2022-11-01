using MyClasses;

namespace MyClassesTest;

[TestClass]
public class FileProcessOtherTest: TestBase
{
    #region Class Initialization and Cleanup
    [ClassInitialize()]
    public static void SomethingElse(TestContext tc)
    {
        // TODO: Do class initialization...
        tc.WriteLine("In ClassInitialize() method");
    }

    /**
     * Test context is gone by the time of cleanup
     */
    [ClassCleanup]
    public static void ClassCleanup()
    {
        // TODO: do class clean up...
        
    }
    
    #endregion

    #region TestInitialization and Cleanup
    [TestInitialize]
    public void TestInitialize()
    {
        _GoodFileName = "FileToDeploy.txt";
        TestContext.WriteLine("TestInitialize() method called...");
        WriteDescription(this.GetType());
    }
    
    [TestCleanup]
    public void TestCleanup()
    {
        TestContext.WriteLine("TestCleanup() method ...");
    }
    #endregion

    [TestMethod]
    public void AreSameTest()
    {
        FileProcess fp1 = new();
        FileProcess fp2 = new();
        
        Assert.AreNotSame(fp1, fp2);
    }

    [TestMethod]
    public void AreEqualTest()
    {
        var str1 = "Paul";
        var str2 = "paul";
        
        Assert.AreEqual(str1, str2, true,$"{str1} and {str2} are not equal");
    }

    [TestMethod]
    public void FileNameDoesExistSimpleMessage()
    {
        FileProcess fp = new();
        bool fromCall;

        fromCall = fp.FileExist(_GoodFileName);
        
        Assert.IsTrue(fromCall, "File: {0} does not exist", _GoodFileName);
    }
    
}