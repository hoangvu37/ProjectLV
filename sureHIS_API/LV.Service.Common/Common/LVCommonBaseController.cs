using LV.Poco;
using LV.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace LV.Service.Common
{
    [RoutePrefix("api/LVCommonBase")]
    public class LVCommonBaseController : LVApiController
    {
        public LVCommonBaseController()
        {

        }

        /// <summary>
        /// Lấy Type ứng với giá trị tên entity truyền vào
        /// </summary>
        /// <param name="EntityName">Tên emtity</param>
        /// <returns>null nếu ko tìm thấy entity phù hợp</returns>
        public static Type GetType(string EntityName)
        {
            var type = Type.GetType(EntityName);
            if (type != null) return type;
            foreach (var a in AppDomain.CurrentDomain.GetAssemblies())//Duyệt qua từng assembly có trong reference của project
            {
                type = a.GetType(EntityName);
                if (type != null)
                    return type;
            }
            return null;
        }

        /// <summary>
        /// Lấy thông tin về tên cột và loại dữ liệu của cột tương ứng
        /// </summary>
        /// <param name="EntityName">Tên thực thể</param>
        /// <returns>Trả về Exception nếu ko tìm thấy</returns>
        public IDictionary<string, List<string>> GetNameAndTypeInEntity(string EntityName)
        {
            IDictionary<string, List<string>> dictionary = new Dictionary<string, List<string>>();
            Type type = GetType("LV.Poco." + EntityName);
            if (type == null)
                throw new Exception("Not found EntityName " + type + " in assembly LV.Poco.dll.");
            //var item = Activator.CreateInstance(type);//Create instance of entity
            var listType = new List<string>();
            var listName = new List<string>();

            foreach (var prop in type.GetProperties())
            {
                listType.Add(prop.PropertyType.Name);
                listName.Add(prop.Name);
            }
            dictionary.Add("listType", listType);
            dictionary.Add("listName", listName);
            return dictionary;
        }

        /// <summary>
        /// Lấy thông tin về tên cột và loại dữ liệu của cột tương ứng
        /// </summary>
        /// <param name="EntityName">Tên thực thể</param>
        /// <returns></returns>
        //[AllowAnonymous]
        [Route("GetInfoTable")]
        public IHttpActionResult GetInfoTable(string EntityName)
        {
            try
            {
                var dictionary = GetNameAndTypeInEntity(EntityName);
                return Ok(dictionary);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        //[AllowAnonymous]
        [Route("GetEntity")]
        public IHttpActionResult GetEntity(string EntityName)
        {

            Type type = GetType("LV.Poco." + EntityName);
            if (type == null)
                throw new Exception("Not found EntityName " + type + " in assembly LV.Poco.dll.");
            var item = Activator.CreateInstance(type);//Create instance of entity
            return Ok(item);
        }
        

        /// <summary>
        /// Có thể bỏ đi nếu sau này viết mỗi control riêng. Khi đó cứ mỗi lần init 1 control thì thêm đoạn script như
        /// &lt;script type='text/javascript'%gt;ObjectControl = ObjectControl + '{"name":"CreatedBy", "type":"String","controltype":"text"},'; &lt;/script&gt;
        /// </summary>
        /// <param name="GrvName"></param>
        /// <returns></returns>
        //[AllowAnonymous]
        [Route("ObjectControl")]
        [HttpGet]
        public IHttpActionResult ObjectControl(string GrvName)
        {
            //Chưa hỗ trợ Control Type: date,datetime,numberic trong database
            //var items=this.Repository.GetQuery<SYS_GridViewSetup>().Where(p => p.GridViewName == GrvName)
            //    .Select(s => new { name = s.FieldName, type = s.DataType, controltype = s.ControlType }).ToList();
            var items = new List<ObjTest>();
            items.Add(new ObjTest() { Name = "NationID", Type = "String", Controltype = "TextBox" });
            items.Add(new ObjTest() { Name = "NationName", Type = "String", Controltype = "TextBox" });
            items.Add(new ObjTest() { Name = "NationName2", Type = "String", Controltype = "TextBox" });
            return Ok(items);
        }
        private class ObjTest
        {
            public string Type { get; set; }
            public string Name { get; set; }
            public string Controltype { get; set; }
        }

        //[AllowAnonymous]
        //[Route("GridInfo")]
        //[HttpGet]
        //public IHttpActionResult GridInfo()
        //{
        //    string gridViewName = "grvtblNationsList"; string formName = ""; string entityName = "CF_tblNationsList"; 
        //    LVGridView lv = new LVGridView();
        //    var g = lv.GetLVGridView(gridViewName, formName, entityName, "api/CF/NationList/GetAll", false);
        //    return Ok(g);
        //}
    }
}
