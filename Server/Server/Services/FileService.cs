namespace Server.Services;

public class FileService
{
    private readonly string _fileBasePath = Path.Combine(Directory.GetCurrentDirectory(), "Files");

    public IEnumerable<string?> GetFiles()
    {
        var files = Directory.GetFiles(_fileBasePath).Select(Path.GetFileName);

        return files;
    }

    public void DeleteFile(string file)
    {
        File.Delete(Path.Combine(_fileBasePath, file));
    }
}