using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace MvcApplication.Controllers
{
    public class FilesController : ApiController
    {
        [HttpGet]
        public string Get()
        {
            return "ApiController";
        }

        [HttpPost]
        public  void Upload()
        {
            if (!Request.Content.IsMimeMultipartContent())
                throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);

            string root = HttpContext.Current.Server.MapPath("~/App_Data");
            var provider = new MultipartFormDataStreamProvider(root);

             Request.Content.ReadAsMultipartAsync(provider);
        }
    }
}
