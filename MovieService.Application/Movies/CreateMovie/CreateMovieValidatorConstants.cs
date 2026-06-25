namespace MovieService.Application.Movies.CreateMovie
{
    public class CreateMovieValidatorConstants
    {
        public const int TitleMinLength = 1;
        public const int TitleMaxLength = 200;

        public const int DurationMinMinutes = 0;
        public const int DurationMaxMinutes = 600;

        public const int CurrencyIsoMinLength = 3;
    }
}
