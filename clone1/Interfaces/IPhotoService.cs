
using CloudinaryDotNet.Actions;

namespace clone1.Interfaces;

public interface IPhotoService
{
    public Task<ImageUploadResult> AddPhotoAsync(IFormFile file);
    public Task<DeletionResult> DeletePhotoAsync(string publicUrl);
}