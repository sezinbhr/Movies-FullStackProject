using Microsoft.EntityFrameworkCore;
using Movies.DataAccess.Data;
using Movies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Movies.DataAccess.Repositories
{
    public class EFGenreRepository : IGenreRepository
    {
        private MoviesDbContext db;

        public EFGenreRepository(MoviesDbContext moviesDbContext)
        {
            db = moviesDbContext;
        }
        public Genre Add(Genre entity)
        {
            db.Genres.Add(entity);
            db.SaveChanges();
            return entity;
        }

        public void Delete(int id)
        {
            db.Genres.Remove(GetById(id));
            db.SaveChanges();
        }

        public IList<Genre> GetAll()
        {
            return db.Genres.ToList();
        }

        public Genre GetById(int id)
        {
            return db.Genres.AsNoTracking().FirstOrDefault(x => x.Id == id);
        }

        public Genre GetMovieListByGenre(int genreId)
        {
            return db.Genres.Include(genres => genres.Movies).Where(genre => genre.Id == genreId).FirstOrDefault();
        }

        public IList<Genre> GetWithCriteria(Func<Genre, bool> criteria)
        {
            return db.Genres.Where(criteria).ToList();
        }

        public Genre Update(Genre genre)
        {
            db.Entry(genre).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
            return genre;
        }
    }
}
