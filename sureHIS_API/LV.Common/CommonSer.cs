using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using System.Drawing;
using System.Security.Cryptography;

namespace LV.Common
{
    public class CommonSer
    {

        /// <summary>
        /// Convert list to string
        /// </summary>
        /// <param name="data">data converted</param>
        /// <returns>string</returns>
        public static string ConvertSortToString(List<Sort> data)
        {
            StringBuilder _result = null;
            if (data != null)
            {
                _result = new StringBuilder();
                for (int i = 0; i < data.Count; i++)
                {
                    if (i < data.Count - 1)
                    {
                        _result.Append(data[i].Field + " " + data[i].Dir + ", ");
                    }
                    else
                    {
                        _result.Append(data[i].Field + " " + data[i].Dir);
                    }
                }
                return _result.ToString();
            }
            else
            {
                return null;
            }

        }
        /// <summary>
        /// convert nosign by filed = filedname
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="Filed"></param>
        /// <returns></returns>

        public static Filter ConvertFilterToNosign(Filter filter, string FiledName)
        {
            if (filter != null)
            {
                foreach (var p in filter.filters)
                {
                    if (p.Field == FiledName)
                    {
                        p.Value = ConvertToUnSignNormal(p.Value);
                    }
                }
            }
            return filter;
        }

        /// <summary>
        /// ConvertFilertToString function
        /// </summary>
        /// <param name="filter">data convert</param>
        /// <returns>string after convert</returns>
        public static string ConvertFilertToString(Filter filter)
        {
            StringBuilder _whereClause = null;
            if (filter != null && (filter.filters != null && filter.filters.Count > 0))
            {
                _whereClause = new StringBuilder();
                var filters = filter.filters;

                for (var i = 0; i < filters.Count; i++)
                {
                    if (i < (filters.Count - 1))
                    {
                        if (filters[i].Value != null && filters[i].Value != "")
                        {
                            //edit by vdhoang
                            if (ToSQLOperator(filters[i].Operator) == " LIKE ")
                            {
                                _whereClause.Append(filters[i].Field + " " + ToSQLOperator(filters[i].Operator) + " " + ToValueOperatorLike(filters[i].Value) + " " + filter.Logic + " ");
                            }
                            else

                                _whereClause.Append(filters[i].Field + " " + ToSQLOperator(filters[i].Operator) + " " + ToValueOperator(filters[i].Value) + " " + filter.Logic + " ");
                        }

                    }
                    else
                    {
                        if (filters[i].Value != null && filters[i].Value != "")
                        {
                            if (ToSQLOperator(filters[i].Operator) == " LIKE ")
                            {
                                //string _a = ToValueOperatorLike(filters[i].Value);
                                _whereClause.Append(filters[i].Field + " " + ToSQLOperator(filters[i].Operator) + " " + ToValueOperatorLike(filters[i].Value));
                            }
                            else
                                _whereClause.Append(filters[i].Field + " " + ToSQLOperator(filters[i].Operator) + " " + ToValueOperator(filters[i].Value));
                        }

                        else _whereClause.Append("1 <> -1");
                    }

                }
                return _whereClause.ToString();
            }
            else
                return null;
        }

