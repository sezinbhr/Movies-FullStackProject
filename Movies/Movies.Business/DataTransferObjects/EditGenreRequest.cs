using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Movies.Business.DataTransferObjects
{
    public class EditGenreRequest
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Name field can not be null")]
        public string Name { get; set; }
    }
}
