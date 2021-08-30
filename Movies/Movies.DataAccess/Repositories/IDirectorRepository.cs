using Movies.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Movies.DataAccess.Repositories
{
    public interface IDirectorRepository : IRepository<Director>
    {
        Director GetMovieListByDirector(int directorId);
        IList<Director> Search(string name);
    }
}
