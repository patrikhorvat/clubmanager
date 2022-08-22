namespace CloudManager.Api.Models
{
    public class AddTeamMemberRequest: RequestBase
    {
        public int TeamId { get; set; }
        public int MemberId { get; set; }
    }
}
