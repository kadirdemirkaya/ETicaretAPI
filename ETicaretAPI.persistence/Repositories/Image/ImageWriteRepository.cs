using ETicaretAPI.application.Repositories;
using ETicaretAPI.domain.Entites;
using ETicaretAPI.persistence.Data;

namespace ETicaretAPI.persistence.Repositories
{
    public class ImageWriteRepository : WriteRepository<Image>, IImageWriteRepository
    {
        public ImageWriteRepository(ETicaretAPIProjectDbContext context) : base(context)
        {
        }
    }
}