        public static string MultiField_ConvertFilertToString(Filter request)
        {
            string sqlExcute = "";
            string sqlItem = "AAALV BBBLV CCCLV";
            string bkSqlItem = sqlItem;
            int ls, ls1, ls2;
            string temp, temp1, temp2;

            int countField = request.filters.Count;
            for (int i = 0; i < countField; i++)
            {

                sqlItem = bkSqlItem;
                sqlItem = sqlItem.Replace("AAALV", request.filters[i].Field);

                // Equal
                if ((request.filters[i].Operator == "eq") && (!string.IsNullOrEmpty(request.filters[i].Value) == true))
                {
                    sqlItem = sqlItem.Replace("BBBLV", "=");
                    sqlItem = sqlItem.Replace("CCCLV", request.filters[i].Value);
                }

                // Contain
                if ((request.filters[i].Operator == "like") && (!string.IsNullOrEmpty(request.filters[i].Value) == true))
                {
                    sqlItem = sqlItem.Replace("BBBLV", "Like");
                    sqlItem = sqlItem.Replace("CCCLV", "N'%" + "" + request.filters[i].Value + "%'");
                }

                // Datepicker from Date to Date
                if ((request.filters[i].Operator == "datepickerfromto") && (!string.IsNullOrEmpty(request.filters[i].Value) == true))
                {
                    string sqlItem_Date = "AAALV between 'BBBLV' and 'CCCLV'";
                    string fromDate = "";
                    string toDate = "";

                    ls1 = request.filters[i].Value.IndexOf("[fromdate]");
                    ls2 = request.filters[i].Value.IndexOf("[/fromdate]");
                    fromDate = request.filters[i].Value.Substring(ls1 + 10, ls2 - ls1 - 10);

                    ls1 = request.filters[i].Value.IndexOf("[todate]");
                    ls2 = request.filters[i].Value.IndexOf("[/todate]");
                    toDate = request.filters[i].Value.Substring(ls1 + 8, ls2 - ls1 - 8);

                    if ((string.IsNullOrEmpty(fromDate) == true) && (!string.IsNullOrEmpty(toDate) == true))
                    {
                        DateTime dateTime_Temp = DateTime.Now;
                        fromDate = dateTime_Temp.Date.Month.ToString() + "/" + dateTime_Temp.Date.Day.ToString() + "/" + dateTime_Temp.Date.Year.ToString();
                    }
                    if ((string.IsNullOrEmpty(toDate) == true) && (!string.IsNullOrEmpty(fromDate) == true))
                    {
                        DateTime dateTime_Temp = DateTime.Now;
                        toDate = dateTime_Temp.Date.Month.ToString() + "/" + dateTime_Temp.Date.Day.ToString() + "/" + dateTime_Temp.Date.Year.ToString();
                    }

                    if ((!string.IsNullOrEmpty(fromDate) == true) && (!string.IsNullOrEmpty(toDate) == true))
                    {
                        sqlItem_Date = sqlItem_Date.Replace("AAALV", request.filters[i].Field);
                        sqlItem_Date = sqlItem_Date.Replace("BBBLV", fromDate);
                        sqlItem_Date = sqlItem_Date.Replace("CCCLV", toDate);

                        sqlItem = "(" + sqlItem_Date + ")";
                    }
                }

                // Search Field in Xml Table
                if ((request.filters[i].Operator == "likeinxmltable") && (!string.IsNullOrEmpty(request.filters[i].Value) == true))
                {
                    string sqlItem_LikeInXmlTable = "cast(AAALV as nvarchar(max)) like '%<BBBLV>'+N'%CCCLV%'+'</BBBLV>%'";
                    string value_Search = "";
                    string inTable = "";

                    ls1 = request.filters[i].Value.IndexOf("[value_sar]");
                    ls2 = request.filters[i].Value.IndexOf("[/value_sar]");
                    value_Search = request.filters[i].Value.Substring(ls1 + 11, ls2 - ls1 - 11);

                    ls1 = request.filters[i].Value.IndexOf("[intable]");
                    ls2 = request.filters[i].Value.IndexOf("[/intable]");
                    inTable = request.filters[i].Value.Substring(ls1 + 9, ls2 - ls1 - 9);

                    if ((!string.IsNullOrEmpty(value_Search) == true) && (!string.IsNullOrEmpty(inTable) == true))
                    {
                        sqlItem_LikeInXmlTable = sqlItem_LikeInXmlTable.Replace("AAALV", inTable);
                        sqlItem_LikeInXmlTable = sqlItem_LikeInXmlTable.Replace("BBBLV", request.filters[i].Field);
                        sqlItem_LikeInXmlTable = sqlItem_LikeInXmlTable.Replace("CCCLV", value_Search);

                        sqlItem = "(" + sqlItem_LikeInXmlTable + ")";
                    }
                }

                // Cộng vào SqlExcute
                if ((sqlItem.Contains("AAALV") != true) && (sqlItem.Contains("BBBLV") != true))
                {
                    sqlExcute += sqlItem + " " + request.Logic + " ";
                }
            }

            sqlExcute = sqlExcute.Trim();
            if (!string.IsNullOrEmpty(sqlExcute) == true)
            {
                if (sqlExcute.Substring(sqlExcute.Length - 3, 3) == "and")
                {
                    sqlExcute = sqlExcute.Remove(sqlExcute.Length - 3, 3);
                }

                if (sqlExcute.Substring(sqlExcute.Length - 2, 2) == "or")
                {
                    sqlExcute = sqlExcute.Remove(sqlExcute.Length - 2, 2);
                }
            }
            sqlExcute = sqlExcute.Trim();
            return sqlExcute;
        }
        public static string HandleFieldNoSign(string sqlExcute, string RawField, string InTable)
        {
            // Where cast(ItemsAuthors as nvarchar(max)) LIKE  N'%nha%'
            // Where cast(ItemsAuthors as nvarchar(max)) like '%<AuthorName>'+N'%nha%'+'</AuthorName>%'
            if (sqlExcute.Contains(RawField) == true)
            {

                int ls, ls1, ls2;
                int tongls, tongls1, tongls2;
                string temp, temp1, temp2;

                ls = -1;
                ls1 = -1;
                ls2 = -1;
                temp = "";
                temp1 = "";
                temp2 = "";

                ls = sqlExcute.IndexOf(RawField);
                temp = sqlExcute.Substring(ls, sqlExcute.Length - ls);
                ls1 = temp.IndexOf("N'%");
                ls2 = temp.IndexOf("%'");
                string Value = temp.Substring(ls1 + 3, ls2 - ls1 - 3);

                // Cat chuoi
                tongls1 = ls + ls1;
                tongls2 = ls + ls2;
                sqlExcute = sqlExcute.Remove(ls, tongls2 - ls + 2);


                string TempFieldNoSign = "cast(AAALV as nvarchar(max)) like '%<BBBLV>'+N'%CCCLV%'+'</BBBLV>%'";
                TempFieldNoSign = TempFieldNoSign.Replace("AAALV", InTable);
                TempFieldNoSign = TempFieldNoSign.Replace("BBBLV", RawField);
                TempFieldNoSign = TempFieldNoSign.Replace("CCCLV", Value);
                TempFieldNoSign = "(" + TempFieldNoSign + ")";

                sqlExcute = sqlExcute.Insert(ls, TempFieldNoSign);

                sqlExcute = sqlExcute.Trim();

            }
            else
            {

            }

            return sqlExcute;
        }


