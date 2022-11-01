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
        WriteDescription(this.GetType());
    }


    [TestCleanup]
    public void TestCleanup()
    {
        TestContext.WriteLine("TestCleanup() method ...");
    }

    [TestMethod]
    [DeploymentItem("FileToDeploy.txt")]
    [DataRow("FileToDeploy.txt", DisplayName = "Check if FileToDeploy.txt exist")]
    public void CheckFileExist(string fileName)
    {
        FileProcess fp = new();
        fp.FileExist(fileName);
    }

    [TestMethod]
    [DataRow(1,1, DisplayName = "1 and 1")]
    [DataRow(1,1, DisplayName = "2 and 2")]
    public void AreNumbersEqual(int a, int b)
    {
        Assert.AreEqual(a, b);
    }
    
    [TestMethod]
    [Timeout(5000)]
    public void SimulateTimeout()
    {
        Thread.Sleep(4000);
    }
    
    [TestMethod]
    [Description("Check to see if a file exist")]
    [Owner("BenWhite")]
    [Priority(1)]
    [TestCategory("NoException")]
    [Ignore]
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
    [Owner("Dan")]
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
    [Owner("BenWhite")]
    public void FileNameNullOrEmpty_UsingAttribute()
    {
        FileProcess fp = new();
        TestContext.Write($"Checking for a null file via [ExpectedException] attribute");
        fp.FileExist("");

    }
    
    [TestMethod]
    [Owner("Dan")]
    [Description("Check to see if a filename is null via try-catch")]
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