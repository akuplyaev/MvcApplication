using System;
using System.Collections.Generic;
using System.IO;
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
        public HttpResponseMessage Get()
        {
            DirectoryInfo dirInfo = new DirectoryInfo(HttpContext.Current.Server.MapPath("~/App_Data/"));
            List<string> list = new List<string>();
            foreach (FileInfo file in dirInfo.GetFiles())
            {
                list.Add(file.Name);
            }
            HttpResponseMessage respone = Request.CreateResponse(HttpStatusCode.OK);
            string filesname = string.Join(", ", list);
            respone.Content = new StringContent(filesname);
            return respone;
        }

        [HttpPost]
        public async Task<HttpResponseMessage> Post()
        {            
            if (!Request.Content.IsMimeMultipartContent())
            {
                throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
            }

            string root = HttpContext.Current.Server.MapPath("~/App_Data");
            var provider = new MyStreamProvider(root);
            await Request.Content.ReadAsMultipartAsync(provider);
            List<string> files = new List<string>();
            foreach (var file in provider.FileData)
            {                
                string filename = file.Headers.ContentDisposition.FileName.Replace("\"", string.Empty);              
                files.Add(Path.GetFileName(file.LocalFileName));
            }
           
            return Request.CreateResponse(HttpStatusCode.OK, files);
        }

    }

}




//public HttpResponseMessage Post()
//{
//    var httpRequest = HttpContext.Current.Request;
//    if (httpRequest.Files.Count > 0)
//    {
//        //foreach (string file in httpRequest.Files)
//        //{
//        //    var postfile = httpRequest.Files[file];
//        //     var filePath = HttpContext.Current.Server.MapPath("~/App_Data/" + postFile.FileName);
//        //     postFile.SaveAs(filePath);
//        //}
//        for (int i = 0; i < httpRequest.Files.Count; i++)
//        {
//            var postFile = httpRequest.Files[i];
//            var filePath = HttpContext.Current.Server.MapPath("~/App_Data/" + postFile.FileName);
//            postFile.SaveAs(filePath);
//        }
//        return Request.CreateResponse(HttpStatusCode.Created);
//    }

//    return Request.CreateResponse(HttpStatusCode.BadRequest);
//}