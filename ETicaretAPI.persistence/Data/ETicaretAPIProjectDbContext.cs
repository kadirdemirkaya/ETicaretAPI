using ETicaretAPI.domain.Entites;
using ETicaretAPI.domain.Entites.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ETicaretAPI.persistence.Data
{
    public class ETicaretAPIProjectDbContext : IdentityDbContext<AppUser, AppRole, Guid, AppUserClaim, AppUserRole, AppUserLogin, AppRoleClaim, AppUserToken>
    {
        public ETicaretAPIProjectDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Basket> Baskets { get; set; }
        public DbSet<BasketItem> BasketItems { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<ImageProduct> ImageProducts { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<CommunicationPerson> CommunicationPersons { get; set; }
        public DbSet<CommunicationCustomerPerson> CommunicationCustomerPersons { get; set; }
        public DbSet<CommunicationMessage> CommunicationMessages { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Category>()
                .HasData(
                    new Category() { Id = Guid.Parse("C112704C-1192-42D5-B83F-8932CEBB59C8"), Name = "Toys" },
                    new Category() { Id = Guid.Parse("D2B26034-015E-4414-ABD6-A83C6D1E593A"), Name = "Food" },
                    new Category() { Id = Guid.Parse("C62E3D07-1F16-411E-BE9E-A76C6BA445F0"), Name = "Shoe" },
                    new Category() { Id = Guid.Parse("22DA9127-F4E9-491F-8440-75765EB4DB4A"), Name = "Phone" },
                    new Category() { Id = Guid.Parse("D0C3D27E-1781-46C9-87E1-2B88F48D23F2"), Name = "Laptop" },
                    new Category() { Id = Guid.Parse("CA13F73E-EE19-40CA-9905-678043BE4AEA"), Name = "Furniture" }
                );

            base.OnModelCreating(builder);
        }
    }
}
