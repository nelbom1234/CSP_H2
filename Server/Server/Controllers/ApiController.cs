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
    
    // GET
    [HttpGet("GetFiles")]
    public IEnumerable<string?> GetFiles()
    {
        return _fileService.GetFiles();
    }

    [HttpPost]
    public IActionResult UploadFile(IFormFile file)
    {
        
    }
}