using Microsoft.Extensions.Configuration;

namespace RestaurantsAPI
{
    public class RestaurantConfiguration
    {
        private IConfiguration config { get; set; }
        public RestaurantConfiguration(IConfiguration config)
        {
            this.config = config;
        }
        public string DBConnectionString
        {
            get
            {
                return config.GetValue<string>("DbSqlLite");
            }
        }
    }
}
