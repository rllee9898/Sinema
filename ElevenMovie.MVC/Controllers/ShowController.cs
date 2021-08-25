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
    public class ShowController : Controller
    {
        // GET: Show
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ShowService(userId);
            var model = service.GetShows();

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
        public ActionResult Create(ShowCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateShowService();

            if (service.CreateShow(model))
            {
                TempData["SaveResult"] = "Your show was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Show could not be created.");

            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = CreateShowService();
            var model = svc.GetShowById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateShowService();
            var detail = service.GetShowById(id);
            var model =
                new ShowEdit
                {
                    ShowId = detail.ShowId,
                    Title = detail.Title,
                    GenreType = detail.GenreType,
                    Description = detail.Description,
                    Genre = detail.Genre,

                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ShowEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.ShowId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateShowService();

            if (service.UpdateShow(model))
            {
                TempData["SaveResult"] = "Your show was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your show could not be updated.");
            return View(model);
        }


        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateShowService();
            var model = svc.GetShowById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateShowService();
            service.DeleteShow(id);
            TempData["SaveResult"] = "Your show was deleted";

            return RedirectToAction("index");
        }

        private ShowService CreateShowService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ShowService(userId);
            return service;
        }
    }
}