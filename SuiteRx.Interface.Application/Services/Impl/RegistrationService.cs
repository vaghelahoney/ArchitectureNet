using SuiteRx.Interface.Application.Dto;
using SuiteRx.Interface.Domain.Entities;
using SuiteRx.Interface.Persistance;
using SuiteRx.Interface.Persistance.Extension;
using SuiteRx.Interface.Persistance.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuiteRx.Interface.Application.Services.Impl
{
    public class RegistrationService : IRegistrationService
    {

        private readonly IRegistrationRepository _registrationRepository;

        public RegistrationService(IRegistrationRepository registrationRepository)
        {
            _registrationRepository = registrationRepository;
        }


        public async Task<bool> SaveRegistrationAsync(RegistrationDto student)
        {
            var registrationEntity = new Registration
            {
               Id=student.Id,
               FullName=student.FullName,
               Email=student.Email, 
               PasswordHash= PasswordHelper.PasswordGenerator(student.PasswordHash.Length),   
               IsActive = student.IsActive,
               PhoneNumber=student.PhoneNumber, 
               Role =   student.Role,
            };


            Registration Registration = await RegistrationAsync(registrationEntity);

            return true;



        }

        public async Task<Registration> RegistrationAsync(Registration student)
        {
            return await _registrationRepository.CreateRegistration(student);
        }

        public async Task<List<RegistrationDto>> GetAllRegistration()
        {
           List<Registration> data = await _registrationRepository.GetAllRegistration();
            RegistrationDto registrationdto = new RegistrationDto();
            List<RegistrationDto> registrationdList = new List<RegistrationDto>();
            for (int i = 0; i < data.Count(); i++)
            {
                registrationdto.Id = data[i].Id;
                registrationdto.FullName = data[i].FullName;
                registrationdto.Email = data[i].Email;
                registrationdto.PhoneNumber = data[i].PhoneNumber;
                registrationdto.IsActive = data[i].IsActive;
                registrationdto.CreatedAt = data[i].CreatedAt;
                registrationdto.Role = data[i].Role;
                registrationdList.Add(registrationdto);
            }

            return registrationdList;
        }
    }
}
