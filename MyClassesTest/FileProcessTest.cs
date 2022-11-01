using MyClasses;

namespace MyClassesTest;

[TestClass]
public class FileProcessTest: TestBase
{
   
    private const string BAD_FILE_NAME = @"C:\Windows\nonExist.exe";
    
    private const string GOOD_FILE_NAME = @"C:\Windows\Regedit.exe";


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


    [TestInitialize]
    public void TestInitialize()
    {
        TestContext.WriteLine("TestInitialize() method called...");
    }


    [TestCleanup]
    public void TestCleanup()
    {
        TestContext.WriteLine("TestCleanup() method ...");
    }
  
    
    [TestMethod]
    [Description("Check to see if a file exist")]
    public void FileNameDoesExist()
    {
        FileProcess fp = new();
        if (!string.IsNullOrEmpty(_GoodFileName))
        {
            File.AppendAllText(_GoodFileName, "Some text");
        }
        
        TestContext.Write($"Checking File {_GoodFileName}");
        var fromCall = fp.FileExist(GOOD_FILE_NAME);
        
        Assert.IsTrue(fromCall);
    }
    
    [TestMethod]
    [Description("Check to see if a file does not exist")]
    public void FileNameDoesNotExist()
    {
        FileProcess fp = new();
        TestContext.Write($"Checking File {GOOD_FILE_NAME}");
        var fromCall = fp.FileExist(BAD_FILE_NAME);

        Assert.IsFalse(fromCall);
    }
    
    
    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    [Description("Check to see if a filename is null via attributes")]
    public void FileNameNullOrEmpty_UsingAttribute()
    {
        FileProcess fp = new();
        TestContext.Write($"Checking for a null file via [ExpectedException] attribute");
        fp.FileExist("");

    }
    
    [TestMethod]
    [Description("Check to see if a filename is null via trycatch")]
    public void FileNameNullOrEmpty_TryCatch()
    {
        FileProcess fp = new();
        try
        {
            TestContext.Write($"Checking for a null file via TryCatch block");
            fp.FileExist("");
        }
        catch (ArgumentNullException e)
        {
           return;
        }
        Assert.Fail("Call to FileExists() did not throw an exception");
    }
    
}