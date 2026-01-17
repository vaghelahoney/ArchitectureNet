using SuiteRx.Interface.Domain.Entities;

namespace SuiteRx.Interface.Persistance
{
    public interface IRegistrationRepository
    {
        Task<Registration> CreateRegistration(Registration request);

        Task<List<Registration>> GetAllRegistration();
    }
}