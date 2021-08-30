using System;
using System.Collections.Generic;
using System.Text;

namespace Movies.Business.DataTransferObjects
{
    public class MovieListResponse
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public decimal? Rating { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
    }
}
