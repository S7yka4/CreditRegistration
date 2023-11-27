using CreditRegistration.DbCommon;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace CreditRegistration.MsSql
{
    public class DataContextFactory : IDesignTimeDbContextFactory<MsSqlContext>
    {
        // dotnet ef migrations add Initial --  --Args 'connextionString'
        // dotnet ef database update -- "connextionString"
        public MsSqlContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<DataContext>();
            optionsBuilder.UseSqlServer(args[0]);
            return new MsSqlContext(optionsBuilder.Options);
        }
    }

}
