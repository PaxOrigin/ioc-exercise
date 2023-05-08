using System.Text;

namespace FileSystemManager;

public class FileWriter : FileSystemWorkerBase, IFileWriter
{

    public FileWriter(string? path) : base(path)
    {

    }

    public void WriteToFile(string fileName, string content)
    {
        StringBuilder filepath = new StringBuilder();
        filepath.Append(_currentDirectory);
        filepath.Append('/');
        filepath.Append(fileName);
        File.WriteAllText(filepath.ToString(), content);
    }
}
