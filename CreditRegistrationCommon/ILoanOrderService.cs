using CreditRegistration.DbCommon.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditRegistrationCommon
{
    public interface ILoanOrderService
    {
        public Task<List<LoanOrder>> GetByUserId(long userId);
        public Task<string> CreateLoanOrder(LoanOrder loanOrder);
        public Task<LoanOrder?> GetByOrderId(string orderId);
        public Task<LoanOrder?> GetByOrderAndUserId(string orderId, long userId);
        public Task<int> Update(LoanOrder loanOrder);
        public Task<List<LoanOrder>> GetByStatus(string status);
        public Task<int> DeleteOrder(LoanOrder order);
    }
}
