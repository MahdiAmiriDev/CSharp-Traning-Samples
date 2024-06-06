using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UploaderSample.FileUploadService;

namespace UploaderSample.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IFileUploaderService _fileUploaderService;
        public string FilePath;
        public IndexModel(ILogger<IndexModel> logger, IFileUploaderService fileUploaderService)
        {
            _logger = logger;
            _fileUploaderService = fileUploaderService;
        }

        public void OnGet()
        {

        }

        public async Task OnPostAsync(IFormFile file)
        {
            if(file != null)
                FilePath = await _fileUploaderService.UploadFileAsync(file);
        }
    }
}