using CreditRegistration.DbCommon;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace CreditRegistration.Postgre
{
    public class DataContextFactory : IDesignTimeDbContextFactory<PostgreContext>
    {
        // dotnet ef migrations add Initial --  --Args 'connextionString'
        // dotnet ef database update -- "connectionString"
        public PostgreContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<DataContext>();
            optionsBuilder.UseNpgsql(args[0]);
            return new PostgreContext(optionsBuilder.Options);
        }
    }
}
