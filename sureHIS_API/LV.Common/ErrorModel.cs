using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.ModelBinding;

namespace LV.Common
{
    public class ErrorModel
    {
        public ErrorModel(HttpStatusCode statusCode, string message)
        {
            StatusCode = (int)statusCode;
            Message = message;
            ValidationErrors = new Dictionary<string, ModelErrorCollection>();
        }

        public ErrorModel(HttpStatusCode statusCode)
        {
            StatusCode = (int)statusCode;
            ValidationErrors = new Dictionary<string, ModelErrorCollection>();
        }
        public object EntityError { get; set; }
        public bool LVApiError { get { return true; } }
        public string MsgCode { get; set; }
        public string Message { get; set; }
        public string FieldName { get; set; }
        public int StatusCode { get; set; }
        public Dictionary<string, ModelErrorCollection> ValidationErrors { get; set; }
        public Exception Exception { get; set; }

        public List<ErrorModel> _child = new List<ErrorModel>();
        public List<ErrorModel> Child { get { return _child; } }
    }
}
