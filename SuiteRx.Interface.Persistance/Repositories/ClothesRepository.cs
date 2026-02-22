using SuiteRx.Interface.Domain.Entities;
using SuiteRx.Interface.Domain.Repositories;
using SuiteRx.Interface.Persistance.Contexts;

namespace SuiteRx.Interface.Persistance.Repositories
{
    public class ClothesRepository : IClothesRepository
    {
        private readonly PharmacyDBContext _dbContext;

        public ClothesRepository(PharmacyDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Clothes> CreateClothesAsync(Clothes request)
        {
            if (request != null)
            {
                try
                {
                    request.CreatedAt = DateTime.UtcNow;
                    await _dbContext.Clothes.AddAsync(request);
                    _dbContext.SaveChanges();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
            return request;
        }

        public async Task<List<Clothes>> GetAllClothesAsync()
        {
            return await Task.FromResult(_dbContext.Clothes.ToList()); 
        }

        public async Task<Clothes?> GetClothesByIdAsync(int id)
        {
            return await _dbContext.Clothes.FindAsync(id);
        }

        public async Task<bool> UpdateClothesAsync(Clothes request)
        {
            var existing = await _dbContext.Clothes.FindAsync(request.Id);
            if (existing != null)
            {
                existing.Name = request.Name;
                existing.Description = request.Description;
                existing.Price = request.Price;
                existing.Category = request.Category;
                existing.StockQuantity = request.StockQuantity;
                existing.IsAvailable = request.IsAvailable;
                
                _dbContext.Clothes.Update(existing);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> DeleteClothesAsync(int id)
        {
            var existing = await _dbContext.Clothes.FindAsync(id);
            if (existing != null)
            {
                _dbContext.Clothes.Remove(existing);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
