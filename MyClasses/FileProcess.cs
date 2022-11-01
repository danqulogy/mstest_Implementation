namespace MyClasses;

public class FileProcess
{
    public bool FileExist(string filename)
    {
        if (string.IsNullOrEmpty(filename))
        {
            throw new ArgumentNullException(nameof(filename));
        }
        return File.Exists(filename);
    }
}