using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CreditRegistration.DbCommon.Models;
using CreditRegistration.DbCommon;

namespace CreditRegistration.Postgre
{
    public class DataContextFactory : IDesignTimeDbContextFactory<PostgreContext>
    {
        // dotnet ef migrations add Initial --  --Args 'connextionString'
        // dotnet ef database update -- "connextionString"
        public PostgreContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<DataContext>();
            optionsBuilder.UseNpgsql(args[0]);
            return new PostgreContext(optionsBuilder.Options);
        }
    }
}
