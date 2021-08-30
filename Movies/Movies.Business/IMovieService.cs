using Movies.Business.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Movies.Business
{
    public interface IMovieService
    {
        IList<MovieListResponse> GetAllMovies();
        MovieListResponse GetMoviesById(int id);

        int AddMovie(AddNewMovieRequest request);
        int UpdateMovie(EditMovieRequest request);
        void DeleteMovie(int id);
        IList<MovieListResponse> SearchMovie(string title);
    }
}