        /// <summary>
        /// ToSQLOperator function
        /// </summary>
        /// <param name="opera">data</param>
        /// <returns>string</returns>
        private static string ToSQLOperator(string opera)
        {
            switch (opera.ToLower())
            {
                case "eq": return " = ";
                case "neq": return " <> ";
                case "gte": return " >= ";
                case "gt": return " > ";
                case "lte": return " <= ";
                case "lt": return " < ";
                case "or": return " or ";
                case "and": return " and ";
                //vdhoang add
                case "like": return " LIKE ";
                case "contains": return " LIKE ";
                default: return null;
            }
        }

        /// <summary>
        /// ToValueOperator
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        private static string ToValueOperator(string val)
        {
            long _n;
            bool isNumeric = long.TryParse(val, out _n);
            if (isNumeric)
            {
                return val;
            }
            else
            {
                return string.Format("'{0}'", val);
            }
        }


        /// <summary>
        /// ToValueOperatorLike
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        private static string ToValueOperatorLike(string val)
        {
            long _n;
            bool isNumeric = long.TryParse(val, out _n);
            if (isNumeric)
            {
                return val;
            }
            else
            {
                return string.Format("N'%{0}%'", val);
            }
        }

        /// <summary>
        /// ConvertXMLToJson
        /// </summary>
        /// <param name="Xml"></param>
        /// <returns></returns>
        public static string ConvertXMLToJson(string xml)
        {
            if (xml != "" && xml != null)
            {

                XmlDocument _doc = new XmlDocument();
                _doc.LoadXml(xml);
                //return JsonConvert.SerializeXmlNode(doc);
                string _returnJson;
                var _rows = _doc.SelectNodes("//Table");
                if (_rows.Count == 1)
                {
                    var contentNode = _doc.SelectSingleNode("//NewDataSet");
                    contentNode.AppendChild(_doc.CreateNode("element", "Table", ""));
                    //contentNode.AppendChild(doc.CreateNode("element", "Total", ""));

                    // Convert to JSON and replace the empty element we created but keep the array declaration
                    _returnJson = JsonConvert.SerializeXmlNode(_doc, Newtonsoft.Json.Formatting.None, true).Replace(",null]", "]");
                }
                else
                {
                    // Convert to JSON
                    _returnJson = JsonConvert.SerializeXmlNode(_doc, Newtonsoft.Json.Formatting.None, true);
                }
                return _returnJson;
                //return JsonConvert.SerializeObject(new { data = returnJson, total = rows[0]["Total"].ToString()});
            }
            {
                object _table = null;
                return JsonConvert.SerializeObject(new { Table = _table });
            }

        }

