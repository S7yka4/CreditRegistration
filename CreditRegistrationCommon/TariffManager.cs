using CreditRegistration.DbCommon;
using CreditRegistration.DbCommon.Models;
using Microsoft.EntityFrameworkCore;

namespace CreditRegistrationCommon
{
    public class TariffManager : ITarrifService
    {
        DataContext _context;

        public TariffManager(DataContext context)
        {
            _context = context;
        }

        public async Task<Tarrif[]> GetTarrifs()
        {
            var result = await _context.Tarrifs.ToArrayAsync();
            return result;
        }

        public async Task<Tarrif?> GetById(long id)
        {
            return await _context.Tarrifs.FindAsync(id);
        }
    }
}
