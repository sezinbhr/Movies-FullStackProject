using System;
using System.Collections.Generic;
using System.Text;

namespace Movies.Business.DataTransferObjects
{
    public class MovieGenreListResponse
    {
        public IList<MovieListResponse> Movies { get; set; }
    }
}
