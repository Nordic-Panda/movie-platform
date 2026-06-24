using MovieService.Domain.Enums;
using MovieService.Domain.Exceptions;

namespace MovieService.Domain.Movies
{
    public static class MovieFactory
    {
        public static Movie Create(string title, TimeSpan duration, Genre genre)
        {
            if (string.IsNullOrWhiteSpace(title))
                throw new DomainException(
                    MovieErrors.MovieTitleEmptyCode,
                    MovieErrors.MovieTitleEmptyMessage);

            if (duration <= TimeSpan.Zero)
                throw new DomainException(
                    MovieErrors.MovieDurationInvalidCode,
                    MovieErrors.MovieDurationInvalidMessage);

            if (!Enum.IsDefined(typeof(Genre), genre))
                throw new DomainException(
                    MovieErrors.MovieGenreInvalidCode,
                    MovieErrors.MovieGenreInvalidMessage);

            return new Movie(Guid.NewGuid(), title, duration, genre);
        }
    }
}



//using MovieService.Domain.Entities;
//using MovieService.Domain.Enums;
//using MovieService.Domain.Exceptions;

//namespace MovieService.Domain.Factories
//{
//    public static class MovieFactory
//    {
//        public static Movie Create(string title, TimeSpan duration, Genre genre)
//        {
//            if (string.IsNullOrWhiteSpace(title))
//                throw new DomainException(
//                    MovieErrors.MovieTitleEmptyCode,
//                    MovieErrors.MovieTitleEmptyMessage
//                    );

//            if (duration <= TimeSpan.Zero)
//                throw new DomainException(
//                    MovieErrors.MovieDurationInvalidCode,
//                    MovieErrors.MovieDurationInvalidMessage
//                    );

//            if (!Enum.IsDefined(typeof(Genre), genre))
//                throw new DomainException(
//                    MovieErrors.MovieGenreInvalidCode,
//                    MovieErrors.MovieGenreInvalidMessage
//                    );

//            return new Movie(
//                Guid.NewGuid(),
//                title,
//                duration,
//                genre);
//        }
//    }
//}