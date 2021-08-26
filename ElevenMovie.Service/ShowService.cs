using ElevenMovie.Data;
using ElevenMovie.Models;
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
                    SeasonCount = model.SeasonCount,
                    EpisodeCount = model.EpisodeCount,
                    AverageRunTime = model.AverageRunTime,
                    AirDate = model.AirDate,
                    AssignedGenre = model.AssignedGenre,
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
                                    IsStarred = e.IsStarred,
                                    SeasonCount = e.SeasonCount,
                                    EpisodeCount = e.EpisodeCount,
                                    AverageRunTime = e.AverageRunTime,
                                    AirDate = e.AirDate,
                                    AssignedGenre = e.AssignedGenre,
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
                        IsStarred = enity.IsStarred,
                        SeasonCount = enity.SeasonCount,
                        EpisodeCount = enity.EpisodeCount,
                        AverageRunTime = enity.AverageRunTime,
                        AirDate = enity.AirDate,
                        AssignedGenre = enity.AssignedGenre,
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
                entity.IsStarred = model.IsStarred;
                entity.SeasonCount = model.SeasonCount;
                entity.EpisodeCount = model.EpisodeCount;
                entity.AverageRunTime = model.AverageRunTime;
                entity.AirDate = model.AirDate;
                entity.AssignedGenre = model.AssignedGenre;
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