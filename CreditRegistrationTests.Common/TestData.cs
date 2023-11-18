using CreditRegistration.DbCommon.Models;

namespace CreditRegistrationTests.Common
{
    public static class TestData
    {
        public static readonly LoanOrder ToCreate = new LoanOrder()
        {
            OrderId = Guid.NewGuid().ToString(),
            UserId = 4444444444,
            TarrifId = 2,
            CreditRating = 0.6,
            Status = LoanOrderStatus.InProgress,
            TimeInsert = DateTime.Now,
            TimeUpdate = DateTime.Now
        };
        public static readonly List<Tarrif> Tarrifs = new List<Tarrif>()
        {
            new Tarrif()
            {
                Type="CONSUMER",
                InterstRate="11.9%"
            },
            new Tarrif()
            {
                Type="MORTGAGE",
                InterstRate="5.9%"
            }
        };

        public static readonly List<LoanOrder> LoanOrders = new List<LoanOrder>()
        {
           new  LoanOrder()
           {
               OrderId="75fa7f6f-f6fb-4fef-834c-2e453a703433",
               UserId=111111111,
               TarrifId=1,
               CreditRating=0.75,
               Status=LoanOrderStatus.InProgress,
               TimeInsert=DateTime.Now,
               TimeUpdate=DateTime.Now
           },
           new  LoanOrder()
           {
               OrderId="9d590a6e-3e7f-4762-9134-aa9d1595d810",
               UserId=22222222,
               TarrifId=1,
               CreditRating=0.8,
               Status=LoanOrderStatus.Refused,
               TimeInsert=new DateTime(2022,7,30),
               TimeUpdate=new DateTime(2022,7,30,1,30,35)
           },
           new  LoanOrder()
           {
               OrderId=Guid.NewGuid().ToString(),
               UserId=333333333,
               TarrifId=2,
               CreditRating=0.6,
               Status=LoanOrderStatus.Approved,
               TimeInsert=DateTime.Now,
               TimeUpdate=DateTime.Now
           }
        };
    }
}
