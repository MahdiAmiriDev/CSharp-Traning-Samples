namespace UploaderSample.FileUploadService
{
    public interface IFileUploaderService
    {
        Task<string> UploadFileAsync(IFormFile file);
    }
}
