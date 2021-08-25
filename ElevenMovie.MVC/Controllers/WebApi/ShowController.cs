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
    [RoutePrefix("api/Show")]
    public class ShowController : ApiController
    {
        private bool SetStarState(int showId, bool newState)
        {
            // Create the service
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ShowService(userId);

            //Get the Show
            var detail = service.GetShowById(showId);

            // Create the ShowEdit model instance with the new star state
            var updatedMovie =
                new ShowEdit
                {
                    ShowId = detail.ShowId,
                    Title = detail.Title,
                    Description = detail.Description,
                    AssignedGenre = detail.AssignedGenre,
                    IsStarred = newState
                };
            // Return a value indicating whether the update succeeded
            return service.UpdateShow(updatedMovie);

        }

        [Route("{id}/Star")]
        [HttpPut]
        public bool ToggleStarOn(int id) => SetStarState(id, true);

        [Route("{id}/Star")]
        [HttpDelete]
        public bool ToggleStarOff(int id) => SetStarState(id, false);
    }
}