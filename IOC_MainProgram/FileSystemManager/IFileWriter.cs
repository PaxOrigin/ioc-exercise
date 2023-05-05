namespace FileSystemManager;

public interface IFileWriter
{
    public void WriteToFile(string fileName, string content);
}
