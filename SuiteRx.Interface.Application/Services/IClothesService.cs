using SuiteRx.Interface.Application.Dto;

namespace SuiteRx.Interface.Application.Services
{
    public interface IClothesService
    {
        Task<bool> SaveClothesAsync(ClothesDto request);
        Task<List<ClothesDto>> GetAllClothesAsync();
        Task<ClothesDto?> GetClothesByIdAsync(int id);
        Task<bool> UpdateClothesAsync(ClothesDto request);
        Task<bool> DeleteClothesAsync(int id);
    }
}
