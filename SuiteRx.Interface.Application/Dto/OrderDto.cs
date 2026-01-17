namespace SuiteRx.Interface.Application.Dto
{
    public class OrderDto
    {
        public string? PatientFirstName { get; set; }
        public string? PatientLastName { get; set; }
        public string? DrugName { get; set; }
        public string? DrugQty { get; set; }
        public string? HCPName { get; set; }
        public DateTime? PrescriptionDate { get; set; }
    }
}
