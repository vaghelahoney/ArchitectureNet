using SuiteRx.Interface.Domain.Entities;

namespace SuiteRx.Interface.Domain.Repositories
{
    public interface IDepartmentRepository
    {
        Task<Department> CreateDepartmentAsync(Department request);
        Task<List<Department>> GetAllDepartmentsAsync();
        Task<Department?> GetDepartmentByIdAsync(int id);
        Task<bool> UpdateDepartmentAsync(Department request);
        Task<bool> DeleteDepartmentAsync(int id);
    }
}
