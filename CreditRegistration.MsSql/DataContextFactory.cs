using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CreditRegistration.DbCommon.Models;
using Microsoft.Extensions.Options;
using CreditRegistration.DbCommon;

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
