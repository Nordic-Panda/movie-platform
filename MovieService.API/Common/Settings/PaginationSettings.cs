using MovieService.Application.Common.Interfaces;

namespace MovieService.API.Common.Settings
{
    public class PaginationSettings : IPaginationSettings
    {
        public int DefaultPageSize { get; init; }

        public int DefaultPage { get; init; }
    }
}
