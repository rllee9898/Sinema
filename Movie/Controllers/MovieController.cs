using Movie.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Movie.Controllers
{
    //This annotation makes it so that the views are accessible only to logged in users
    [Authorize]
    public class MovieController : Controller
    {
        // GET: Movie
        public ActionResult Index()
        {
            var model = new MovieListItem[0];
            return View(model);
        }


        //Add method here VVVV
        //GET
        public ActionResult Create()
        {
            return View();
        }

        //Add method here VVVV
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MovieCreate model)
        {
            if (ModelState.IsValid)
            {

            }
            return View(model);
        }

    }
}