using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ElevenMovie.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}

    //   {
    //    //Hosted web API REST Service base url
    //    readonly string Baseurl = "https://api.themoviedb.org";
    //public async Task<ActionResult> Index()
    //{
    //    using (var client = new HttpClient())
    //    {
    //        //Passing service base url
    //        client.BaseAddress = new Uri(Baseurl);
    //        client.DefaultRequestHeaders.Clear();
    //        //Define request data format
    //        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    //        //Sending request to find web api REST service resource GetAllEmployees using HttpClient
    //        HttpResponseMessage Res = await client.GetAsync("/3/search/movie?api_key=6c5cd53089937b6c0e8966d0aacfb8ad&language=en-US&query=star%20wars%20revenge%20of%20sith&page=1&include_adult=true");
    //        //Checking the response is successful or not which is sent using HttpClient
    //        if (Res.IsSuccessStatusCode)
    //        {
    //            //Storing the response details recieved from web api
    //            var MovieSearchResponse = Res.Content.ReadAsStringAsync().Result;
    //            //Deserializing the response recieved from web api and storing into the Employee list
    //            MovieSearchResults MovieInfo = JsonConvert.DeserializeObject<MovieSearchResults>(MovieSearchResponse);

    //            string title = MovieInfo.Results[1].OriginalTitle;
    //        }
    //        //returning the employee list to view
    //        return View();