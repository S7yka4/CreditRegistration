using CreditRegistration.DbCommon;
using Microsoft.EntityFrameworkCore;

namespace CreditRegistration.Postgre
{
    public class PostgreContext : DataContext
    {

        public PostgreContext(DbContextOptions<DataContext> options) : base(options) { }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(x => x.MigrationsHistoryTable(DefaultDbConfiguration.DefaultMigrationTableName, DefaultDbConfiguration.DefaultSchemaName));
        }
    }
}
