using SuiteRx.Interface.Application.Dto;
using SuiteRx.Interface.Domain;
using SuiteRx.Interface.Domain.Entities;
using System.Globalization;

namespace SuiteRx.Interface.Application.Services.Impl
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderService;
        public OrderService(IOrderRepository orderService)
        {
            _orderService = orderService;
        }

        public async Task Refill(HL7MessageDto request)
        {
            try
            {
                var objrequest = new Hl7Message
                {
                    SendingApplication = request.MSH.SendingApplication,
                    SendingFacility = request.MSH.SendingFacility,
                    ReceivingApplication = request.MSH.ReceivingApplication,
                    ReceivingFacility = request.MSH.ReceivingFacility,
                    MessageType = request.MSH.MessageType,
                    TriggerEvent = request.MSH.TriggerEvent,
                    MessageControlId = request.MSH.MessageControlID,
                    Version = request.MSH.Version,

                    PatientId = request.PID.PatientID,
                    PatientName = request.PID.PatientName,
                    Facility = request.PD1.Facility,
                    AttendingDoctor = request.PD1.AttendingDoctor,
                    VisitNumber = request.PV1.VisitNumber,

                    OrderControl = request.ORC.OrderControl,
                    PlacerOrderNumber = request.ORC.PlacerOrderNumber,
                    FillerOrderNumber = request.ORC.FillerOrderNumber,
                    OrderStatus = request.ORC.OrderStatus,

                    DateTimeOfTransaction = !string.IsNullOrEmpty(request.ORC.DateTimeOfTransaction) ? DateTime.ParseExact(request.ORC.DateTimeOfTransaction, "yyyyMMddHHmmss", CultureInfo.InvariantCulture) : null,

                    OrderingProvider = request.ORC.OrderingProvider,
                    DiagnosisCode = request.DG1.DiagnosisCode,
                    DiagnosisDescription = request.DG1.DiagnosisDescription
                };

                await _orderService.CreateOrder(objrequest);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
