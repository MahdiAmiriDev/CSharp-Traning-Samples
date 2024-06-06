namespace UploaderSample.FileUploadService
{
    public class LocalFIleUploadService : IFileUploaderService
    {
        private readonly Microsoft.Extensions.Hosting.IHostingEnvironment environment;

        public LocalFIleUploadService(Microsoft.Extensions.Hosting.IHostingEnvironment environment)
        {
            this.environment = environment;
        }
        public async Task<string> UploadFileAsync(IFormFile file)
        {
            var filePath = Path.Combine(environment.ContentRootPath, @"wwwroot\images", file.FileName);

            using var fileStream = new FileStream(filePath, FileMode.Create);

            await file.CopyToAsync(fileStream);

            return filePath;
        }
    }
}
