using SuiteRx.Interface.Application.Dto;

namespace SuiteRx.Interface.Application.Services
{
    public interface IAuthService
    {
        Task<string> LoginAsync(LoginRequestDto request);
    }
}
