using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using LV.Common;
using Newtonsoft.Json;

namespace LV.Service.Common.Common
{
    [RoutePrefix("api/Common/List")]
    public class ListController : LVApiController
    {
        public struct DynamicEntity
        {
            public string FromName { get; set; }
            /// <summary>
            /// EntityName: Tên Entity
            /// </summary>
            public string EntityName { get; set; }
            /// <summary>
            /// EntityValue: danh sách chứa các đối tượng EntityName.
            /// VD: EntityName= 'CF_tblNationList
            /// --> EntityValue = [{NationID: 'VN', NationName: 'Vietnam',...},{NationID: 'CN', NationName: 'China',...},...]
            /// </summary>
            public List<object> EntityValue { get; set; }
            public List<object> EntityDelete { get; set; }

        }


        [Route("GetKey")]
        [HttpGet]
        public IHttpActionResult GetKey(string entity)
        {
            Type mtype = PocoHelper.GetTypeFromString(entity);
            var old = Activator.CreateInstance(mtype);
            var _pro = mtype.GetProperty("Key");
            return Ok(_pro.GetValue(old, null));

        }

        [Route("Delete")]
        [HttpPost]
        public IHttpActionResult Delete([FromBody]DynamicEntity data)
        {
            List<object> lObj = new List<object>();

            Type mtype = PocoHelper.GetTypeFromString(data.EntityName);
            foreach (var item in data.EntityValue)
            {
                DeleteData(mtype, item, data.FromName);
            }

            try
            {
                this.UnitOfWork.SaveChanges();
            }
            catch (Exception exp)
            {
                return Ok(this.ProcessException(exp));
            }
            this.UnitOfWork.SaveChanges();
            return Ok();
        }

        [Route("Save")]
        [HttpPost]
        public IHttpActionResult Save([FromBody]DynamicEntity data)
        {
            List<object> lObj = new List<object>();

            Type mtype = PocoHelper.GetTypeFromString(data.EntityName);
            ErrorModel err = null;
            foreach (var item in data.EntityValue)
            {
                ErrorModel error = UpdateData(mtype, item, data.FromName);
                if (error != null)
                {
                    if (err == null)
                    {
                        err = new ErrorModel(System.Net.HttpStatusCode.BadRequest);
                        err.Message = getCaption("Common", "DataIsInvalidate", "Data Is Invalidate");
                    }
                    err.Child.Add(error);
                }

            }

            if (data.EntityDelete != null)
            {
                foreach (var item in data.EntityDelete)
                {
                    DeleteData(mtype, item, data.FromName);
                }
            }
            if (err != null)
                return Ok(err);
            try
            {
                this.UnitOfWork.SaveChanges();
            }
            catch (Exception exp)
            {
                return Ok(this.ProcessException(exp));
            }

            return Ok();

        }

        /// <summary>
        /// Them/Sua thong tin theo doi tuong
        /// </summary>
        /// <param name="type">kieu doi tuong</param>
        /// <param name="data">du lieu can them/sua</param>
        public ErrorModel UpdateData(Type type, object data, string formName)
        {
            var updObj = DynamicAssembly.InvokeGenericMethod(type, this, "JsonToObject", data);
            ErrorModel err = this.ValidateObject(updObj, formName);
            if (err != null) return err;
            DynamicAssembly.InvokeGenericMethod(type, this, "UpdateDataLogic", updObj);
            return null;

        }


        public string UpdateDataLogic<TEntity>(TEntity entity) where TEntity : class
        {
            string rs = "";
            try
            {
                var proIsAdd = typeof(TEntity).GetProperty("_IsAdd");
                if (proIsAdd != null)
                {
                    bool _IsAdd = (bool)proIsAdd.GetValue(entity, null);
                    if (_IsAdd)
                    {
                        this.Repository.Add<TEntity>(entity);
                    }
                    else
                    {
                        var _proOld = typeof(TEntity).GetProperty("_KeyOld");
                        var _prokey = typeof(TEntity).GetProperty("Key");
                        if (_proOld != null)
                        {
                            var valOld = _proOld.GetValue(entity, null);
                            KeyValuePair<string, string> key = (KeyValuePair<string, string>)_prokey.GetValue(entity, null);
                            if (key.Value.Equals(valOld))
                            {
                                this.Repository.Update<TEntity>(entity);
                            }
                            else
                            {
                                var old = Activator.CreateInstance<TEntity>();
                                var _pro = typeof(TEntity).GetProperty(key.Key);
                                _pro.SetValue(old, valOld, null);

                                this.Repository.Delete<TEntity>(old);
                                this.Repository.Add(entity);
                            }
                        }
                        else
                        {

                            this.Repository.Update<TEntity>(entity);
                        }
                    }
                }
            }
            catch (Exception ex)
            { rs = ex.Message; }
            return rs;
        }


        public ErrorModel DeleteData(Type type, object data, string formName)
        {
            var updObj = DynamicAssembly.InvokeGenericMethod(type, this, "JsonToObject", data);
            ErrorModel err = this.ValidateObject(updObj, formName);
            if (err != null) return err;
            DynamicAssembly.InvokeGenericMethod(type, this, "DeleteDataLogic", updObj);
            return null;

        }


        public string DeleteDataLogic<TEntity>(TEntity entity) where TEntity : class
        {
            string rs = "";
            try
            {
                var _prokey = typeof(TEntity).GetProperty("Key");
                if (_prokey != null)
                {
                    
                    KeyValuePair<string, string> key = (KeyValuePair<string, string>)_prokey.GetValue(entity, null);
                    if (!string.IsNullOrEmpty(key.Value))
                    {
                        var pre = key.Key + "==\""+ key.Value+ "\"";
                        var item = this.Repository.GetQuery<TEntity>().Where(pre).FirstOrDefault();
                        if (item != null)
                        {
                            this.Repository.Delete(item);
                        }
                    }
                    else
                    {
                        this.Repository.Delete<TEntity>(entity);
                    }
                    
                }
                else
                {
                    this.Repository.Delete<TEntity>(entity);
                }

                
            }
            catch (Exception ex)
            {
                rs = ex.Message;
            }
            return rs;
        }
        public T JsonToObject<T>(object obj) where T : class
        {
            T objT = JsonConvert.DeserializeObject<T>(obj.ToString());
            return objT;
        }
        [Route("GridAction")]
        [HttpGet]
        public IHttpActionResult GridAction()
        {
            return Ok();
        }
    }

}
