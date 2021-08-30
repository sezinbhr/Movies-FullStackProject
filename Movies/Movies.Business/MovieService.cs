using AutoMapper;
using Movies.Business.DataTransferObjects;
using Movies.Business.Extensions;
using Movies.DataAccess.Repositories;
using Movies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Movies.Business
{
    public class MovieService : IMovieService
    {
        private IMovieRepository movieRepository;
        private IMapper mapper;

        public MovieService(IMovieRepository movieRepository, IMapper mapper)
        {
            this.movieRepository = movieRepository;
            this.mapper = mapper;
        }

        public int AddMovie(AddNewMovieRequest request)
        {
            var newMovie = request.ConvertToMovie(mapper);
            movieRepository.Add(newMovie);
            return newMovie.Id;
        }

        public void DeleteMovie(int id)
        {
            movieRepository.Delete(id);
        }

        public IList<MovieListResponse> GetAllMovies()
        {
            var dtolist = movieRepository.GetAll().ToList();
            var result = dtolist.ConvertToListResponse(mapper);
            return result;
        }

        public MovieListResponse GetMoviesById(int id)
        {
            Movie movie = movieRepository.GetById(id);
            return movie.ConvertFromEntity(mapper);

        }

        public IList<MovieListResponse> SearchMovie(string title)
        {
            var dtoList = movieRepository.Search(title).ToList();
            return dtoList.ConvertToListResponse(mapper);
            
        }

        public int UpdateMovie(EditMovieRequest request)
        {
            var movie = request.ConvertToEntity(mapper);
            int id = movieRepository.Update(movie).Id;
            return id;
        }
    }
}
