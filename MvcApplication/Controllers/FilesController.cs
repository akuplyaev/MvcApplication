using System.Net;
using System.Net.Http;
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
        public HttpResponseMessage Post()
        {
            var httpRequest = HttpContext.Current.Request;
            if (httpRequest.Files.Count > 0)
            {
                for (int i = 0; i < httpRequest.Files.Count; i++)
                {
                    var postedFile = httpRequest.Files[i];
                    var filePath = HttpContext.Current.Server.MapPath("~/App_Data/" + postedFile.FileName);
                    postedFile.SaveAs(filePath);
                }
                return Request.CreateResponse(HttpStatusCode.Created);
            }

            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }
    }
}
