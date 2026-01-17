namespace SuiteRx.Interface.Application.Dto
{
    public class HL7MessageDto
    {

        public MSHDto MSH { get; set; }
        public PIDDto PID { get; set; }
        public PD1Dto PD1 { get; set; }
        public PV1Dto PV1 { get; set; }
        public ORCDto ORC { get; set; }
        public OBRDto OBR { get; set; }
        public DG1Dto DG1 { get; set; }
    }

    public class MSHDto
    {
        public string? SendingApplication { get; set; }
        public string? SendingFacility { get; set; }
        public string? ReceivingApplication { get; set; }
        public string? ReceivingFacility { get; set; }
        public string? MessageType { get; set; }
        public string? TriggerEvent { get; set; }
        public string? MessageControlID { get; set; }
        public string? Version { get; set; }
    }

    public class PIDDto
    {
        public string? PatientID { get; set; }
        public string? PatientName { get; set; }
        public string? DOB { get; set; }
        public string? Gender { get; set; }
        public string? Address { get; set; }
    }

    public class PD1Dto
    {
        public string? Facility { get; set; }
        public string? AttendingDoctor { get; set; }
    }

    public class PV1Dto
    {
        public string? VisitNumber { get; set; }
        public string? AttendingDoctor { get; set; }
    }

    public class ORCDto
    {
        public string? OrderControl { get; set; }
        public string? PlacerOrderNumber { get; set; }
        public string? FillerOrderNumber { get; set; }
        public string? OrderStatus { get; set; }
        public string? DateTimeOfTransaction { get; set; }
        public string? OrderingProvider { get; set; }
    }

    public class OBRDto
    {
        public string? SetID { get; set; }
        public string? PlacerOrderNumber { get; set; }
        public string? FillerOrderNumber { get; set; }
        public string? UniversalServiceID { get; set; }
        public string? ObservationDateTime { get; set; }
        public string? OrderingProvider { get; set; }
    }

    public class DG1Dto
    {
        public string? DiagnosisCode { get; set; }
        public string? DiagnosisDescription { get; set; }
    }
}
