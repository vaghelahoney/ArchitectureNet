using SuiteRx.Interface.Domain.Entities;

namespace SuiteRx.Interface.Domain.Repositories
{
    public interface IClothesRepository
    {
        Task<Clothes> CreateClothesAsync(Clothes request);
        Task<List<Clothes>> GetAllClothesAsync();
        Task<Clothes?> GetClothesByIdAsync(int id);
        Task<bool> UpdateClothesAsync(Clothes request);
        Task<bool> DeleteClothesAsync(int id);
    }
}
