using LV.Common;
using LV.Poco;
using LV.Poco.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace LV.Service.Eportal
{
    [RoutePrefix("api/Home")]
    [AllowAnonymous]
    public class HomeController : LVApiController
    {       
        [Route("getHospitalInfo")]
        [HttpGet]
        public IHttpActionResult getHospitalInfo(string hosId, string perID)
        {            
            try
            {
                var hospitalInfo = (from hospital in this.Repository.GetQuery<HCProvider>()
                                    where hospital.HosID == 11163 && hospital.isBulitIn == true
                                    select hospital).FirstOrDefault();
                if (hospitalInfo == null)
                {
                    return null;
                }               
                LV.Service.Eportal.RegisterMailController getWork = new RegisterMailController();
                List<WorkDayTime> dateTimeToWork = new List<WorkDayTime>();                
                dateTimeToWork = getWork.GetScheduleOfHos(long.Parse(hosId));
                return Ok(new { hospitalInfo = hospitalInfo, dateTimeToWork = dateTimeToWork });
            }
            catch (Exception exp)
            {
                return BadRequest(exp.ToString());
            }
        }

        [Route("getDoctorInfo")]
        [HttpGet]
        public IHttpActionResult getDoctorInfo(string hosId)
        {
            try
            {
                //0:lay tat ca chuyen khoa
                var obj = new object[2] { hosId, 0 };
                var result = this.Repository.ExecuteStoreScalar("RMS_spDoctorInSpecialist", obj);
                if (result != null && result.Tables.Count > 0)
                {
                    var data = result.Tables[0].AsEnumerable()
                              .Select(r => r.Table.Columns.Cast<DataColumn>()
                                      .Select(c => new KeyValuePair<string, object>(c.ColumnName, r[c.Ordinal])
                                     ).ToDictionary(z => z.Key, z => z.Value)
                              ).ToList();
                    return Ok(data);
                }
                return null;
            }
            catch (Exception exp)
            {
                return BadRequest(exp.ToString());
            }
        }
    }
}