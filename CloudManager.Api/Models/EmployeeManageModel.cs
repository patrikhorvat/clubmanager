namespace CloudManager.Api.Models
{
    public class EmployeeManageModel
    {
        public int? Id { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public int? Type { get; set; } = null!;
    }
}
