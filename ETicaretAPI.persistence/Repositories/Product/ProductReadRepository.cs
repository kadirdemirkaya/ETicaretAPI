using ETicaretAPI.application.DTOs.Product;
using ETicaretAPI.application.Repositories;
using ETicaretAPI.domain.Entites;
using ETicaretAPI.persistence.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace ETicaretAPI.persistence.Repositories
{
    public class ProductReadRepository : ReadRepository<Product>, IProductReadRepository
    {
        private readonly ETicaretAPIProjectDbContext context;
        public ProductReadRepository(ETicaretAPIProjectDbContext context) : base(context)
        {
            this.context = context;
        }
    }
}
