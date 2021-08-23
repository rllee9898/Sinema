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
            return View();
        }
    }
}