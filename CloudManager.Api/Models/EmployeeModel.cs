namespace CloudManager.Api.Models
{
    public class EmployeeModel
    {
        public int Id { get; set; }
        public DateTimeOffset DateCreated { get; set; }
        public int? UserCreatedId { get; set; }
        public string? UserCreatedDisplayName { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public int? StatusId { get; set; }
        public string? StatusName { get; set; }
        public DateTimeOffset? Birthday { get; set; }
        public DateTimeOffset? DateEmployeed { get; set; }
        public DateTimeOffset? EmployedTo { get; set; }
        public string? Oib { get; set; }
        public int? ClubId { get; set; }
        public string? ClubName { get; set; }
        public DateTimeOffset? LastModified { get; set; }
        public int? UserLastModifiedId { get; set; }
        public string? UserLastModifiedDisplayName { get; set; }
    }
}
