using AutoMapper;
using Movies.Business.DataTransferObjects;
using Movies.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Movies.Business.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Genre, GenreListResponse>().ReverseMap();
            CreateMap<Movie, MovieListResponse>().ReverseMap();
            CreateMap<Director, DirectorListResponse>().ReverseMap();

            CreateMap<Genre, MovieGenreListResponse>().ReverseMap();
            CreateMap<Director, MovieDirectorListResponse>().ReverseMap();

            CreateMap<Genre, AddNewGenreRequest>().ReverseMap();
            CreateMap<Movie, AddNewMovieRequest>().ReverseMap();
            CreateMap<Director, AddNewDirectorRequest>().ReverseMap();

            CreateMap<Genre, EditGenreRequest>().ReverseMap();
            CreateMap<Movie, EditMovieRequest>().ReverseMap();
            CreateMap<Director, EditDirectorRequest>().ReverseMap();
        }
    }
}
