using Movies.Business.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Movies.Business
{
    public interface IDirectorService
    {
        IList<DirectorListResponse> GetAllDirectors();

        int AddDirector(AddNewDirectorRequest request);
        DirectorListResponse GetDirectorsById(int id);
        int UpdateDirector(EditDirectorRequest request);
        void DeleteDirector(int id);

        MovieDirectorListResponse GetMoviesByDirectorId(int directorId);
        IList<DirectorListResponse> SearchDirector(string name);
    }
}
