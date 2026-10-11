using Microsoft.AspNetCore.Mvc;
using Server.Services;

namespace Server.Controllers;

[ApiController]
[Route("[controller]")]
public class ApiController : ControllerBase
{
    private readonly FileService _fileService;
    
    public ApiController(FileService fileService)
    {
        _fileService = fileService;
    }
    
    [HttpGet("GetFiles")]
    public IEnumerable<string?> GetFiles()
    {
        var files = _fileService.GetFiles();

        HttpContext.Response.Headers.Append("Access-Control-Allow-Origin", "http://localhost:63343");
        
        return files;
    }

    [HttpGet("DownloadFile")]
    public async Task<IFormFile>? DownloadFile(string fileName)
    {
        HttpContext.Response.Headers.Append("Access-Control-Allow-Origin", "http://localhost:63343");
        
        var file = await _fileService.DownloadFileAsync(fileName);
        
        return file;
    }
    
    [HttpPost]
    public async Task<IActionResult> UploadFile(IFormFile file)
    {
        HttpContext.Response.Headers.Append("Access-Control-Allow-Origin", "http://localhost:63343");
        
        await _fileService.SavefileAsync(file);
        return Ok();
    }
}