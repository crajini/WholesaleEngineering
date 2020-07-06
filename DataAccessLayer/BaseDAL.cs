using Microsoft.Extensions.Configuration;
using System.IO;

namespace DataAccessLayer
{
    public class BaseDAL
    {
        public readonly string _connectionString = string.Empty;
        public BaseDAL()
        {
            var configurationBuilder = new ConfigurationBuilder();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.Development.json");
            configurationBuilder.AddJsonFile(path, false);

            var root = configurationBuilder.Build();
            _connectionString = root.GetConnectionString("DefaultConnection");
        }
        public string GetConnectionString(string key)
        {
            return _connectionString;
        }
    }
}
