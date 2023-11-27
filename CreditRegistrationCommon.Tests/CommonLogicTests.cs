using CreditRegistration.DbCommon.Models;
using CreditRegistrationTests.Common;

namespace CreditRegistrationCommon.Tests
{
    public class CommonLogicTests
    {

        readonly string mssqlConnectionString = "Data Source=S7YKA4WS; Initial Catalog=CreditRegistration; User id=TestUser; Password=12345678; TrustServerCertificate=true;";
        readonly string postgreConnectionString = "Server=127.0.0.1;Port=5432;Database=PetProjectDb;Username=testUser;Password=12345678;";
        DbContextFactory _factory;
        TestDataSetter _testDataSetter;
        DbPreparer _preparer;

        DbContextFactory ContextFactory
        {
            get
            {
                return _factory ??= new DbContextFactory()
                {
                    mssql = mssqlConnectionString,
                    postgre = postgreConnectionString
                };
            }
        }
        TestDataSetter TestDataSetter
        {
            get
            {
                return _testDataSetter ??= new TestDataSetter(ContextFactory);
            }
        }
        DbPreparer Preparer
        {
            get
            {
                return _preparer ??= new DbPreparer(TestDataSetter);
            }
        }


        ILoanOrderService GetService(string provider)
        {
            var list = TestData.LoanOrders;
            Preparer.PrepareDb(provider);
            return new LoanOrderManager(ContextFactory.GetContext(provider));
        }


        [Theory]
        [InlineData("MSSQL")]
        [InlineData("POSTGRE")]
        public void GetByOrderIdTest(string provider)
        {
            try
            {
                var service = GetService(provider);
                var result = service.GetByOrderId(TestData.LoanOrders[0].OrderId).Result;
                Assert.NotNull(result);
                Assert.Equal(result.OrderId, TestData.LoanOrders[0].OrderId);
            }
            finally
            {
                Preparer.ClearDb(provider);
            }
        }

        [Theory]
        [InlineData("MSSQL")]
        [InlineData("POSTGRE")]
        public void DeleteTest(string provider)
        {
            try
            {
                var service = GetService(provider);
                var code = service.DeleteOrder(TestData.LoanOrders[0]).Result;
                var result = service.GetByOrderId(TestData.LoanOrders[0].OrderId).Result;
                Assert.Null(result);
            }
            finally
            {
                Preparer.ClearDb(provider);
            }
        }

        [Theory]
        [InlineData("MSSQL")]
        [InlineData("POSTGRE")]
        public void CreateTest(string provider)
        {
            try
            {
                var service = GetService(provider);
                var toCreate = TestData.ToCreate;
                toCreate.Id = null;
                var newOrderId = service.CreateLoanOrder(toCreate).Result;
                var result = service.GetByOrderId(newOrderId).Result;
                Assert.NotNull(result);
                Assert.Equal(result.OrderId, TestData.ToCreate.OrderId);
            }
            finally
            {
                Preparer.ClearDb(provider);
            }
        }

        [Theory]
        [InlineData("MSSQL")]
        [InlineData("POSTGRE")]
        public void UpdateTest(string provider)
        {
            try
            {
                var service = GetService(provider);
                var toUpdate = service.GetByOrderId(TestData.LoanOrders[0].OrderId).Result;
                toUpdate.Status = LoanOrderStatus.Approved;
                var res = service.Update(toUpdate).Result;
                var result = service.GetByOrderId(TestData.LoanOrders[0].OrderId).Result;
                Assert.NotNull(result);
                Assert.Equal(result.Status, LoanOrderStatus.Approved);
            }
            finally
            {
                Preparer.ClearDb(provider);
            }
        }

        [Theory]
        [InlineData("MSSQL")]
        [InlineData("POSTGRE")]
        public void GetByUserIdTest(string provider)
        {
            try
            {
                var service = GetService(provider);
                var result = service.GetByUserId(TestData.LoanOrders[0].UserId).Result;
                Assert.NotNull(result);
                Assert.True(result.Length != 0);
                Assert.Equal(result.Where(_ => _.UserId == TestData.LoanOrders[0].UserId).Count(), result.Length);
            }
            finally
            {
                Preparer.ClearDb(provider);
            }
        }

        [Theory]
        [InlineData("MSSQL")]
        [InlineData("POSTGRE")]
        public void GetByOrderAndUserIdTest(string provider)
        {
            try
            {
                var service = GetService(provider);
                var result = service.GetByOrderAndUserId(TestData.LoanOrders[0].OrderId, TestData.LoanOrders[0].UserId).Result;
                Assert.NotNull(result);
            }
            finally
            {
                Preparer.ClearDb(provider);
            }
        }

        [Theory]
        [InlineData("MSSQL")]
        [InlineData("POSTGRE")]
        public void GetbyStatusTest(string provider)
        {
            try
            {
                var service = GetService(provider);
                var result = service.GetByStatus(LoanOrderStatus.InProgress).Result;
                Assert.NotNull(result);
                Assert.Equal(result.Length, TestData.LoanOrders.Where(_ => _.Status == LoanOrderStatus.InProgress).Count());
            }
            finally
            {
                Preparer.ClearDb(provider);
            }
        }
    }
}