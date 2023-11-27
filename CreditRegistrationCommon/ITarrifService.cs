using CreditRegistration.DbCommon.Models;

namespace CreditRegistrationCommon
{
    public interface ITarrifService
    {
        Task<Tarrif[]> GetTarrifs();
        Task<Tarrif?> GetById(long id);
    }
}
