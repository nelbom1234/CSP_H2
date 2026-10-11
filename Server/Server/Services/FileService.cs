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

    public async Task<IFormFile> DownloadFileAsync(string fileName)
    {
        await using var stream = new FileStream(Path.Combine(_fileBasePath, fileName), FileMode.Open);
        return new FormFile(stream, 0, stream.Length, fileName, Path.GetFileName(fileName))
        {
            Headers =  new HeaderDictionary(),
            ContentDisposition = "attachment; filename=" + fileName,
        };
    }

    public async Task SavefileAsync(IFormFile file)
    {
        await using var stream = new FileStream(Path.Combine(_fileBasePath, file.FileName), FileMode.Create);
        await file.CopyToAsync(stream);
    }
}