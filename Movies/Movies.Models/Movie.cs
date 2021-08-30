using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Movies.Models
{
    public class Movie : IEntity
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Title field can not be null!")]
        [MinLength(3,ErrorMessage ="Title should contain at least 3 characters")]
        [MaxLength(200, ErrorMessage = "Title should contain no more than 200 characters")]
        public string Title { get; set; }
        public decimal? Rating { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }

        public int GenreId { get; set; }
        public int DirectorId { get; set; }

        //Navigation Property

        public virtual Genre Genre { get; set; }
        public virtual Director Director { get; set; }
    }
}
