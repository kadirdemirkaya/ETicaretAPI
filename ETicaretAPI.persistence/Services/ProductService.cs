using ETicaretAPI.application.Abstractions.Services;
using ETicaretAPI.application.UnitOfWorks;
using ETicaretAPI.domain.Entites;
using Microsoft.EntityFrameworkCore;

namespace ETicaretAPI.persistence.Services
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork unitOfWork;

        public ProductService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<List<Product>> GetProductToBasket(Guid userId)
        {
            Basket basket = await unitOfWork.GetReadRepository<Basket>().GetAsync(b => b.UserId == userId && b.IsSuccess == true && b.isBasketConfirm == false);
            List<Product> products = await unitOfWork.GetReadRepository<BasketItem>()
                                     .Table
                                    .Where(bi => bi.Basket.IsSuccess && bi.Basket.UserId == userId && !bi.Basket.isBasketConfirm &&         bi.IsSuccess == true)
                                    .Include(bi => bi.Product)
                                    .Select(bi => new Product
                                    {
                                        Name = bi.Product.Name,
                                        Price = bi.Product.Price,
                                        Quantity = bi.Quantity,
                                        Id = bi.Product.Id,
                                        ProductCode = bi.Product.ProductCode
                                    })
                                    .ToListAsync();
            if (products is not null)
                return products;
            return null;

            #region Anonim Type
            //var baskets = await unitOfWork.GetReadRepository<Basket>()
            //    .Table
            //    .Include(b => b.BasketItems)
            //        .ThenInclude(b => b.Product) //eğer bağlı bulunduğu yerse ThenInclude !
            //        .Where(b => b.UserId == userId && b.isBasketConfirm == false && b.IsSuccess == true)
            //    .Select(b => new
            //    {
            //        Basket = b,
            //        ProductNames = b.BasketItems.Select(bi => bi.Product.Name),
            //        ProductPrices = b.BasketItems.Select(bi => bi.Product.Price),
            //        ProductStocks = b.BasketItems.Select(bi=>bi.Product.Stock),
            //        ProductCodes = b.BasketItems.Select(bi=>bi.Product.ProductCode),
            //        ProductIds = b.BasketItems.Select(bi=>bi.Product.Id)
            //    }).ToListAsync();
            //var productList = baskets.SelectMany(b => b.Basket.BasketItems.Select((bi,index) => new Product
            //{
            //    Name = b.ProductNames.ElementAt(index),
            //    Price = b.ProductPrices.ElementAt(index),
            //    Stock = bi.Product.Stock,
            //    Id = bi.Product.Id,
            //    ProductCode = bi.Product.ProductCode
            //})).ToList();
            //return productList;
            #endregion
        }
    }
}
