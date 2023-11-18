using CreditRegistration.DbCommon.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditRegistrationCommon
{
    public interface ITarrifService
    {
        public Task<List<Tarrif>> GetTarrifs();
        public Task<Tarrif?> GetById(long id);
    }
}
