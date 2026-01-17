using SuiteRx.Interface.Application.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuiteRx.Interface.Application.Services
{
    public interface IRegistrationService
    {
        Task<bool> SaveRegistrationAsync(RegistrationDto request);

        Task<List<RegistrationDto>> GetAllRegistration();
    }
}
