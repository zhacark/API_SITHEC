using Microsoft.Extensions.Configuration;

namespace Persistence.Models
{
    public class ConnectionService
    {
        public static string connstring = "";
        public static void Set(IConfiguration config)
        {
            connstring = config.GetConnectionString("DefaultConnection");
        }
    }
}