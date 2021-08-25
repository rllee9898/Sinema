using ElevenMovie.Models;
using ElevenMovie.Service;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ElevenMovie.MVC.Controllers
{
    //This annotation makes it so that the views are accessible only to logged in users
    [Authorize]
    public class GenreController : Controller
    {
        // GET: Genre
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new GenreService(userId);
            var model = service.GetGenres();

            return View(model);
        }


        // Add method here VVVV
        //GET
        public ActionResult Create()
        {
            return View();
        }

        // Add method here VVVV
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(GenreCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateGenreService();

            if (service.CreateGenre(model))
            {
                TempData["SaveResult"] = "Your Genre was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Genre could not be created.");

            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = CreateGenreService();
            var model = svc.GetGenreById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateGenreService();
            var detail = service.GetGenreById(id);
            var model =
                new GenreEdit
                {
                    GenreType = detail.GenreType,
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, GenreEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.GenreId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateGenreService();

            if (service.UpdateGenre(model))
            {
                TempData["SaveResult"] = "Your Genre was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your Genre could not be updated.");
            return View(model);
        }


        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateGenreService();
            var model = svc.GetGenreById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateGenreService();
            service.DeleteGenre(id);
            TempData["SaveResult"] = "Your Genre was deleted";

            return RedirectToAction("index");
        }

        private GenreService CreateGenreService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new GenreService(userId);
            return service;
        }
    }
}