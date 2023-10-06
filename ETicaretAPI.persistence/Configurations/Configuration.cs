using Microsoft.Extensions.Configuration;

namespace ETicaretAPI.persistence.Configurations
{
    public static class Configuration
    {
        public static string ConnectionString
        {
            get
            {
                ConfigurationManager cManager = new();
                //cManager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../../Presentation/ETicaretAPI.api"));
                cManager.SetBasePath("C:\\Users\\Casper\\Desktop\\GitHub Projects\\ETicaretAPI\\ETicaretAPI.api");
                cManager.AddJsonFile("appsettings.json");
                return cManager.GetConnectionString("SqlServer");
            }
        }
    }
}
