using MyClasses;

namespace MyClassesTest;

[TestClass]
public class FileProcessTest
{
    protected string _GoodFileName = "";
    private const string BAD_FILE_NAME = @"C:\Windows\nonExist.exe";
    
    private const string GOOD_FILE_NAME = @"C:\Windows\Regedit.exe";

    protected void SetGoodFileName()
    {
        _GoodFileName = TestContext.Properties["GoodFileName"]?.ToString();
        if (_GoodFileName.Contains("[AppPath]"))
        {
            _GoodFileName = _GoodFileName.Replace("[AppPath]",
                Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData));
        }
    }
    
    public TestContext TestContext { get; set; }    
    
    [TestMethod]
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
    public void FileNameDoesNotExist()
    {
        FileProcess fp = new();
        TestContext.Write($"Checking File {GOOD_FILE_NAME}");
        var fromCall = fp.FileExist(BAD_FILE_NAME);

        Assert.IsFalse(fromCall);
    }
    
    
    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void FileNameNullOrEmpty_UsingAttribute()
    {
        FileProcess fp = new();
        TestContext.Write($"Checking for a null file via [ExpectedException] attribute");
        fp.FileExist("");

    }
    
    [TestMethod]
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