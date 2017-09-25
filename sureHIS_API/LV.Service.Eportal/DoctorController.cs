using LV.Common;
using LV.Poco;
using LV.Poco.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace LV.Service.Eportal
{
    [RoutePrefix("api/Doctor")]
    [AllowAnonymous]
    public class DoctorController : LVApiController
    {
        [Route("LoadListDepartment")]
        [HttpGet]
        public IHttpActionResult LoadListDepartment(int id)
        {
            var obj = new object[1] { id };
            var result = this.Repository.ExecuteStoreScalar("RMS_spCntDoctorInSpecialist", obj);
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

        [Route("LoadListDoctorByDepartment")]
        [HttpGet]
        public IHttpActionResult LoadListDoctorByDepartment(string id, string HosID)
        {
            var obj = new object[2] { HosID, id };
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

        [Route("SearchDoctorInSpecialist")]
        [HttpGet]
        public IHttpActionResult SearchDoctorInSpecialist(long hosID, string search, long dep)
        {
            if (search == null) search = "";
            search = StripUnicodeCharactersFromString(search);
            var obj = new object[3] { search, dep, hosID };
            var result = this.Repository.ExecuteStoreScalar("RMS_SPSEARCHDOCTORINSPECIALIST", obj);
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

        public static String StripUnicodeCharactersFromString(string inputValue)
        {
            StringBuilder newStringBuilder = new StringBuilder();
            newStringBuilder.Append(inputValue.Normalize(NormalizationForm.FormKD).Where(x => x < 128).ToArray());
            return newStringBuilder.ToString();
        }

        [Route("getDoctorInfo")]
        [HttpGet]
        public IHttpActionResult getDoctorInfo(int id, int hosID = 0)
        {
            var obj = new object[2] { id, hosID };
            var result = this.Repository.ExecuteStoreScalar("HCP_spEmployeeDetail", obj);
            if (result != null)
            {
                var Employee = result.Tables[0].AsEnumerable()
                          .Select(r => r.Table.Columns.Cast<DataColumn>()
                                  .Select(c => new KeyValuePair<string, object>(c.ColumnName, r[c.Ordinal])
                                 ).ToDictionary(z => z.Key, z => z.Value)
                          ).ToList();

                var AdvancedSpecialist = result.Tables[1].AsEnumerable()
                          .Select(r => r.Table.Columns.Cast<DataColumn>()
                                  .Select(c => new KeyValuePair<string, object>(c.ColumnName, r[c.Ordinal])
                                 ).ToDictionary(z => z.Key, z => z.Value)
                          ).ToList();

                var EduLevel = result.Tables[2].AsEnumerable()
          .Select(r => r.Table.Columns.Cast<DataColumn>()
                  .Select(c => new KeyValuePair<string, object>(c.ColumnName, r[c.Ordinal])
                 ).ToDictionary(z => z.Key, z => z.Value)
          ).ToList();

                var JobPosition = result.Tables[3].AsEnumerable()
          .Select(r => r.Table.Columns.Cast<DataColumn>()
                  .Select(c => new KeyValuePair<string, object>(c.ColumnName, r[c.Ordinal])
                 ).ToDictionary(z => z.Key, z => z.Value)
          ).ToList();

                var JobHistory = result.Tables[4].AsEnumerable()
        .Select(r => r.Table.Columns.Cast<DataColumn>()
          .Select(c => new KeyValuePair<string, object>(c.ColumnName, r[c.Ordinal])
         ).ToDictionary(z => z.Key, z => z.Value)
        ).ToList();

                var Language = result.Tables[5].AsEnumerable()
          .Select(r => r.Table.Columns.Cast<DataColumn>()
                  .Select(c => new KeyValuePair<string, object>(c.ColumnName, r[c.Ordinal])
                 ).ToDictionary(z => z.Key, z => z.Value)
          ).ToList();
                return Ok(new
                {
                    Employee = Employee,
                    AdvancedSpecialist = AdvancedSpecialist,
                    EduLevel = EduLevel,
                    JobPosition = JobPosition,
                    JobHistory = JobHistory,
                    Language = Language
                });

            }
            return null;
        }

    }
}
