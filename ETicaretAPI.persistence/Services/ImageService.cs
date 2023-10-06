using ETicaretAPI.application.Abstractions.Services;
using ETicaretAPI.application.UnitOfWorks;
using ETicaretAPI.domain.Entites;
using ETicaretAPI.domain.Entites.Identity;
using ETicaretAPI.persistence.Statics;
using Microsoft.AspNetCore.Http;

namespace ETicaretAPI.persistence.Services
{
    public class ImageService : IImageService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IHttpContextAccessor httpContextAccessor;

        public ImageService(IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor)
        {
            this.unitOfWork = unitOfWork;
            this.httpContextAccessor = httpContextAccessor;
        }

        public async Task<bool> ProductPhotosAddAsync(List<IFormFile> files, Guid productId)
        {
            if (files is not null)
            {
                string folderPath = $@"C:/Users/Casper/Desktop/GitHub Projects/ETicaretAPI/ETicaretAPI.api/wwwroot/Images/{StaticsProperties.ProductImages}";

                foreach (var file in files)
                {
                    var tuple = PathAndFileNameCreate(folderPath);

                    Image image = new()
                    {
                        Path = tuple.filePath,
                        FolderName = StaticsProperties.ProductImages,
                        FileName = tuple.fileName
                    };

                    await unitOfWork.GetWriteRepository<Image>().AddAsync(image);
                    await unitOfWork.GetWriteRepository<Image>().SaveChangesAsync();

                    ImageProduct imageProduct = new();
                    imageProduct.ImageId = image.Id;
                    imageProduct.ProductId = productId;

                    await unitOfWork.GetWriteRepository<ImageProduct>().AddAsync(imageProduct);
                    await unitOfWork.GetWriteRepository<ImageProduct>().SaveChangesAsync();

                    using (var stream = new FileStream(tuple.filePath, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }
                }
                return true;
            }
            return false;
        }

        public async Task<bool> ProductPhotoDeleteAsync(Guid ImageId)
        {
            Image image = await unitOfWork.GetReadRepository<Image>().GetByGuidAsync(ImageId);
            DeleteFolderInProject(image.Path);
            await unitOfWork.GetWriteRepository<Image>().Delete(ImageId);
            await unitOfWork.GetWriteRepository<ImageProduct>().SaveChangesAsync();
            return true;
        }

        public async Task<bool> ProductAndImagesDeleteAsync(Guid productId)
        {
            var productImages = await unitOfWork.GetReadRepository<ImageProduct>().GetAllAsync(ip => ip.ProductId == productId, true, ip => ip.Image);

            List<Image> images = productImages.Select(ip => ip.Image).ToList();//select image

            foreach (var image in images)
            {
                DeleteFolderInProject(image.Path);
            }

            bool result1 = unitOfWork.GetWriteRepository<Image>().DeleteRange(images);
            bool result2 = await unitOfWork.GetWriteRepository<Product>().Delete(productId);
            await unitOfWork.GetWriteRepository<Product>().SaveChangesAsync();
            bool response = result1 == result2 == true ? true : false;
            return response;
        }

        public async Task<List<string>> GetProductImages(Guid productId)
        {
            List<ImageProduct> imageProduct = await unitOfWork.GetReadRepository<ImageProduct>().GetAllAsync(ip => ip.ProductId == productId, true, ip => ip.Image);

            List<string> paths = new();
            foreach (var imageP in imageProduct)
            {
                paths.Add(imageP.Image.Path);
            }
            return paths;
        }

        public async Task<bool> UserProfilePhotoAddAsync(IFormFile file)
        {
            string folderPath = $@"C:/Users/Casper/Desktop/GitHub Projects/ETicaretAPI/ETicaretAPI.api/wwwroot/Images/{StaticsProperties.UserImages}/";

            string userName = httpContextAccessor.HttpContext.Request.HttpContext.User.Identity.Name;
            var userWithImage = await unitOfWork.GetReadRepository<AppUser>().GetAsync(x => x.UserName == userName);
            if (userWithImage.ImageId is null)
            {
                var tuple = PathAndFileNameCreate(folderPath);

                Image image = new()
                {
                    Path = tuple.filePath,
                    FileName = tuple.fileName,
                    FolderName = StaticsProperties.UserImages
                };

                await unitOfWork.GetWriteRepository<Image>().AddAsync(image);
                await unitOfWork.GetWriteRepository<Image>().SaveChangesAsync();

                userWithImage.ImageId = image.Id;
                await unitOfWork.GetWriteRepository<AppUser>().SaveChangesAsync();

                using (var stream = new FileStream(tuple.filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
                return true;
            }
            return false;
        }

        public async Task<bool> UserProfilePhotoDeleteAsync()
        {
            string userName = httpContextAccessor.HttpContext.Request.HttpContext.User.Identity.Name;
            AppUser user = await unitOfWork.GetReadRepository<AppUser>().GetAsync(x => x.UserName == userName, true, x => x.Image);
            if (user.ImageId is not null)
            {
                DeleteFolderInProject(user.Image.Path);
                await unitOfWork.GetWriteRepository<Image>().Delete(user.Image.Id);
                await unitOfWork.GetWriteRepository<Image>().SaveChangesAsync();
                return true;
            }
            return false;
        }

        public void DeleteFolderInProject(string path)
        {
            File.Delete(path);
        }
        public (string fileName, string filePath) PathAndFileNameCreate(string path)
        {
            string fileName = Guid.NewGuid().ToString();
            string filePath = $"{path}/{fileName}.jpg";
            return (fileName, filePath);
        }
    }
}
