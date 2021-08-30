using AutoMapper;
using Movies.Business.DataTransferObjects;
using Movies.Business.Extensions;
using Movies.DataAccess.Repositories;
using Movies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Movies.Business
{
    public class DirectorService : IDirectorService
    {
        private IDirectorRepository directorRepository;
        private IMapper mapper;

        public DirectorService(IDirectorRepository directorRepository, IMapper mapper)
        {
            this.directorRepository = directorRepository;
            this.mapper = mapper;
        }
        public int AddDirector(AddNewDirectorRequest request)
        {
            var newDirector = request.ConvertToDirector(mapper);
            directorRepository.Add(newDirector);
            return newDirector.Id;
        }

        public void DeleteDirector(int id)
        {
            directorRepository.Delete(id);
        }

        public IList<DirectorListResponse> GetAllDirectors()
        {
            var dtoList = directorRepository.GetAll().ToList();
            var result = dtoList.ConvertToListResponse(mapper);
            return result;
        }

        public DirectorListResponse GetDirectorsById(int id)
        {
            Director director = directorRepository.GetById(id);
            return director.ConvertFromEntity(mapper);
        }

        public MovieDirectorListResponse GetMoviesByDirectorId(int directorId)
        {
            Director director = directorRepository.GetMovieListByDirector(directorId);
            return director.ConvertFromEntityToMovies(mapper);
        }

        public IList<DirectorListResponse> SearchDirector(string name)
        {
            var dtoList = directorRepository.Search(name).ToList();
            return dtoList.ConvertToListResponse(mapper);
        }

        public int UpdateDirector(EditDirectorRequest request)
        {
            var director = request.ConvertToEntity(mapper);
            int id = directorRepository.Update(director).Id;
            return id;
        }
    }
}
