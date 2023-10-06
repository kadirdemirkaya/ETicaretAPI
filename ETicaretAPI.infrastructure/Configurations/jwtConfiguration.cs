using Microsoft.Extensions.Configuration;

namespace ETicaretAPI.infrastructure.Configurations
{
    public static class jwtConfiguration
    {
        public static string ValidAudience
        {

            get
            {
                IConfiguration configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                    .AddEnvironmentVariables()
                    .Build();

                string ValidAudience = configuration.GetValue<string>("JWT:ValidAudience");
                return ValidAudience;
            }
        }

        public static string ValidIssuer
        {
            get
            {
                IConfiguration configuration = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                   .AddEnvironmentVariables()
                   .Build();

                string ValidIssuer = configuration.GetValue<string>("JWT:ValidIssuer");
                return ValidIssuer;
            }
        }

        public static string Secret
        {
            get
            {
                IConfiguration configuration = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                   .AddEnvironmentVariables()
                   .Build();

                string Secret = configuration.GetValue<string>("JWT:Secret");
                return Secret;
            }
        }
    }
}