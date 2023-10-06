using ETicaretAPI.application.Repositories;
using ETicaretAPI.domain.Entites;
using ETicaretAPI.persistence.Data;

namespace ETicaretAPI.persistence.Repositories
{
    public class ImageReadRepository : ReadRepository<Image>, IImageReadRepository
    {
        public ImageReadRepository(ETicaretAPIProjectDbContext context) : base(context)
        {
        }
    }
}
