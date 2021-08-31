//using System;
//using System.Web.Mvc;
//using System.Net;
//using System.IO;
//using System.Text;
//using Newtonsoft.Json;
//using static ElevenMovie.Models.MovieSearchResults;
//using ElevenMovie.Models;

//namespace ElevenMovie.MVC.Controllers
//{
//    public class TmdbApiController : Controller
//    {
//        // GET
//        public ActionResult Index(string title, int? page)
//        {
//            if (page != null)
//                CallAPI(title, Convert.ToInt32(page));

//            Models.MovieSearchResults.Result Result = new Models.MovieSearchResults.Result();
//            Result.SearchText = title;
//            return View(Result);
//        }

//        [HttpPost]
//        public ActionResult Index(Models.MovieSearchResults MovieSearchResults, string searchText)
//        {
//            if (ModelState.IsValid)
//            {
//                CallAPI(searchText, 0);
//            }
//            return View(MovieSearchResults);
//        }

//        public void CallAPI(string searchText, int page)
//        {
//            int pageNo = Convert.ToInt32(page) == 0 ? 1 : Convert.ToInt32(page);

//            /*Calling API https://developers.themoviedb.org/3/search/search-people */
//            string apiKey = "3356865d41894a2fa9bfa84b2b5f59bb";
//            HttpWebRequest apiRequest = WebRequest.Create("https://api.themoviedb.org/3/search/Movie?api_key=" + apiKey + "&language=en-US&query=" + searchText + "&page=" + pageNo + "&include_adult=false") as HttpWebRequest;

//            string apiResponse = "";
//            ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3
//                            | SecurityProtocolType.Tls
//                            | SecurityProtocolType.Tls11
//                            | SecurityProtocolType.Tls12;
//            using (HttpWebResponse response = apiRequest.GetResponse() as HttpWebResponse)
//            {
//                StreamReader reader = new StreamReader(response.GetResponseStream());
//                apiResponse = reader.ReadToEnd();
//            }
//            /*End*/

//            /*http://json2csharp.com*/
//            ResponseSearchMovie rootObject = JsonConvert.DeserializeObject<ResponseSearchMovie>(apiResponse);

//            StringBuilder sb = new StringBuilder();
//            sb.Append("<div class=\"resultDiv\"><p>Names</p>");
//            foreach (Result result in rootObject.results)
//            {
//                string image = result.backdrop_path == null ? Url.Content("~/Content/Image/no-image.png") : "https://image.tmdb.org/t/p/w500/" + result.backdrop_path;
//                string link = Url.Action("GetPerson", "TmdbApi", new { Id = result.Id });

//                sb.Append("<div class=\"result\" resourceId=\"" + result.Id + "\">" + "<a href=\"" + link + "\"><img src=\"" + image + "\" />" + "<p>" + result.Title + "</a></p></div>");
//            }

//            ViewBag.Result = sb.ToString();

//            int pageSize = 20;
//            PagingInfo pagingInfo = new PagingInfo();
//            pagingInfo.CurrentPage = pageNo;
//            pagingInfo.TotalItems = rootObject.total_results;
//            pagingInfo.ItemsPerPage = pageSize;
//            ViewBag.Paging = pagingInfo;
//        }

//        public ActionResult GetMovieAPI(int id)
//        {
//            /*Calling API https://developers.themoviedb.org/3/people */
//            string apiKey = "3356865d41894a2fa9bfa84b2b5f59bb";
//            HttpWebRequest apiRequest = WebRequest.Create("https://api.themoviedb.org/3/person/" + id + "?api_key=" + apiKey + "&language=en-US") as HttpWebRequest;

//            string apiResponse = "";
//            using (HttpWebResponse response = apiRequest.GetResponse() as HttpWebResponse)
//            {
//                StreamReader reader = new StreamReader(response.GetResponseStream());
//                apiResponse = reader.ReadToEnd();
//            }
//            /*End*/

//            /*http://json2csharp.com*/
//            Result rootObject = JsonConvert.DeserializeObject<Result>(apiResponse);
//            Result Result = new Result();
//            Result.original_title = rootObject.original_title;
//            Result.popularity = rootObject.popularity;
//            Result.poster_path = rootObject.poster_path;
//            Result.release_date = rootObject.release_date;
//            Result.Title = rootObject.Title;
//            Result.video = rootObject.video;
//            Result.vote_average = rootObject.vote_average;
//            Result.vote_count = rootObject.vote_count;
//            Result.backdrop_path = rootObject.backdrop_path == null ? Url.Content("~/Content/Image/no-image.png") : "https://image.tmdb.org/t/p/w500/" + rootObject.backdrop_path;
           
//            return View(Result);
//        }
//    }
//}