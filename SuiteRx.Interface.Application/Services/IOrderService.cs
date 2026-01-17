using SuiteRx.Interface.Application.Dto;

namespace SuiteRx.Interface.Application.Services
{
    public interface IOrderService
    {
        Task Refill(HL7MessageDto request);
    }
}
