using CreditRegistration.DbCommon.Models;
using Microsoft.EntityFrameworkCore;


namespace CreditRegistration.DbCommon
{
    public class DataContext : DbContext
    {
        string _baseType;

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public virtual DbSet<LoanOrder> LoanOrders => Set<LoanOrder>();
        public virtual DbSet<Tarrif> Tarrifs => Set<Tarrif>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
