using SuiteRx.Interface.Application.Dto;

namespace SuiteRx.Interface.Application.Services
{
    public interface IAddressService
    {
        Task<bool> SaveAddressAsync(AddressDto request);
        Task<List<AddressDto>> GetAllAddressesAsync();
        Task<AddressDto?> GetAddressByIdAsync(int id);
        Task<bool> UpdateAddressAsync(AddressDto request);
        Task<bool> DeleteAddressAsync(int id);
    }
}
