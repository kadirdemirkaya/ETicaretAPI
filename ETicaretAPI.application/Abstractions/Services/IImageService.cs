using Microsoft.AspNetCore.Http;

namespace ETicaretAPI.application.Abstractions.Services
{
    public interface IImageService
    {
        Task<bool> UserProfilePhotoAddAsync(IFormFile file);
        Task<bool> UserProfilePhotoDeleteAsync();

        Task<bool> ProductPhotosAddAsync(List<IFormFile> files, Guid productId);

        Task<bool> ProductPhotoDeleteAsync(Guid ImageId);

        Task<bool> ProductAndImagesDeleteAsync(Guid productId);

        Task<List<string>> GetProductImages(Guid productId);
    }
}
