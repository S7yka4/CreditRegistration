using CreditRegistration.DbCommon;
using CreditRegistration.DbCommon.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditRegistrationCommon
{
    public class LoanOrderManager : ILoanOrderService
    {
        DataContext _context;

        public LoanOrderManager(DataContext context)
        {
            _context = context;
        }

        public async Task<List<LoanOrder>> GetByUserId(long userId)
        {

            return await _context.LoanOrders.Where(_ => _.UserId == userId).ToListAsync();
        }

        public async Task<string> CreateLoanOrder(LoanOrder loanOrder)
        {

            _context.LoanOrders.Add(loanOrder);
            await _context.SaveChangesAsync();

            return loanOrder.OrderId;
        }

        public async Task<LoanOrder?> GetByOrderId(string orderId)
        {
            return await _context.LoanOrders.FirstOrDefaultAsync(_ => _.OrderId == orderId);
        }

        public async Task<LoanOrder?> GetByOrderAndUserId(string orderId, long userId)
        {
            return await _context.LoanOrders.FirstOrDefaultAsync(_ => _.OrderId == orderId && _.UserId == userId);
        }

        public async Task<int> Update(LoanOrder newEntity)
        {
            _context.LoanOrders.Update(newEntity);
            await _context.SaveChangesAsync();
            return 0;
        }
        public async Task<List<LoanOrder>> GetByStatus(string status)
        {
            return await _context.LoanOrders.Where(_ => _.Status == status).ToListAsync();
        }

        public async Task<int> DeleteOrder(LoanOrder order)
        {
            _context.LoanOrders.Remove(order);
            await _context.SaveChangesAsync();
            return 0;
        }

    }
}
