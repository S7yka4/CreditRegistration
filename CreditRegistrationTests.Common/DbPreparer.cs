
namespace CreditRegistrationTests.Common
{
    public class DbPreparer
    {
        TestDataSetter _dbManager;
        public DbPreparer(TestDataSetter dbManager)
        {
            _dbManager = dbManager;
        }
        public void ClearDb(string provider)
        {
            _dbManager.ClearLoanOrderTable(provider);
            _dbManager.ClearTarrifTable(provider);
        }
        public Dictionary<int, long?> PrepareDb(string provider)
        {
            ClearDb(provider);
            var typeAndIdDictionary = _dbManager.FillTarrifTable(provider, TestData.Tarrifs);
            _dbManager.FillLoanOrderTable(provider, TestData.LoanOrders, typeAndIdDictionary);
            return typeAndIdDictionary;
        }

    }
}
