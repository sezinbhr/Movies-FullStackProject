using Microsoft.EntityFrameworkCore;
using Movies.DataAccess.Data;
using Movies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Movies.DataAccess.Repositories
{
    public class EFDirectorRepository : IDirectorRepository
    {
        private MoviesDbContext db;

        public EFDirectorRepository(MoviesDbContext moviesDbContext)
        {
            db = moviesDbContext;
        }
        public Director Add(Director entity)
        {
            db.Directors.Add(entity);
            db.SaveChanges();
            return entity;
        }

        public void Delete(int id)
        {
            db.Directors.Remove(GetById(id));
            db.SaveChanges();
        }

        public IList<Director> GetAll()
        {
            return db.Directors.ToList();
        }

        public Director GetById(int id)
        {
            return db.Directors.AsNoTracking().FirstOrDefault(x => x.Id == id);
        }

        public Director GetMovieListByDirector(int directorId)
        {
            return db.Directors.Include(director => director.Movies).Where(director => director.Id == directorId).FirstOrDefault();
        }

        public IList<Director> GetWithCriteria(Func<Director, bool> criteria)
        {
            return db.Directors.Where(criteria).ToList();
        }

        public IList<Director> Search(string name)
        {
            IQueryable<Director> query = db.Directors;

            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(movie => movie.Name.Contains(name));
            }

            else
            {
                query = null;
            }

            return query.ToList();
        }

        public Director Update(Director director)
        {
            db.Entry(director).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
            return director;
        }
    }
}
