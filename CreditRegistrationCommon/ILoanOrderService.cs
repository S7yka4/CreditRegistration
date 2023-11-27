using CreditRegistration.DbCommon.Models;

namespace CreditRegistrationCommon
{
    public interface ILoanOrderService
    {
        Task<LoanOrder[]> GetByUserId(long userId);
        Task<string> CreateLoanOrder(LoanOrder loanOrder);
        Task<LoanOrder?> GetByOrderId(string orderId);
        Task<LoanOrder?> GetByOrderAndUserId(string orderId, long userId);
        Task<int> Update(LoanOrder loanOrder);
        Task<LoanOrder[]> GetByStatus(string status);
        Task<int> DeleteOrder(LoanOrder order);
        Task<LoanOrder?> GetFirstByStatus(string status);
    }
}
