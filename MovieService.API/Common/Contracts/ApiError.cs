namespace MovieService.API.Common.Contracts
{
    public class ApiError
    {
        public string Code { get; set; } = "";
        public string Message { get; set; } = "";
        public Dictionary<string, string[]> Details { get; set; } = new();
    }
}
