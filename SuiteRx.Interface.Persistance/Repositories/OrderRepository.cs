using SuiteRx.Interface.Domain;
using SuiteRx.Interface.Domain.Entities;
using SuiteRx.Interface.Persistance.Contexts;

namespace SuiteRx.Interface.Persistance.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly PharmacyDBContext _dbContext;

        public OrderRepository(PharmacyDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Hl7Message> CreateOrder(Hl7Message request)
        {
            if (request != null)
            {
                try
                {
                    await _dbContext.Hl7Messages.AddAsync(request);
                    _dbContext.SaveChanges();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }

            return request;
        }
    }
}
