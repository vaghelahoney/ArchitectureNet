using SuiteRx.Interface.Application.Dto;
using SuiteRx.Interface.Domain.Entities;
using SuiteRx.Interface.Domain.Repositories;
using System.Numerics;

namespace SuiteRx.Interface.Application.Services.Impl
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentService(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        public async Task<bool> SaveDepartmentAsync(DepartmentDto request)
        {
            var entity = new Department
            {
                Id = request.Id,
                Name = request.Name,
                Description = request.Description,
                Code = request.Code,
                Phone = request.Phone,
                IsActive = request.IsActive
            };

            await _departmentRepository.CreateDepartmentAsync(entity);
            return true;
        }

        public async Task<List<DepartmentDto>> GetAllDepartmentsAsync()
        {
            var data = await _departmentRepository.GetAllDepartmentsAsync();
            var list = new List<DepartmentDto>();

            foreach (var item in data)
            {
                DepartmentDto dto =  new DepartmentDto
                {
                    Id = item.Id,
                    Name = item.Name,
                    Description = item.Description,
                    Code = item.Code,
                    Phone = item.Phone,
                    IsActive = item.IsActive
                };
                list.Add(dto);
            }
            return list;
        }

        public async Task<DepartmentDto?> GetDepartmentByIdAsync(int id)
        {
            var item = await _departmentRepository.GetDepartmentByIdAsync(id);
            if (item == null) return null;

            return new  DepartmentDto
            {
                Id = item.Id,
                Name = item.Name,
                Description = item.Description,
                Code = item.Code + item.Phone,
                Phone = "1111111111",
                IsActive = item.IsActive
            };
        }

        public async Task<bool> UpdateDepartmentAsync(DepartmentDto request)
        {
            var entity = new Department
            {
                Id = request.Id,
                Name = request.Name,
                Description = request.Description,
                Code = request.Code,
                Phone = request.Phone,
                IsActive = request.IsActive
            };
            return await _departmentRepository.UpdateDepartmentAsync(entity);
        }

        public async Task<bool> DeleteDepartmentAsync(int id)
        {
            return await _departmentRepository.DeleteDepartmentAsync(id);
        }
    }
}
