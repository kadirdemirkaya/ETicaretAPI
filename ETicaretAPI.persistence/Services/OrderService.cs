using AutoMapper;
using ETicaretAPI.application.Abstractions.Services;
using ETicaretAPI.application.DTOs.Address;
using ETicaretAPI.application.DTOs.Order;
using ETicaretAPI.application.Repositories;
using ETicaretAPI.application.UnitOfWorks;
using ETicaretAPI.domain.Entites;
using ETicaretAPI.domain.Entites.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ETicaretAPI.persistence.Services
{
    public class OrderService : IOrderService
    {
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly UserManager<AppUser> userManager;
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly IAppUserReadRepository appUserReadRepository;
        private readonly ICustomerReadRepository customerReadRepository;
        private readonly IOrderReadRepository orderReadRepository;

        public OrderService(IHttpContextAccessor httpContextAccessor, UserManager<AppUser> userManager, IUnitOfWork unitOfWork, IMapper mapper, IAppUserReadRepository appUserReadRepository, ICustomerReadRepository customerReadRepository, IOrderReadRepository orderReadRepository)
        {
            this.httpContextAccessor = httpContextAccessor;
            this.userManager = userManager;
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.appUserReadRepository = appUserReadRepository;
            this.customerReadRepository = customerReadRepository;
            this.orderReadRepository = orderReadRepository;
        }

        public async Task<Guid> AddOrderWithRelations(AddOrderDto addOrderDto, AddAddressDto addAddressDto)
        {
            //1
            string userName = httpContextAccessor.HttpContext.Request.HttpContext.User.Identity.Name;
            AppUser user = await userManager.FindByNameAsync(userName);

            //2
            bool result1 = false;
            Customer customer = await unitOfWork.GetReadRepository<Customer>().GetAsync(c => c.AppUserId == user.Id);
            if (customer is null)
            {
                customer = new() { AppUserId = user.Id, Name = userName };
                result1 = await unitOfWork.GetWriteRepository<Customer>().AddAsync(customer);
            }
            await unitOfWork.GetWriteRepository<Customer>().SaveChangesAsync();

            //3
            var map = mapper.Map<Address>(addAddressDto);
            bool result2 = await unitOfWork.GetWriteRepository<Address>().AddAsync(map);
            await unitOfWork.GetWriteRepository<Address>().SaveChangesAsync();

            //4
            var map2 = mapper.Map<Order>(addOrderDto);
            map2.AddressId = map.Id;
            map2.CustomerId = customer.Id;
            map2.IsSuccess = true;
            bool result3 = await unitOfWork.GetWriteRepository<Order>().AddAsync(map2);
            await unitOfWork.GetWriteRepository<Customer>().SaveChangesAsync();

            string fakeString = "7309516F-67AE-4AD5-A98A-B259ECA9CFEF"; // !!!
            return map2.Id != null ? map2.Id : Guid.Parse(fakeString);
        }

        public async Task<List<ActiveOrdersDto>> GetUserActiveOrders(Guid userId, Guid orderId)
        {
            var customers = await unitOfWork.GetReadRepository<Customer>()
                .Table
                .Where(c => c.AppUserId == userId && c.IsSuccess == true)
                .Include(c => c.Orders.Where(c => c.IsSuccess == true && c.Id == orderId))
                    .ThenInclude(c => c.Address)
                .Include(c => c.Orders.Where(c => c.IsSuccess == true && c.Id == orderId))
                    .ThenInclude(c => c.Basket)
                    .ThenInclude(c => c.BasketItems)
                    .ThenInclude(c => c.Product)
                 .ToListAsync();

            var filterDatas = customers
                 .SelectMany(c => c.Orders.SelectMany(o => o.Basket.BasketItems))
                 .Where(bi => bi.Basket.IsSuccess == false && bi.Basket.isBasketConfirm == true && bi.IsSuccess == false)
                 .Select(bi => new ActiveOrdersDto
                 {
                     UserId = bi.Basket.UserId,
                     OrderId = bi.Basket.Order.Id,
                     BasketItemQuantity = bi.Quantity,
                     BasketId = bi.BasketId,
                     ProductId = bi.ProductId,
                     ProductStock = bi.Product.Stock,
                     ProductName = bi.Product.Name,
                     ProductCode = bi.Product.ProductCode,
                     ProductPrice = bi.Product.Price
                 });

            return filterDatas.ToList();
        }

        public async Task<bool> CancelToOrder(Guid orderId)
        {
            var orderAndRelations = await unitOfWork.GetReadRepository<Order>()
                .Table
                .Include(o => o.Customer)
                .Include(o => o.Address)
                .Include(o => o.Basket)
                    .ThenInclude(b => b.BasketItems.Where(bi => bi.IsSuccess == false))
                    .ThenInclude(b => b.Product)
                 .Where(o => o.Id == orderId && o.IsSuccess == true &&
                 o.Basket.IsSuccess == false && o.Basket.isBasketConfirm == true &&
                 o.Address.IsSuccess == true && o.Customer.IsSuccess == true)
                .ToListAsync();

            foreach (var relation in orderAndRelations)
            {
                var Order = relation;
                var Customer = relation.Customer;
                var Address = relation.Address;
                var Basket = relation.Basket;
                var BasketItem = relation.Basket.BasketItems;

                Order.IsSuccess = false;
                Order.DeletedTime = DateTime.Now;

                //To do : Customer'ın isSuccess make adjustments on !
                #region Customer may also need correction
                //Customer.IsSuccess = false;
                //Customer.DeletedTime = DateTime.Now;
                #endregion

                Address.IsSuccess = false;
                Address.DeletedTime = DateTime.Now;

                Basket.isBasketConfirm = false;
                Basket.IsSuccess = false;
                Basket.DeletedTime = DateTime.Now;

                foreach (var bItem in BasketItem)
                {
                    bItem.IsSuccess = false;
                    bItem.DeletedTime = DateTime.Now;
                }
            }
            await unitOfWork.GetWriteRepository<Order>().SaveChangesAsync();
            return true;
        }

        public async Task<List<Order>> GetActiveOrNotActiveOrdersAsync(bool isSuccessOrder)
        {
            string userName = httpContextAccessor.HttpContext.Request.HttpContext.User.Identity.Name;
            AppUser appUser = await appUserReadRepository.GetAsync(a => a.UserName == userName);

            Customer customer = await customerReadRepository.GetAsync(c => c.AppUserId == appUser.Id && c.IsSuccess == true);
            List<ETicaretAPI.domain.Entites.Order>? orders = await orderReadRepository.GetAllAsync(o => o.CustomerId == customer.Id && o.IsSuccess == isSuccessOrder);

            orders = orders.Select(o => new ETicaretAPI.domain.Entites.Order
            {
                Id = o.Id,
                Description = o.Description,
                CreatedDate = o.CreatedDate
            }).ToList();

            return orders;
        }
    }
}
