using LV.Common;
using LV.Poco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using LV.Poco.Model;
using System.IO;
using System.Net.Http;
using System.Net;
using System.Net.Http.Headers;
using System.Web;

namespace LV.Service.AD
{
    [RoutePrefix("api/Setup")]
    public class SetupController : LVApiController
    {
        [Route("Get")]
        [HttpGet]
        public IHttpActionResult Get()
        {
            try
            {
                var Setup = this.Repository.GetQuery<AD_tblSetup>().FirstOrDefault();
                if (Setup == null) Setup = new AD_tblSetup() { ID = Guid.NewGuid() };

                return Ok(Setup);
            }
            catch (Exception exp)
            {
                return BadRequest(exp.ToString());
            }
        }


        [Route("Save")]
        [HttpPost]
        public IHttpActionResult Save(AD_tblSetup Setup)
        {
            try
            {
                this.Repository.AddOrUpdate(Setup);
                this.Repository.UnitOfWork.SaveChanges();
                return Ok();
            }
            catch (Exception exp)
            {
                return BadRequest(exp.ToString());
            }
        }


        [AllowAnonymous]
        [Route("GetCustomFormat")]
        [HttpGet]
        public IHttpActionResult GetCustomFormat()
        {
            try
            {
                var CustomFormat = this.Repository.GetQuery<AD_tblSetup>().FirstOrDefault();
                if (CustomFormat == null)
                {
                    CustomFormat = new AD_tblSetup
                    {
                        ID = Guid.NewGuid(),
                        App_BaseCurrID = "VND",
                        App_ForgAmtDec = 0,
                        App_RateExchDec = 0,
                        App_BaseAmtDec = 0,
                        App_PercentDec = 0,
                        App_QuantityDec = 0,
                        App_UnitCostDec = 0,
                        App_RF_Color = "#FF8A8A",
                        App_OF_Color = "#6495ED",
                        App_AppFontSize = 9,
                        App_RptFontSize = 9,
                        App_TitleFontSize = 16
                    };
                }
                return Ok(CustomFormat);
            }
            catch (Exception exp)
            {
                return BadRequest(exp.ToString());
            }
        }

        [Route("GetLogo")]
        [HttpGet]
        [AllowAnonymous]
        public HttpResponseMessage GetLogo()
        {
            var ad = this.Repository.GetQuery<AD_tblSetup>().FirstOrDefault();

            using (MemoryStream ms = new MemoryStream())
            {
                HttpResponseMessage result = new HttpResponseMessage(HttpStatusCode.OK);
                result.Content = new ByteArrayContent(ad != null ? (ad.App_CompLogo==null ?new byte[0] : ad.App_CompLogo) : new byte[0]);
                result.Content.Headers.ContentType = new MediaTypeHeaderValue("image/png");
                return result;
            }
        }
        [Route("UploadLogo")]
        [HttpPost]
        public IHttpActionResult UploadLogo()
        {
            var request = HttpContext.Current.Request;
            using (var streamReader = new MemoryStream())
            {
                request.Files[0].InputStream.CopyTo(streamReader);
                var ad = this.Repository.GetQuery<AD_tblSetup>().FirstOrDefault();
                if(ad!=null)
                {
                    if (streamReader.Length > 0)
                        ad.App_CompLogo = streamReader.ToArray();
                    else
                        ad.App_CompLogo = null;
                    this.Repository.Update(ad);
                    this.UnitOfWork.SaveChanges();
                }
            }
            return Ok();
        }
    }
}
