using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Dynamic;
using System.Collections;
using System.Web.Script.Serialization;
using System.Reflection;
using System.Data;
using System.Web.Http.Results;

namespace LV.Service.Common
{
    public class JsonConverter
    {
        public static string ObjectToJson(object obj)
        {

            return JsonConvert.SerializeObject(obj);
        }

        public static T JsonToObject<T>(string json)
        {
            return JsonConvert.DeserializeObject<T>(json);
        }
        public static dynamic JsonToObject(string json)
        {
            return JsonConvert.DeserializeObject(json);
        }

        public static string  DataSetToJson(DataSet ds)
        {
           return JsonConvert.SerializeObject(ds.Tables[0], Formatting.None);
            //System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            //List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
            //Dictionary<string, object> row;
            //foreach (DataRow dr in ds.Tables[0].Rows)
            //{
            //    row = new Dictionary<string, object>();
            //    foreach (DataColumn col in ds.Tables[0].Columns)
            //    {
            //        row.Add(col.ColumnName, dr[col]);
            //    }
            //    rows.Add(row);
            //}
            //return serializer.Serialize(rows);
        }
        #region No need to use

        //http://www.codeproject.com/Tips/986176/Deeply-Nested-JSON-Deserialization-Using-Recursion
        public static ExpandoObject ToExpando(string json)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            IDictionary<string, object> dictionary =
                serializer.Deserialize<IDictionary<string, object>>(json);
            return Expando(dictionary);
        }

        private static ExpandoObject Expando(IDictionary<string, object> dictionary)
        {
            ExpandoObject expandoObject = new ExpandoObject();
            IDictionary<string, object> objects = expandoObject;

            foreach (var item in dictionary)
            {
                bool processed = false;

                if (item.Value is IDictionary<string, object>)
                {
                    objects.Add(item.Key, Expando((IDictionary<string, object>)item.Value));
                    processed = true;
                }
                else if (item.Value is ICollection)
                {
                    List<object> itemList = new List<object>();

                    foreach (var item2 in (ICollection)item.Value)

                        if (item2 is IDictionary<string, object>)
                            itemList.Add(Expando((IDictionary<string, object>)item2));
                        else
                            itemList.Add(Expando(new Dictionary<string,
                                object> { { "Unknown", item2 } }));

                    if (itemList.Count > 0)
                    {
                        objects.Add(item.Key, itemList);
                        processed = true;
                    }
                }

                if (!processed)
                    objects.Add(item);
            }

            return expandoObject;
        }

        public ExpandoObject ToExpando2(string json, dynamic pat)
        {
            // GetDicProp<Hl7.Fhir.Model.Patient>();
            LV.Common.DynamicAssembly.InvokeGenericMethod(pat.GetType(), this, "GetDicProp", null);
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            IDictionary<string, object> dictionary =
                serializer.Deserialize<IDictionary<string, object>>(json);
            return Expando2(dictionary, pat);
        }

