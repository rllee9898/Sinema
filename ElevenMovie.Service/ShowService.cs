using ElevenMovie.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevenMovie.Service
{
    public class ShowService
    {
        private readonly Guid _userId;

        public ShowService(Guid userId)
        {
            _userId = userId;
        }

        // This will create a instance of Note
        public bool CreateShow(ShowCreate model)
        {
            var entity =
                new Data.Show()
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
                ctx.Shows.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        //Get

        //This method will allow us to see all the notes that belong to a specific user.
        public IEnumerable<ShowListItem> GetShows()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Shows
                        .Where(e => e.OwnerId == _userId)
                        .Select(
                            e =>
                                new ShowListItem
                                {
                                    ShowId = e.ShowId,
                                    Title = e.Title,
                                    Description = e.Description,
                                    Genre = e.Genre,
                                    IsStarred = e.IsStarred,
                                    CreatedUtc = e.CreatedUtc
                                }
                        );
                return query.ToArray();
            }
        }
        public ShowDetail GetShowById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var enity =
                    ctx
                        .Shows
                        .Single(e => e.ShowId == id && e.OwnerId == _userId);
                return
                    new ShowDetail
                    {
                        ShowId = enity.ShowId,
                        Title = enity.Title,
                        Description = enity.Description,
                        Genre = enity.Genre,
                        CreatedUtc = enity.CreatedUtc,
                        ModifiedUtc = enity.ModifiedUtc
                    };
            }
        }

        //Put or Update

        //Update Method
        public bool UpdateShow(ShowEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Shows
                        .Single(e => e.ShowId == model.ShowId && e.OwnerId == _userId);

                entity.Title = model.Title;
                entity.Description = model.Description;
                entity.Genre = model.Genre;
                entity.ModifiedUtc = DateTimeOffset.UtcNow;


                return ctx.SaveChanges() == 1;

            }
        }

        //Delete Method

        //Delete
        public bool DeleteShow(int showId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Shows
                    .Single(e => e.ShowId == showId && e.OwnerId == _userId);

                ctx.Shows.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}