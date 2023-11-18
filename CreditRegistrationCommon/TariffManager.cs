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
    public class TariffManager : ITarrifService
    {
        DataContext _context;

        public TariffManager(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Tarrif>> GetTarrifs()
        {
            var result = await _context.Tarrifs.ToListAsync();
            return result;
        }

        public async Task<Tarrif?> GetById(long id)
        {
            return await _context.Tarrifs.FindAsync(id);
        }
    }
}
