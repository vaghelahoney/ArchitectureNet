using SuiteRx.Interface.Application.Dto;

namespace SuiteRx.Interface.Application.Services
{
    public interface IDepartmentService
    {
        Task<bool> SaveDepartmentAsync(DepartmentDto request);
        Task<List<DepartmentDto>> GetAllDepartmentsAsync();
        Task<DepartmentDto?> GetDepartmentByIdAsync(int id);
        Task<bool> UpdateDepartmentAsync(DepartmentDto request);
        Task<bool> DeleteDepartmentAsync(int id);
    }
}
