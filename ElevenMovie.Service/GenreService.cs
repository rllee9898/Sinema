using ElevenMovie.Data;
using ElevenMovie.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevenMovie.Service
{
    public class  GenreService
    {
        private readonly Guid _userId;

        public GenreService(Guid userId)
        {
            _userId = userId;
        }// This will create a instance of Note
        public bool CreateGenre(GenreCreate model)
        {
            var entity =
                new Data.Genre()
                {
                    OwnerId = _userId,
                    GenreType = model.GenreType 
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Genres.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        //Get

        //This method will allow us to see all the notes that belong to a specific user.
        public IEnumerable<GenreListItem> GetGenres()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Genres
                        .Where(e => e.OwnerId == _userId)
                        .Select(
                            e =>
                                new GenreListItem
                                {
                                    GenreId = e.GenreId,
                                    GenreType = e.GenreType
                                }
                        );
                return query.ToArray();
            }
        }
        public GenreDetails GetGenreById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var enity =
                    ctx
                        .Genres
                        .Single(e => e.GenreId == id && e.OwnerId == _userId);
                return
                    new GenreDetails
                    {
                        GenreId = enity.GenreId,
                        GenreType = enity.GenreType
                    };
            }
        }

        //Put or Update

        //Update Method
        public bool UpdateGenre(GenreEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Genres
                        .Single(e => e.GenreId == model.GenreId && e.OwnerId == _userId);

                entity.GenreId = model.GenreId;
                entity.GenreType = model.GenreType;

                return ctx.SaveChanges() == 1;
            }
        }

                //Delete Method

                //Delete
                public bool DeleteMovie(int movieId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Movies
                    .Single(e => e.MovieId == movieId && e.OwnerId == _userId);

                ctx.Movies.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}