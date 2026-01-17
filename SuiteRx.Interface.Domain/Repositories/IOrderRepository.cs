using SuiteRx.Interface.Domain.Entities;

namespace SuiteRx.Interface.Domain
{
    public interface IOrderRepository
    {
        Task<Hl7Message> CreateOrder(Hl7Message request);
    }
}
