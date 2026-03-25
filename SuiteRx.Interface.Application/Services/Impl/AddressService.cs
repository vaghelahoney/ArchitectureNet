using SuiteRx.Interface.Application.Dto;
using SuiteRx.Interface.Domain.Entities;
using SuiteRx.Interface.Domain.Repositories;

namespace SuiteRx.Interface.Application.Services.Impl
{
    public class AddressService : IAddressService
    {
        private readonly IAddressRepository _addressRepository;

        public AddressService(IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }

        public async Task<bool> SaveAddressAsync(AddressDto request)
        {
            var entity = new Address
            {
                Id = request.Id,
                Street = request.Street,
                City = request.City,
                DepartmentId = request.DepartmentId
            };

            await _addressRepository.CreateAddressAsync(entity);
            return true;
        }

        public async Task<List<AddressDto>> GetAllAddressesAsync()
        {
            var data = await _addressRepository.GetAllAddressesAsync();
            var list = new List<AddressDto>();

            foreach (var item in data)
            {
                var dto = new AddressDto
                {
                    Id = item.Id,
                    Street = item.Street,
                    City = item.City,
                    DepartmentId = item.DepartmentId
                };
                list.Add(dto);
            }

            return list;
        }

        public async Task<AddressDto?> GetAddressByIdAsync(int id)
        {
            var item = await _addressRepository.GetAddressByIdAsync(id);
            if (item == null) return null;

            return new AddressDto
            {
                Id = item.Id,
                Street = item.Street,
                City = item.City,
                DepartmentId = item.DepartmentId
            };
        }

        public async Task<bool> UpdateAddressAsync(AddressDto request)
        {
            var entity = new Address
            {
                Id = request.Id,
                Street = request.Street,
                City = request.City,
                DepartmentId = request.DepartmentId
            };
            return await _addressRepository.UpdateAddressAsync(entity);
        }

        public async Task<bool> DeleteAddressAsync(int id)
        {
            return await _addressRepository.DeleteAddressAsync(id);
        }
    }
}
