namespace MyClassesTest;


[TestClass]
public class MyClassesTestInitialization
{
    
    [AssemblyInitialize]
    public static void AssemblyInitialize(TestContext tc)
    {
        // TODO: Initialize all test within an assembly
        tc.WriteLine("In AssemblyInitialize() method...");
    }

    [AssemblyCleanup]
    public static void AssemblyCleanup()
    {
        // TODO: Clean assembly test
        Console.WriteLine("Cleaning up assembly...");
    }
}