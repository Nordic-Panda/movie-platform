namespace MovieService.Application.Common.Interfaces
{
    public interface IPaginationSettings
    {
        int DefaultPageSize { get; }
        int DefaultPage { get; }
    }
}
