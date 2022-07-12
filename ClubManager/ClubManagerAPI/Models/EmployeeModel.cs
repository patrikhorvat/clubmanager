namespace ClubManagerAPI.Models
{
    public class EmployeeModel
    {
        public int Id { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public StatusModel Status { get; set; }
        public DateTimeOffset? Birthday { get; set; }
        public DateTimeOffset? DateEmployeed { get; set; }
        public DateTimeOffset? EmployeedTo { get; set; }
        public string? Oib { get; set; }
        public ClubModel Club { get; set; }
        public UserModel? User { get; set; }

        public UserModel UserCreated { get; set; }
        public DateTimeOffset? DateCreated { get; set; }
        public UserModel? UserLastModified { get; set; }
        public DateTimeOffset? LastModified { get; set; }

    }
}
