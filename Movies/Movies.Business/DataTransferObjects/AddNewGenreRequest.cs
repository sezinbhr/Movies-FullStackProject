using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Movies.Business.DataTransferObjects
{
    public class AddNewGenreRequest
    {
        [Required(ErrorMessage ="Genre name is not defined")]
        public string Name { get; set; }
    }
}
