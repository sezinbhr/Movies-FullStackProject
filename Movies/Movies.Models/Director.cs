using System;
using System.Collections.Generic;
using System.Text;

namespace Movies.Models
{
    public class Director : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Details { get; set; }
        public string ImagePath { get; set; }

        public virtual IList<Movie> Movies { get; set; }

        public Director() : base ()
        {
            this.Movies = new List<Movie>();
        }
    }
}
