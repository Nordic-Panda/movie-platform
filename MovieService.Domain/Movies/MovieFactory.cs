using MovieService.Domain.Enums;
using MovieService.Domain.Exceptions;
using MovieService.Domain.ValueObjects;

namespace MovieService.Domain.Movies
{
    public static class MovieFactory
    {
        public static Movie Create(
            string title,
            TimeSpan duration,
            Genre genre,
            MovieDetails details)
        {
            if (string.IsNullOrWhiteSpace(title))
                throw new DomainException(
                    MovieErrors.MovieTitleEmptyCode,
                    MovieErrors.MovieTitleEmptyMessage);

            if (title.Length < MovieRules.TitleMinLength)
                throw new DomainException(
                    MovieErrors.MovieTitleTooShortCode,
                    MovieErrors.MovieTitleTooShortMessage(MovieRules.TitleMinLength));

            if (title.Length > MovieRules.TitleMaxLength)
                throw new DomainException(
                    MovieErrors.MovieTitleTooLongCode,
                    MovieErrors.MovieTitleTooLongMessage(MovieRules.TitleMaxLength));

            if (duration < MovieRules.MinDuration)
                throw new DomainException(
                    MovieErrors.MovieDurationTooShortCode,
                    MovieErrors.MovieDurationTooShortMessage((int)MovieRules.MinDuration.TotalMinutes));

            if (duration > MovieRules.MaxDuration)
                throw new DomainException(
                    MovieErrors.MovieDurationTooLongCode,
                    MovieErrors.MovieDurationTooLongMessage((int)MovieRules.MinDuration.TotalMinutes));

            if (!Enum.IsDefined(typeof(Genre), genre))
                throw new DomainException(
                    MovieErrors.MovieGenreInvalidCode,
                    MovieErrors.MovieGenreInvalidMessage);

            return new Movie(
                Guid.NewGuid(),
                title,
                duration,
                genre,
                details);
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