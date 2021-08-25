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
    [RoutePrefix("api/Genre")]
    public class GenreController : ApiController
    {
        private bool SetStarState(int genreId, bool newState)
        {
            // Create the Genre
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new GenreService(userId);

            //Get the Genre
            var detail = service.GetGenreById(genreId);

            // Create the GenreEdit model instance with the new star state
            var updatedGenre =
                new GenreEdit
                {
                    GenreId = detail.GenreId,
                    GenreType = detail.GenreType,
                    IsStarred = newState
                };
            // Return a value indicating whether the update succeeded
            return service.UpdateGenre(updatedGenre);

        }

        [Route("{id}/Star")]
        [HttpPut]
        public bool ToggleStarOn(int id) => SetStarState(id, true);

        [Route("{id}/Star")]
        [HttpDelete]
        public bool ToggleStarOff(int id) => SetStarState(id, false);
    }
}