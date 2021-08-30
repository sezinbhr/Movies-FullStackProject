using Movies.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Movies.DataAccess.Repositories
{
    public interface IMovieRepository : IRepository<Movie>
    {
        Movie GetMoviesList(int movieId);
        IList<Movie> Search(string title);
    }
}
