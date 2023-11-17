using Microsoft.AspNetCore.Mvc;

namespace EFCoreRelationshipPractice.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FileController : ControllerBase
    {
        private const string TEXT_FOLDER = "txt";
        private readonly IHostEnvironment _hostEnvironment;

        public FileController(IHostEnvironment hostEnvironment)
        {
            _hostEnvironment = hostEnvironment;
        }

        [HttpGet("download-apk")]
        public async Task<IActionResult> DownloadFile()
        {
            var rootPath = _hostEnvironment.ContentRootPath;
            var apkPath = Path.Combine(rootPath, TEXT_FOLDER);
            var directory = new DirectoryInfo(apkPath);
            var latestAPKFile = directory.GetFiles()
                         .OrderByDescending(f => f.Name)
                         .First();

            if (!latestAPKFile.Exists)
            {
                return NotFound();
            }

            var file = File(System.IO.File.ReadAllBytes(latestAPKFile.FullName), "application/octet-stream", "Test1234.txt");
            return file;
        }

    }
}
