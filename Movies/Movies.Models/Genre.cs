using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Movies.Models
{
    public class Genre : IEntity
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Name field can not be null!")]
        public string Name { get; set; }

        public virtual IList<Movie> Movies { get; set; }

        public Genre() : base()
        {
            this.Movies = new List<Movie>();
        }
    }
}
