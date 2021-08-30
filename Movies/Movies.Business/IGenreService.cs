using Movies.Business.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Movies.Business
{
    public interface IGenreService
    {
        IList<GenreListResponse> GetAllGenres();

        int AddGenre(AddNewGenreRequest request);
        GenreListResponse GetGenresById(int id);

        MovieGenreListResponse GetMoviesByGenreId(int genreId);


        int UpdateGenre(EditGenreRequest request);
        void DeleteGenre(int id);
    }
}
