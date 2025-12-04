using ChequeBook.Application;
using ChequeBook.Application.Dtos;
using ChequeBook.Application.Interface;

using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CheckBookPrinter.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ChequeController : Controller
    {

        private readonly IBankInfo _bankinfo;
        private readonly string _imagePath;
        public ChequeController(IConfiguration configuration, IBankInfo bankinfo)
        {
            _bankinfo = bankinfo;
            _imagePath = configuration["ImageStorage:TokenImagePath"] ?? string.Empty;
        }


        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> BankInfo()
        {
            var banklist = await _bankinfo.GetBankList();
            return View(banklist);
        }

        [HttpPost]
        public async Task<IActionResult> SaveBank(IFormFile BankImage, string BankName, int Status)
        {
            byte[]? fileBytes = null;
            string? fileName = null;
            if (BankImage != null && BankImage.Length > 0)
            {
                fileName = Guid.NewGuid() + Path.GetExtension(BankImage.FileName);
                using var ms = new MemoryStream();
                await BankImage.CopyToAsync(ms);
                fileBytes = ms.ToArray();
            }

            var dto = new BankSaveInfoDto
            {
                BankName = BankName,
                BankImage = fileBytes,
                FileName = fileName,
                Status = Status
            };

            var  result= await _bankinfo.SaveBankInfo(dto);

            return Ok(new { success = result.Status, message=result.Message });
        }




        private string GetFileType(string fileName)
        {
            var ext = Path.GetExtension(fileName)?.ToLower();
            var imageExts = new[] { ".jpg", ".jpeg", ".png", ".gif", ".bmp", ".webp" };
            var videoExts = new[] { ".mp4", ".avi", ".mov", ".mkv" };

            if (imageExts.Contains(ext)) return "image";
            if (videoExts.Contains(ext)) return "video";
            return "other";
        }

        [HttpGet("GetImage/{fileName}")]
        public IActionResult GetImage(string fileName)
        {
            if (string.IsNullOrWhiteSpace(fileName))
                return BadRequest("File name is required.");

            var path = Path.Combine(_imagePath, fileName);

            if (!System.IO.File.Exists(path))
                return NotFound("/images/placeholder.png");

            var mimeType = Path.GetExtension(fileName).ToLower() switch
            {
                ".png" => "image/png",
                ".jpg" => "image/jpeg",
                ".jpeg" => "image/jpeg",
                ".gif" => "image/gif",
                ".bmp" => "image/bmp",
                ".webp" => "image/webp",
                ".mp4" => "video/mp4",
                ".avi" => "video/x-msvideo",
                ".mov" => "video/quicktime",
                ".mkv" => "video/x-matroska",
                _ => "application/octet-stream"
            };

            Response.Headers["Cache-Control"] = "public,max-age=3600"; // Cache 1 hour
            return PhysicalFile(path, mimeType);
        }


    }
}
