using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Movies.Business.DataTransferObjects
{
    public class AddNewMovieRequest
    {
        [Required(ErrorMessage = "Title is not defined")]
        public string Title { get; set; }
        public decimal? Rating { get; set; }
        public string Description { get; set; }

        [Required(ErrorMessage = "ImageUrl is not defined")]
        public string ImageUrl { get; set; }

        [Required(ErrorMessage = "GenreId is not defined")]
        public int GenreId { get; set; }

        [Required(ErrorMessage = "DirectorId is not defined")]
        public int DirectorId { get; set; }
    }
}
