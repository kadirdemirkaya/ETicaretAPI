using ETicaretAPI.application.Abstractions.Services;
using ETicaretAPI.application.Repositories;
using ETicaretAPI.application.UnitOfWorks;
using ETicaretAPI.domain.Entites;
using ETicaretAPI.domain.Entites.Identity;
using ETicaretAPI.persistence.Configurations;
using ETicaretAPI.persistence.Data;
using ETicaretAPI.persistence.Repositories;
using ETicaretAPI.persistence.Services;
using ETicaretAPI.persistence.Subscription;
using ETicaretAPI.persistence.UnitOfWorks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ETicaretAPI.persistence.Extensions
{
    public static class PersistenceRegistrationExtension
    {
        public static void AddPersistenceLayerServices(this IServiceCollection services)
        {
            services.AddDbContext<ETicaretAPIProjectDbContext>(opt => opt.UseSqlServer(Configuration.ConnectionString), ServiceLifetime.Singleton);


            services.AddIdentity<AppUser, AppRole>(opt =>
            {
                opt.Password.RequireDigit = false;
                opt.Password.RequireNonAlphanumeric = false;
                opt.Password.RequireLowercase = false;
                opt.Password.RequireUppercase = false;
                opt.SignIn.RequireConfirmedEmail = true;
                opt.SignIn.RequireConfirmedPhoneNumber = false;
                opt.User.RequireUniqueEmail = false;
                opt.Password.RequiredLength = 3;
                opt.Password.RequiredUniqueChars = 0;
            })
                .AddRoleManager<RoleManager<AppRole>>()
                .AddErrorDescriber<IdentityErrorDescriber>()
                .AddEntityFrameworkStores<ETicaretAPIProjectDbContext>()
                .AddDefaultTokenProviders();


            services.AddSingleton<IUnitOfWork, UnitOfWork>();

            services.AddScoped<ICustomerReadRepository, CustomerReadRepository>();
            services.AddScoped<ICustomerWriteRepository, CustomerWriteRepository>();
            services.AddScoped<IProductReadRepository, ProductReadRepository>();
            services.AddScoped<IProductWriteRepository, ProductWriteRepository>();
            services.AddScoped<IOrderReadRepository, OrderReadRepository>();
            services.AddScoped<IOrderWriteRepository, OrderWriteRepository>();
            services.AddScoped<IImageReadRepository, ImageReadRepository>();
            services.AddScoped<IImageWriteRepository, ImageWriteRepository>();
            services.AddScoped<IAddressReadRepository, AddressReadRepository>();
            services.AddScoped<IAddressWriteRepository, AddressWriteRepository>();
            services.AddScoped<IBasketReadRepository, BasketReadRepository>();
            services.AddScoped<IBasketWriteRepository, BasketWriteRepository>();
            services.AddScoped<IBasketItemReadRepository, BasketItemReadRepository>();
            services.AddScoped<IBasketItemWriteRepository, BasketItemWriteRepository>();
            services.AddScoped<IAppUserReadRepository, AppUserReadRepository>();
            services.AddScoped<IAppUserWriteRepository, AppUserWriteRepository>();
            services.AddScoped<ICategoryReadRepository, CategoryReadRepository>();
            services.AddScoped<ICategoryWriteRepository, CategoryWriteRepository>();
            services.AddScoped<ICommunicationPersonReadRepository, CommunicationPersonReadRepository>();
            services.AddScoped<ICommunicationPersonWriteRepository, CommunicationPersonWriteRepository>();
            services.AddScoped<ICommunicationCustomerPersonReadRepository, CommunicationCustomerPersonReadRepository>();
            services.AddScoped<ICommunicationCustomerPersonWriteRepository, CommunicationCustomerPersonWriteRepository>();
            services.AddScoped<ICommunicationMessageReadRepository, CommunicationMessageReadRepository>();
            services.AddScoped<ICommunicationMessageWriteRepository, CommunicationMessageWriteRepository>();


            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IAuthenticateService, AuthenticateService>();
            services.AddScoped<IImageService, ImageService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<ICommunicationService, CommunicationService>();
            services.AddScoped<ICommunicationCustomerPersonService, CommunicationCustomerPersonService>();

            services.AddSingleton<DatabaseSubscription<Product>>();
        }
    }
}
