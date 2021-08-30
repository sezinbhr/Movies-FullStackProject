using Microsoft.EntityFrameworkCore;
using Movies.DataAccess.Data;
using Movies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Movies.DataAccess.Repositories
{
    public class EFMovieRepository : IMovieRepository
    {
        private MoviesDbContext db;

        public EFMovieRepository(MoviesDbContext moviesDbContext)
        {
            db = moviesDbContext;
        }
        public Movie Add(Movie entity)
        {
            db.Movies.Add(entity);
            db.SaveChanges();
            return entity;
        }

        public void Delete(int id)
        {
            db.Movies.Remove(GetById(id));
            db.SaveChanges();
        }

        public IList<Movie> GetAll()
        {
            return db.Movies.Include(movie => movie.Director).ToList();
        }

        public Movie GetById(int id)
        {
            return db.Movies.AsNoTracking().FirstOrDefault(x => x.Id == id);
        }

        public Movie GetMoviesList(int movieId)
        {
            return db.Movies.Include(movie => movie.Director).Where(movie => movie.Id == movieId).FirstOrDefault();
        }

        public IList<Movie> GetWithCriteria(Func<Movie, bool> criteria)
        {
            return db.Movies.Where(criteria).ToList();
        }

        public IList<Movie> Search(string title)
        {
            IQueryable<Movie> query = db.Movies;

            if (!string.IsNullOrEmpty(title))
            {
                query = query.Where(movie => movie.Title.Contains(title));
            }

            else
            {
                query = null;
            }

            return query.ToList();
        }

        public Movie Update(Movie movie)
        {
            db.Entry(movie).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
            return movie;
        }
    }
}
