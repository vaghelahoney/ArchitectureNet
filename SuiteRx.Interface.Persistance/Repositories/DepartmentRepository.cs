using Microsoft.EntityFrameworkCore;
using SuiteRx.Interface.Domain.Entities;
using SuiteRx.Interface.Domain.Repositories;
using SuiteRx.Interface.Persistance.Contexts;

namespace SuiteRx.Interface.Persistance.Repositories
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly PharmacyDBContext _dbContext;

        public DepartmentRepository(PharmacyDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Department> CreateDepartmentAsync(Department request)
        {
            if (request != null)
            {
                try
                {
                    await _dbContext.Departments.AddAsync(request);
                    await _dbContext.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
            return request;
        }

        public async Task<List<Department>> GetAllDepartmentsAsync()
        {
            return await _dbContext.Departments.AsNoTracking().ToListAsync();
        }

        public async Task<Department?> GetDepartmentByIdAsync(int id)
        {
            return await _dbContext.Departments.FindAsync(id);
        }

        public async Task<bool> UpdateDepartmentAsync(Department request)
        {
            var existing = await _dbContext.Departments.FindAsync(request.Id);
            if (existing != null)
            {
                existing.Name = request.Name;
                existing.Description = request.Description;
                existing.Code = request.Code;
                existing.Phone = request.Phone;
                existing.IsActive = request.IsActive;
                
                _dbContext.Departments.Update(existing);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> DeleteDepartmentAsync(int id)
        {
            var existing = await _dbContext.Departments.FindAsync(id);
            if (existing != null)
            {
                _dbContext.Departments.Remove(existing);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
