namespace FileSystemManager;

public abstract class FileSystemWorkerBase
{
    protected readonly string _currentDirectory = null!;

    public FileSystemWorkerBase()
    {
        _currentDirectory = Directory.GetCurrentDirectory();
    }
}
