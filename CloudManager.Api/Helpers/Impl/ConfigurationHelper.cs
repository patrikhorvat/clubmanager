namespace CloudManager.Api.Helpers.Impl
{
    public class ConfigurationHelper:IConfigurationHelper
    {
        private readonly IConfiguration _configuration;

        public ConfigurationHelper(
            IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GetDefaultConnectionString()
        {
            return _configuration.GetConnectionString("DefaultConnection");
        }
    }
}
