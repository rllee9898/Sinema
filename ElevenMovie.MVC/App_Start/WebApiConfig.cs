using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace ElevenMovie.MVC.App_Start
{
    public class WebApiConfig
    {
        public static void Register()
        {
            GlobalConfiguration
                .Configure(
                    X =>
                    {
                        X
                             .Formatters
                             .JsonFormatter
                             .SupportedMediaTypes
                             .Add(new System.Net.Http.Headers.MediaTypeHeaderValue("text/html"));

                        X.MapHttpAttributeRoutes();
                    });
        }
    }
}