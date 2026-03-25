namespace SuiteRx.Interface.Application.Dto
{
    public record DepartmentDto
    {
        public int Id { get; init; }
        public string? Name { get; init; }
        public string? Description { get; init; }
        public string? Code { get; init; }
        public string? Phone { get; init; }
        public bool IsActive { get; init; }
    }
}
