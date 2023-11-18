using CreditRegistration.DbCommon.Models;

namespace CreditRegistrationCommon
{
    public class OrderCloseService : IOrderCloseService
    {
        ILoanOrderService _loanOrderService;
        public OrderCloseService(ILoanOrderService loanOrderService)
        {
            _loanOrderService = loanOrderService;
        }
        public async void CloseOrder()
        {
            var loanOrder = (await _loanOrderService.GetByStatus(LoanOrderStatus.InProgress)).FirstOrDefault();
            if (loanOrder is not null)
            {
                loanOrder.Status = new Random().Next(0, 1) == 1 ? LoanOrderStatus.Approved : LoanOrderStatus.Refused;
                loanOrder.TimeUpdate = DateTime.Now;
                await _loanOrderService.Update(loanOrder);
            }
        }
    }
}
