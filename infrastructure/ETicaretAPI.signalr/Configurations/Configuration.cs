using Microsoft.Extensions.Configuration;

namespace ETicaretAPI.signalr.Configurations
{
    public static class Configuration
    {
        public static string ConnectionString
        {
            get
            {
                ConfigurationManager cManager = new();
                cManager.SetBasePath("C:\\Users\\Casper\\Desktop\\GitHub Projects\\ETicaretAPI\\ETicaretAPI.api");
                cManager.AddJsonFile("appsettings.json");
                return cManager.GetConnectionString("SqlServer");
            }
        }
    }
}
