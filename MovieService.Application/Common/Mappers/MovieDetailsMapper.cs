using System;
using System.Collections.Generic;
using System.Text;
using MovieService.Application.Common.DTOs;
using MovieService.Domain.Movies;

namespace MovieService.Application.Common.Mappers
{
    public class MovieDetailsMapper
    {
        public static MovieDetailsDto ToDto(Movie movie)
        {
            var money = MoneyMapper.ToDto(movie);

            return new MovieDetailsDto(movie.Details.Synopsis, money);
        }
    }
}
