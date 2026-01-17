using SuiteRx.Interface.Domain.Entities;
using SuiteRx.Interface.Persistance.Contexts;

namespace SuiteRx.Interface.Persistance.Repositories
{
    public class RegistrationRepository : IRegistrationRepository
    {

        private readonly PharmacyDBContext _dbContext;

        public RegistrationRepository(PharmacyDBContext dbContext)
        {
            _dbContext = dbContext;

        }
        public async Task<Registration> CreateRegistration(Registration request)
        {
            if (request != null)
            {
                try
                {
                    request.CreatedAt = DateTime.UtcNow;

                    await _dbContext.Registration.AddAsync(request);
                    _dbContext.SaveChanges();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }

            return request;
        }

        public async Task<List<Registration>> GetAllRegistration()
        {
            return await Task.FromResult(_dbContext.Registration.ToList()); 
        }
    }
}