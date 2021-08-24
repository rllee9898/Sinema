﻿using ElevenMovie.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevenMovie.Service
{
    public class ReviewService
    {
        private readonly Guid _userId;

        public ReviewService(Guid userId)
        {
            _userId = userId;
        }

        // This will create a instance of Note
        public bool CreateReview(ReviewCreate model)
        {
            var entity =
                new Data.Review()
                {
                    OwnerId = _userId,
                    ReviewId = model.ReviewId,
                    Reviewer = model.Reviewer,
                    Content = model.Content,
                    CreatedUtc = DateTimeOffset.Now,
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Reviews.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        //Get

        //This method will allow us to see all the notes that belong to a specific user.
        public IEnumerable<ReviewListItem> GetReviews()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Reviews
                        .Where(e => e.OwnerId == _userId)
                        .Select(
                            e =>
                                new ReviewListItem
                                {
                                    ReviewId = e.ReviewId,
                                    Reviewer = e.Reviewer,
                                    Content = e.Content,
                                    CreatedUtc = e.CreatedUtc
                                }
                        );
                return query.ToArray();
            }
        }
        public ReviewDetail GetReviewById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var enity =
                    ctx
                        .Reviews
                        .Single(e => e.ReviewId == id && e.OwnerId == _userId);
                return
                    new ReviewDetail
                    {
                        ReviewId = enity.ReviewId,
                        Reviewer = enity.Reviewer,
                        Content = enity.Content,
                        CreatedUtc = enity.CreatedUtc,
                    };
            }
        }

        //Put or Update

        //Update Method
        public bool UpdateReview(ReviewEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Reviews
                        .Single(e => e.ReviewId == model.ReviewId && e.OwnerId == _userId);

                entity.Content = model.Content;
                entity.ModifiedUtc = DateTimeOffset.UtcNow;


                return ctx.SaveChanges() == 1;

            }
        }

        //Delete Method

        //Delete
        public bool DeleteReview(int reviewId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Reviews
                    .Single(e => e.ReviewId == reviewId && e.OwnerId == _userId);

                ctx.Reviews.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}