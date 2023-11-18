using CreditRegistration.DbCommon.Models;
using CreditRegistrationCommon.Tests;
using CreditRegistrationService;
using CreditRegistrationService.Bodies;
using CreditRegistrationTests.Common;
using Microsoft.AspNetCore.Http;

namespace CreditRegistration.ServiceTest
{
    public class ServiceTest
    {

        string uri = "https://localhost:5001/";
        CreditRegistartionClient _client;
        DbContextFactory _factory;
        TestDataSetter _testDataSetter;
        DbPreparer _preparer;
        readonly string provider = "POSTGRE";
        readonly string postgreConnectionString = "Server=127.0.0.1;Port=5432;Database=PetProjectDb;Username=testUser;Password=232962759Mat;";


        DbContextFactory ContextFactory
        {
            get
            {
                return _factory ??= new DbContextFactory()
                {
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

        CreditRegistartionClient Client
        {
            get
            {
                return _client ??= new CreditRegistartionClient(uri);
            }
        }
        [Fact]
        public void  GetTarrifsTest()
        {
            try
            {
                Preparer.PrepareDb(provider);
                var response = Client.GetTarrifs();
                response.EnsureSuccessStatusCode();
                var tarrifs = response.Deserialize<List<Tarrif>>();
                Assert.NotNull(tarrifs);
                Assert.NotEmpty(tarrifs);
            }
            finally { Preparer.ClearDb(provider); }

        }

        [Fact]
        public void CreateOrderSuccess()
        {
            try
            {
                var dict=Preparer.PrepareDb(provider);
                var response = Client.CreateOrder(123456, (long)dict[1]);
                response.EnsureSuccessStatusCode();
                var successResponse = response.Deserialize<CreateOrderSuccessResponse>();
                Assert.NotNull(successResponse);
                Assert.True(!String.IsNullOrWhiteSpace(successResponse.data.orderId));
            }
            finally
            {
                Preparer.ClearDb(provider);
            }
        }

        [Fact]
        public void CreateOrderTarrifNotFoundError()
        {
            try
            {
                Preparer.PrepareDb(provider);
                var response = Client.CreateOrder(123456, 3);
                Assert.Equal("BadRequest", response.StatusCode.ToString());
                var errorResponse = response.Deserialize<ErrorResponse>();
                Assert.Equal(ErrorCodes.TarrifNotFound, errorResponse.error.code);
            }
            finally
            {
                Preparer.ClearDb(provider);
            }
        }

        [Fact]
        public void CreateOrderLoanConsiderationError()
        {
            try
            {
                var dict=Preparer.PrepareDb(provider);
                var response = Client.CreateOrder(111111111, (long) dict[1]);
                Assert.Equal("BadRequest", response.StatusCode.ToString());
                var errorResponse = response.Deserialize<ErrorResponse>();
                Assert.Equal(ErrorCodes.LoanConsideration, errorResponse.error.code);
            }
            finally
            {
                Preparer.ClearDb(provider);
            }
        }

        [Fact]
        public void CreateOrderLoanApprovedError()
        {
            try
            {
                var dict=Preparer.PrepareDb(provider);
                var response = Client.CreateOrder(333333333, (long)dict[2]);
                Assert.Equal("BadRequest", response.StatusCode.ToString());
                var errorResponse = response.Deserialize<ErrorResponse>();
                Assert.Equal(ErrorCodes.LoanApproved, errorResponse.error.code);
            }
            finally
            {
                Preparer.ClearDb(provider);
            }
        }

        [Fact]
        public void CreateOrderTryLaterError()
        {
            try
            {
                var dict=Preparer.PrepareDb(provider);
                var response = Client.CreateOrder(22222222, (long)dict[1]);
                var str = response.Content.ReadAsStringAsync().Result;
                Assert.Equal("BadRequest", response.StatusCode.ToString());
                var errorResponse = response.Deserialize<ErrorResponse>();
                Assert.Equal(ErrorCodes.TryLater, errorResponse.error.code);
            }
            finally
            {
                Preparer.ClearDb(provider);
            }
        }

        [Fact]
        public void DeleteOrderSuccess()
        {
            try
            {
                Preparer.PrepareDb(provider);
                var response = Client.DeleteOrder(111111111, "75fa7f6f-f6fb-4fef-834c-2e453a703433");
                Assert.Equal("OK", response.StatusCode.ToString());
            }
            finally
            {
                Preparer.ClearDb(provider);
            }
        }

        [Fact]
        public void DeleteOrderOrderNotFoundError()
        {
            try
            {
                Preparer.PrepareDb(provider);
                var response = Client.DeleteOrder(111111111, Guid.Empty.ToString());
                Assert.Equal("BadRequest", response.StatusCode.ToString());
                var errorResponse = response.Deserialize<ErrorResponse>();
                Assert.Equal(ErrorCodes.OrderNotFound, errorResponse.error.code);
            }
            finally
            {
                Preparer.ClearDb(provider);
            }
        }

        [Fact]
        public void DeleteOrderOrderImpossibleToDelete()
        {
            try
            {
                Preparer.PrepareDb(provider);
                var response = Client.DeleteOrder(22222222, "9d590a6e-3e7f-4762-9134-aa9d1595d810");
                Assert.Equal("BadRequest", response.StatusCode.ToString());
                var errorResponse = response.Deserialize<ErrorResponse>();
                Assert.Equal(ErrorCodes.OrderImpossibleToDelete, errorResponse.error.code);
            }
            finally
            {
                Preparer.ClearDb(provider);
            }
        }
    }
}