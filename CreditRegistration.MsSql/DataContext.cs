using CreditRegistration.DbCommon;
using Microsoft.EntityFrameworkCore;

namespace CreditRegistration.MsSql
{
    public class MsSqlContext : DataContext
    {

        public MsSqlContext(DbContextOptions<DataContext> options) : base(options) { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(x => x.MigrationsHistoryTable(DefaultDbConfiguration.DefaultMigrationTableName, DefaultDbConfiguration.DefaultSchemaName));
            base.OnConfiguring(optionsBuilder);
        }
    }
}
