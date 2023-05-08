namespace FileSystemManager;

public abstract class FileSystemWorkerBase
{
    protected readonly string _currentDirectory = null!;

    public FileSystemWorkerBase(string? filePath)
    {
        _currentDirectory = filePath;
        if (!Directory.Exists(filePath))
            _currentDirectory = Path.GetTempPath();
    }
}
