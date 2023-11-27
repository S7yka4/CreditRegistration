using Microsoft.EntityFrameworkCore;

namespace CreditRegistrationService
{
    public static class Extensions
    {

        public static DbContextOptionsBuilder SetDbConnection(this DbContextOptionsBuilder opts, ConfigurationManager config)
        {
            var csPostgre = config.GetConnectionString("Postgre");
            var csMssql = config.GetConnectionString("MSSQL");
            return String.IsNullOrEmpty(csPostgre) ? opts.UseSqlServer(csMssql) : opts.UseNpgsql(csPostgre);
        }
    }
}
