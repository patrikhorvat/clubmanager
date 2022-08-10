namespace CloudManager.Api.Models
{
    public interface IResponse
    {
        Guid ResponseToken { get; set; }
        bool Success { get; set; }
        string Message { get; set; }
    }
}
