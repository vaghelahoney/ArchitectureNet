using SuiteRx.Interface.Application.Dto;
using SuiteRx.Interface.Domain.Entities;
using SuiteRx.Interface.Domain.Repositories;

namespace SuiteRx.Interface.Application.Services.Impl
{
    public class ClothesService : IClothesService
    {
        private readonly IClothesRepository _clothesRepository;

        public ClothesService(IClothesRepository clothesRepository)
        {
            _clothesRepository = clothesRepository;
        }

        public async Task<bool> SaveClothesAsync(ClothesDto request)
        {
            var clothesEntity = new Clothes
            {
                Id = request.Id,
                Name = request.Name,
                Description = request.Description,
                Price = request.Price,
                Category = request.Category,
                Image = request.Image,
            };

            await _clothesRepository.CreateClothesAsync(clothesEntity);
            return true;
        }

        public async Task<List<ClothesDto>> GetAllClothesAsync()
        {
            List<Clothes> data = await _clothesRepository.GetAllClothesAsync();
            List<ClothesDto> clothesList = new List<ClothesDto>();

            foreach (var item in data)
            {
                var dto = new ClothesDto
                {
                    Id = item.Id,
                    Name = item.Name,
                    Description = item.Description,
                    Price = item.Price,
                    Category = item.Category,
                    Image = item.Image,
                };
                clothesList.Add(dto);
            }

            return clothesList;
        }

        public async Task<ClothesDto?> GetClothesByIdAsync(int id)
        {
            var item = await _clothesRepository.GetClothesByIdAsync(id);
            if (item == null) return null;

            return new ClothesDto
            {
                Id = item.Id,
                Name = item.Name,
                Description = item.Description,
                Price = item.Price,
                Category = item.Category,
                Image = item.Image,
               
            };
        }

        public async Task<bool> UpdateClothesAsync(ClothesDto request)
        {
            var entity = new Clothes
            {
                Id = request.Id,
                Name = request.Name,
                Description = request.Description,
                Price = request.Price,
                Category = request.Category,
                Image = request.Image,
            };
            return await _clothesRepository.UpdateClothesAsync(entity);
        }

        public async Task<bool> DeleteClothesAsync(int id)
        {
            return await _clothesRepository.DeleteClothesAsync(id);
        }
    }
}
