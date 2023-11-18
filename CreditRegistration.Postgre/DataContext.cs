using CreditRegistration.DbCommon;
using CreditRegistration.DbCommon.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CreditRegistration.Postgre
{
    public class PostgreContext:DataContext
    {

        public PostgreContext(DbContextOptions<DataContext> options) : base(options) { }

        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(x=>x.MigrationsHistoryTable(DefaultDbConfiguration.DefaultMigrationTableName, DefaultDbConfiguration.DefaultSchemaName));
        }
    }
}
