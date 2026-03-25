namespace SuiteRx.Interface.Application.Dto
{
    public record AddressDto
    {
        public int Id { get; init; }
        public string? Street { get; init; }
        public string? City { get; init; }
        public int DepartmentId { get; init; }
    }
}
