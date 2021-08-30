using AutoMapper;
using Movies.Business.DataTransferObjects;
using Movies.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Movies.Business.Extensions
{
    public static class Converters
    {
        public static List<GenreListResponse> ConvertToListResponse(this List<Genre> genres, IMapper mapper )
        {
            //var result = new List<GenreListResponse>();
            //genres.ForEach(g => result.Add(new GenreListResponse 
            //{ 
            //    Id = g.Id, 
            //    Name = g.Name 
            //}));

            return mapper.Map<List<GenreListResponse>>(genres);
        }

        public static List<MovieListResponse> ConvertToListResponse(this List<Movie> movies, IMapper mapper)
        {
            return mapper.Map<List<MovieListResponse>>(movies);
        }

        public static List<DirectorListResponse> ConvertToListResponse(this List<Director> directors, IMapper mapper)
        {
            return mapper.Map<List<DirectorListResponse>>(directors);
        }



        public static Genre ConvertToGenre(this AddNewGenreRequest request, IMapper mapper)
        {
            return mapper.Map<Genre>(request);
        }

        public static Movie ConvertToMovie(this AddNewMovieRequest request, IMapper mapper)
        {
            return mapper.Map<Movie>(request);
        }

        public static Director ConvertToDirector(this AddNewDirectorRequest request, IMapper mapper)
        {
            return mapper.Map<Director>(request);
        }


        public static GenreListResponse ConvertFromEntity(this Genre genre, IMapper mapper )
        {
            return mapper.Map<GenreListResponse>(genre);
        }

        public static MovieListResponse ConvertFromEntity(this Movie movie, IMapper mapper)
        {
            return mapper.Map<MovieListResponse>(movie);
        }

        public static DirectorListResponse ConvertFromEntity(this Director director, IMapper mapper)
        {
            return mapper.Map<DirectorListResponse>(director);
        }


        public static Genre ConvertToEntity(this EditGenreRequest request, IMapper mapper)
        {
            return mapper.Map<Genre>(request);
        }

        public static Movie ConvertToEntity(this EditMovieRequest request, IMapper mapper)
        {
            return mapper.Map<Movie>(request);
        }

        public static Director ConvertToEntity(this EditDirectorRequest request, IMapper mapper)
        {
            return mapper.Map<Director>(request);
        }

        public static MovieGenreListResponse ConvertFromEntityToMovies(this Genre genre, IMapper mapper)
        {
            return mapper.Map<MovieGenreListResponse>(genre);
        }

        public static MovieDirectorListResponse ConvertFromEntityToMovies(this Director director, IMapper mapper)
        {
            return mapper.Map<MovieDirectorListResponse>(director);
        }

    }
}
