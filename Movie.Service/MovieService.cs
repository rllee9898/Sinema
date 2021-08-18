using ElevenMovie.Data;
using ElevenMovie.Models;
using Movie.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevenMovie.Service
{
    public class MovieService
    {
        private readonly Guid _userId;

        public MovieService(Guid userId)
        {
            _userId = userId;
        }

        // This will create a instance of Note
        public bool CreateNote(MovieCreate model)
        {
            var entity =
                new Movie()
                {
                    OwnerId = _userId,
                    Title = model.Title,
                    Description = model.Description,
                    Genre = model.Genre,
                    IsStarred = model.IsStarred,
                    CreatedUtc = DateTimeOffset.Now
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Movies.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        //Get

        //This method will allow us to see all the notes that belong to a specific user.
        public IEnumerable<MovieListItem> GetMovies()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Movies
                        .Where(e => e.OwnerId == _userId)
                        .Select(
                            e =>
                                new MovieListItem
                                {
                                    MovieId = e.MovieId,
                                    Title = e.Title,
                                    Genre = e.Genre,
                                    IsFamilyFriendly = e.IsFamilyFriendly,
                                    CreatedUtc = e.CreatedUtc
                                }
                        );
                return query.ToArray();
            }
        }
        public MovieDetail GetMovieById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var enity =
                    ctx
                        .Movies
                        .Single(e => e.MovieId == id && e.OwnerId == _userId);
                return
                    new MovieDetail
                    {
                        MovieId = enity.MovieId,
                        Title = enity.Title,
                        Genre = enity.Genre,
                        CreatedUtc = enity.CreatedUtc,
                        ModifiedUtc = enity.ModifiedUtc
                    };
            }
        }




    }
}
