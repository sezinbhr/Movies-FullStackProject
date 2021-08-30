using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Movies.Business.DataTransferObjects
{
    public class EditMovieRequest
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Title  can not be null")]
        public string Title { get; set; }
        public decimal? Rating { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
    }
}