        private ExpandoObject Expando2(IDictionary<string, object> dictionary, dynamic pat)
        {
            ExpandoObject expandoObject = new ExpandoObject();
            IDictionary<string, object> objects = expandoObject;

            foreach (var item in dictionary)
            {
                bool processed = false;

                if (item.Value is IDictionary<string, object>)//Object lồng list
                {
                    PropertyInfo p;
                    dynamic patTemp = pat;
                    if (_propertyMap.TryGetValue(item.Key.ToLower(), out p))
                    {

                        patTemp = p.GetValue(pat, null);
                        if (patTemp == null)
                        {
                            dynamic valTemp = null;
                            if (p.PropertyType.IsArray || p.PropertyType.IsGenericType)
                            {
                                valTemp = LV.Common.DynamicAssembly.InvokeGenericMethod(p.PropertyType, new JsonConverter(), "CreateList", 1);
                            }
                            else
                            {
                                valTemp = Assembly.Load("Hl7.Fhir.Core").CreateInstance(p.PropertyType.FullName);
                            }
                            p.SetValue(pat, valTemp, null);
                            patTemp = p.GetValue(pat, null);
                            // pat.GetType().GetProperty("Meta").SetValue(pat, valTemp, null);
                        }
                    }
                    else
                    {
                        throw new Exception("Lỗi ko tìm thấy property " + item.Key.ToLower());
                    }

                    objects.Add(item.Key, Expando2((IDictionary<string, object>)item.Value, patTemp));
                    processed = true;
                }
                else if (item.Value is ICollection)
                {
                    List<object> itemList = new List<object>();

                    foreach (var item2 in (ICollection)item.Value)

                        if (item2 is IDictionary<string, object>)
                            itemList.Add(Expando2((IDictionary<string, object>)item2, pat));
                        else
                            itemList.Add(Expando2(new Dictionary<string,
                                object> { { "Unknown", item2 } }, pat));

                    if (itemList.Count > 0)
                    {
                        objects.Add(item.Key, itemList);
                        processed = true;
                    }
                }

                if (!processed)//Add 1 đối tượng
                {
                    if (item.Key == "resourceType")
                    {
                        continue;
                    }
                    objects.Add(item);
                    ConvertType(item, pat);
                }
            }

            return expandoObject;
        }
        private void ConvertType(KeyValuePair<string, object> kv, dynamic pat)
        {
            PropertyInfo p;
            //if (_propertyMap.TryGetValue(kv.Key.ToLower(), out p))
            //{
            //}
            //else
            //{
            //    throw new Exception("Lỗi ko tìm thấy property " + kv.Key.ToLower());
            //}
            p = pat.GetType().GetProperty(kv.Key.ToLower(), BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
            if (p.PropertyType.FullName.StartsWith("System"))
            {
                var t = Type.GetType(p.PropertyType.FullName);
                if (t.Name == "Nullable`1")
                {
                    t = Nullable.GetUnderlyingType(t);
                    var converter = System.ComponentModel.TypeDescriptor.GetConverter(t);
                    var tt = converter.CanConvertFrom(kv.Value.GetType()) ? converter.ConvertFrom(kv.Value) : null;
                    p.SetValue(pat, tt, null);
                    return;
                }
                if (p.PropertyType.FullName == "System.String")
                {
                    p.SetValue(pat, kv.Value, null);
                    //p.SetValue(pat, kv.Value, null);
                }
                else
                    p.SetValue(pat, Convert.ChangeType(kv.Value, t), null);
            }
            else
            {
                var earth = Assembly.Load("Hl7.Fhir.DSTU2.Core").GetType(p.PropertyType.FullName);

                if (earth.IsEnum)
                {
                    var newV = Enum.Parse(earth, kv.Value as string);
                    p.SetValue(pat, newV, null);
                }
                else if (earth.Name.StartsWith("Fhir"))
                {
                    //Dùng để biết type nào để parse ứng với class FHIR nào.VD: FhirBoolean thì cần lấy ra chữ Boolean rồi parse value sang kiểu boolean
                    //Tiếp theo gán = FhirBoolean( value đã parse vào) mới đúng
                    var typeParse = Type.GetType("");
                    //switch (earth.Name.Remove(0, 4))
                    //{
                    //    case "String":
                    //        typeParse = typeof(string);
                    //        value = Convert.ChangeType(value, typeParse);
                    //        value = new FhirString(value);
                    //        break;
                    //    case "Boolean":
                    //        typeParse = typeof(bool);
                    //        value = Convert.ChangeType(value, typeParse);
                    //        value = new FhirBoolean(value);
                    //        break;
                    //    case "DateTime":
                    //        typeParse = typeof(DateTime);
                    //        value = Convert.ChangeType(value, typeParse);
                    //        value = new FhirDateTime(value);
                    //        break;
                    //    case "Decimal":
                    //        typeParse = typeof(decimal);
                    //        value = Convert.ChangeType(value, typeParse);
                    //        value = new FhirDecimal(value);
                    //        break;
                    //}
                }
                else
                {
                  //  var myVal = LV.Common.DynamicAssembly.InvokeGenericMethod(earth, oTargetType, "GetValueOrNull", kv.Value);
                  //  p.SetValue(pat, myVal, null);
                }
            }
        }
        private Dictionary<string, PropertyInfo> _propertyMap;
        public void GetDicProp<T1>() where T1 : class
        {
            // At this point we can convert each
            // property name to lower case so we avoid 
            // creating a new string more than once.
            _propertyMap =
                typeof(T1)
                .GetProperties()
                .ToDictionary(
                    p => p.Name.ToLower(),
                    p => p
                );
        }
        public dynamic CreateList<T>(int? capital = 1) where T : class
        {
            dynamic lst = new List<T>();
            T item = null;
            for (int i = 0; i < capital.Value; i++)
            {
                if (typeof(T) == Type.GetType("System.String"))
                {
                    item = "" as T;
                }
                else
                {
                    item = System.Activator.CreateInstance(typeof(T)) as T;
                }

                lst.Add(item);
            }
            return lst;
        }
        
        #endregion
    }

}
