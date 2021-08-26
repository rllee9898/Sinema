using ElevenMovie.Models;
using ElevenMovie.Service;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ElevenMovie.MVC.Controllers.WebApi
{
    [Authorize]
    [RoutePrefix("api/Review")]
    public class ReviewController : ApiController
    {
        private bool SetStarState(int reviewId, bool newState)
        {
            // Create the service
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ReviewService(userId);

            //Get the Show
            var detail = service.GetReviewById(reviewId);

            // Create the ShowEdit model instance with the new star state
            var updatedReview =
                new ReviewEdit
                {
                    ReviewId = detail.ReviewId,
                    Reviewer = detail.Reviewer,
                    Title = detail.Title,
                    Rating = detail.Rating,
                    Content = detail.Content,
                    IsStarred = newState
                };
            // Return a value indicating whether the update succeeded
            return service.UpdateReview(updatedReview);
        }

        [Route("{id}/Star")]
        [HttpPut]
        public bool ToggleStarOn(int id) => SetStarState(id, true);

        [Route("{id}/Star")]
        [HttpDelete]
        public bool ToggleStarOff(int id) => SetStarState(id, false);
    }
}