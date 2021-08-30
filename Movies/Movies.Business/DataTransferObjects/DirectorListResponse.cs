using System;
using System.Collections.Generic;
using System.Text;

namespace Movies.Business.DataTransferObjects
{
    public class DirectorListResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Details { get; set; }
        public string ImagePath { get; set; }
    }
}
