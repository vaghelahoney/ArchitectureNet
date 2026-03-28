using SuiteRx.Interface.Domain.Entities;

namespace SuiteRx.Interface.Domain.Repositories
{
    public interface IAddressRepository
    {
        Task<Address> CreateAddressAsync(Address request);
        Task<List<Address>> GetAllAddressesAsync();
        Task<Address?> GetAddressByIdAsync(int id);
        Task<bool> UpdateAddressAsync(Address request);
        Task<bool> DeleteAddressAsync(int id);
    }
}