        /// <summary>
        /// convert to unsign url
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string ConvertToUnSignUrl(string text)
        {
            for (int i = 32; i < 48; i++)
            {
                if (i != 38)
                    text = text.Replace(((char)i).ToString(), " ");
            }

            text = text.Replace(".", "-");
            text = text.Replace(" ", "-");
            text = text.Replace(",", "-");
            text = text.Replace(";", "-");
            text = text.Replace(":", "-");
            text = text.Replace("|", "-");
            text = text.Replace("&", "_");
            text = text.Replace("?", "_");
            text = text.Replace("#", "_");
            text = text.Replace("%", "_");
            text = text.Replace("*", "_");
            text = text.Replace("<", "_");
            text = text.Replace(">", "_");

            text = text.Replace("--", "-");
            System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(@"\p{IsCombiningDiacriticalMarks}+");
            string strFormD = text.Normalize(System.Text.NormalizationForm.FormD);
            return regex.Replace(strFormD, String.Empty).Replace('\u0111', 'd').Replace('\u0110', 'D');
        }

        /// <summary>
        /// Convert string to unsign
        /// </summary>
        /// <param name="text"></param>
        /// <returns>string</returns>
        public static string ConvertToUnSignNormal(string text)
        {
            for (int i = 33; i < 48; i++)
            {
                text = text.Replace(((char)i).ToString(), "");
            }

            for (int i = 58; i < 65; i++)
            {
                text = text.Replace(((char)i).ToString(), "");
            }

            for (int i = 91; i < 97; i++)
            {
                text = text.Replace(((char)i).ToString(), "");
            }

            for (int i = 123; i < 127; i++)
            {
                text = text.Replace(((char)i).ToString(), "");
            }

            //text = text.Replace(" ", "-");
            //text = Regex.Replace(text, @"[^0-9a-zA-Z]+", "-");

            Regex regex = new Regex(@"\p{IsCombiningDiacriticalMarks}+");

            string strFormD = text.Normalize(System.Text.NormalizationForm.FormD);
            return regex.Replace(strFormD, String.Empty).Replace('\u0111', 'd').Replace('\u0110', 'D');
        }

        public static Object ObjectToXML(string xml, Type objectType)
        {
            StringReader strReader = null;
            XmlSerializer serializer = null;
            XmlTextReader xmlReader = null;
            Object obj = null;
            try
            {
                strReader = new StringReader(xml);
                serializer = new XmlSerializer(objectType);
                xmlReader = new XmlTextReader(strReader);
                obj = serializer.Deserialize(xmlReader);
            }
            catch (Exception exp)
            {
                //Handle Exception Code
            }
            finally
            {
                if (xmlReader != null)
                {
                    xmlReader.Close();
                }
                if (strReader != null)
                {
                    strReader.Close();
                }
            }
            return obj;
        }
        public static string GetXMLFromObject(object o)
        {
            StringWriter sw = new StringWriter();
            XmlTextWriter tw = null;
            try
            {
                XmlSerializer serializer = new XmlSerializer(o.GetType());
                tw = new XmlTextWriter(sw);
                serializer.Serialize(tw, o);
            }
            catch (Exception ex)
            {
                //Handle Exception Code
            }
            finally
            {
                sw.Close();
                if (tw != null)
                {
                    tw.Close();
                }
            }
            return sw.ToString();
        }
        public static string GetMD5(string pwd)
        {
            if (pwd != null)
            {
                MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
                byte[] bHash = md5.ComputeHash(Encoding.UTF8.GetBytes(pwd));
                StringBuilder sbHash = new StringBuilder();

                foreach (byte b in bHash)
                {
                    sbHash.Append(String.Format("{0:x2}", b));
                }
                return sbHash.ToString();
            }
            return "";
        }
        
    }
}
