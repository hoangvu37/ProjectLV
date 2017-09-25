/*
### LacViet Control library
* Home          : http://www.lacviet.com.vn <http://www.lacviet.com.vn/> 
* Code          : GridViewController.cs
* Date          : 13/5/2015
* Version       : 1.0
* Midifier      : LDHUE
* Description   : class using for receive file from client
### Licensed by LacViet Computing Coporation
*/


using LV.Poco;
using LV.Common;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using Newtonsoft.Json;

namespace LV.Service.Common
{
    [AllowAnonymous]
    [RoutePrefix("api/DocFile")]
    public class DocFileController : LVApiController
    {
        public string ReadFileText(string filePath)
        {
            StringBuilder text = new StringBuilder();
            using (FileStream fs = File.Open(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            using (BufferedStream bs = new BufferedStream(fs))
            using (StreamReader sr = new StreamReader(bs))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    text.Append(line);
                }
            }
            return text.ToString();
        }

        [Route("Post")]
        [HttpPost]
        public async Task<IHttpActionResult> PostFormData()
        {
            // Check if the request contains multipart/form-data.
          
            var httpRequest = HttpContext.Current.Request;
            if (httpRequest.Files.Count > 0)
            {
                var docfiles = new List<string>();
                foreach (string file in httpRequest.Files)
                {
                    HttpPostedFile postedFile = httpRequest.Files[file];
                    string extension = Path.GetExtension(postedFile.FileName);//Lấy định dạng đuôi file dùng để kiểm tra

                    #region Save File to hard disk
                    var filePath = new DirectoryInfo(HttpContext.Current.Server.MapPath("~/")).Parent.FullName + "\\LVFHIR\\UploadFiles\\" + postedFile.FileName;
                    postedFile.SaveAs(filePath);//Lưu file dưới server 
                    #endregion
                    
                    try
                    {
                        var str = ReadFileText(filePath);
                        var obj = JsonConvert.DeserializeObject<object>(str);
                    }
                    catch
                    {
                        throw;
                    }
                    finally
                    {
                        if (Directory.Exists(Path.GetDirectoryName(filePath)))
                        {
                           // File.Delete(filePath);
                        }
                    }
                }
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [Route("Download")]
        [HttpGet]
        public HttpResponseMessage Download()
        {
            var path = new DirectoryInfo(HttpContext.Current.Server.MapPath("~/")).Parent.FullName + "\\LVFHIR\\UploadFiles\\New Text Document.json"; 
            HttpResponseMessage result = new HttpResponseMessage(HttpStatusCode.OK);
            var stream = new FileStream(path, FileMode.Open);
            result.Content = new StreamContent(stream);
            result.Content.Headers.ContentType =
                new MediaTypeHeaderValue("application/octet-stream");
            return result;
        }

        
    }

}
