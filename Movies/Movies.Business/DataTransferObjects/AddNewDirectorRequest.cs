using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Movies.Business.DataTransferObjects
{
    public class AddNewDirectorRequest
    {
        [Required(ErrorMessage = "Name is not defined")]
        public string Name { get; set; }

        [Required(ErrorMessage = "LastName is not defined")]
        public string LastName { get; set; }
        public string Details { get; set; }
        public string ImagePath { get; set; }
    }
}
