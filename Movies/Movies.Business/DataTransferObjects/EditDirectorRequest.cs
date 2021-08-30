using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Movies.Business.DataTransferObjects
{
    public class EditDirectorRequest
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name field can not be null")]
        public string Name { get; set; }

        [Required(ErrorMessage = "LastName field can not be null")]
        public string LastName { get; set; }
        public string Details { get; set; }
        public string ImagePath { get; set; }
    }
}
