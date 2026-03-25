using Microsoft.EntityFrameworkCore;
using SuiteRx.Interface.Domain.Entities;
using SuiteRx.Interface.Domain.Repositories;
using SuiteRx.Interface.Persistance.Contexts;

namespace SuiteRx.Interface.Persistance.Repositories
{
    public class AddressRepository : IAddressRepository
    {
        private readonly PharmacyDBContext _dbContext;

        public AddressRepository(PharmacyDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Address> CreateAddressAsync(Address request)
        {
            if (request != null)
            {
                try
                {
                    await _dbContext.Addresses.AddAsync(request);
                    await _dbContext.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
            return request;
        }

        public async Task<List<Address>> GetAllAddressesAsync()
        {
            return await _dbContext.Addresses.Include(a => a.Department).AsNoTracking().ToListAsync();
        }

        public async Task<Address?> GetAddressByIdAsync(int id)
        {
            return await _dbContext.Addresses.Include(a => a.Department).FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<bool> UpdateAddressAsync(Address request)
        {
            var existing = await _dbContext.Addresses.FindAsync(request.Id);
            if (existing != null)
            {
                existing.Street = request.Street;
                existing.City = request.City;
                existing.DepartmentId = request.DepartmentId;
                
                _dbContext.Addresses.Update(existing);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> DeleteAddressAsync(int id)
        {
            var existing = await _dbContext.Addresses.FindAsync(id);
            if (existing != null)
            {
                _dbContext.Addresses.Remove(existing);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
