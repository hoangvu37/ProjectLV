using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.ModelBinding;

namespace LV.Common
{
    public static class ApiExtensions
    {
        public static HttpResponseMessage CreateCustomResponse(this HttpRequestMessage request, HttpStatusCode statusCode, string errorMessage)
        {
            var errorMessageModel = new ErrorModel(statusCode, errorMessage);

            return request.CreateResponse(statusCode, errorMessageModel);
        }

        public static HttpResponseMessage CreateCustomResponse(this HttpRequestMessage request, HttpStatusCode statusCode, Exception exception, string errorMessage = "")
        {
            if (string.IsNullOrEmpty(errorMessage) && exception != null)
            {
                errorMessage = exception.Message;
            }

            var errorMessageModel = new ErrorModel(statusCode, errorMessage)
            {
                Exception = exception
            };

            return request.CreateResponse(statusCode, errorMessageModel);
        }

        public static HttpResponseMessage CreateCustomResponse(this HttpRequestMessage request,
            HttpStatusCode statusCode, ModelStateDictionary modelState, string errorMessage = "")
        {
            var errorMessageModel = new ErrorModel(statusCode, errorMessage);

            foreach (var error in modelState.Where(x => x.Value.Errors != null && x.Value.Errors.Any()))
            {
                errorMessageModel.ValidationErrors.Add(error.Key.Replace("model.", ""), error.Value.Errors);
            }

            return request.CreateResponse(statusCode, errorMessageModel);
        }

        public static ErrorModel CreateError(string errorMessage)
        {
            ErrorModel model = new ErrorModel(HttpStatusCode.BadRequest, errorMessage);
            return model;
        }
    }
}
