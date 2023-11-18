using CreditRegistration.DbCommon;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditRegistrationTests.Common
{
    public class DbContextFactory
    {
        public string mssql;
        public string postgre;
        public DataContext GetContext(string providerName)
        {
            var builder = new DbContextOptionsBuilder<DataContext>();
            switch (providerName)
            {
                case "MSSQL":
                    {
                        builder.UseSqlServer(mssql);
                        return new DataContext(builder.Options);
                    }

                case "POSTGRE":
                    {
                        builder.UseNpgsql(postgre);
                        return new DataContext(builder.Options);
                    }
            }
            throw new Exception();
        }
    }
}
