using CreditRegistration.DbCommon.Models;

namespace CreditRegistrationTests.Common
{
    public class TestDataSetter
    {

        DbContextFactory _factory;

        public TestDataSetter(DbContextFactory factory)
        {
            _factory = factory;
        }

        public void ClearLoanOrderTable(string provider)
        {

            using (var context = _factory.GetContext(provider))
            {
                foreach (var loanOrder in context.LoanOrders)
                    context.Remove(loanOrder);
                context.SaveChanges();
            }
        }

        public void ClearTarrifTable(string provider)
        {
            using (var context = _factory.GetContext(provider))
            {
                foreach (var tarrif in context.Tarrifs)
                    context.Remove(tarrif);
                context.SaveChanges();
            }
        }

        public void FillLoanOrderTable(string provider, List<LoanOrder> loanOrders, Dictionary<int, long?> tarrifIdHashMap)
        {
            using (var context = _factory.GetContext(provider))
            {
                foreach (var loanOrder in loanOrders)
                {
                    loanOrder.Id = null;
                    if (loanOrder.TarrifId <= 2)
                        loanOrder.TarrifId = (long)tarrifIdHashMap[(int)loanOrder.TarrifId];
                    context.Add(loanOrder);
                }
                context.SaveChanges();
            }
        }

        public Dictionary<int, long?> FillTarrifTable(string provider, List<Tarrif> tarrifs)
        {
            var result = new Dictionary<int, long?>();
            using (var context = _factory.GetContext(provider))
            {
                foreach (var tarrif in tarrifs)
                {
                    tarrif.Id = null;
                    context.Add(tarrif);
                }
                context.SaveChanges();

                foreach (var tarrif in tarrifs)
                {
                    result.Add(tarrif.Type == "CONSUMER" ? 1 : 2, context.Tarrifs.First(_ => _.Type == tarrif.Type).Id);

                }
            }
            return result;
        }
    }
}
