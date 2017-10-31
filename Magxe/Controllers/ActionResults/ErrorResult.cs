using System.Collections;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Magxe.Controllers.ActionResults
{
    internal abstract class ErrorResult : StatusCodeResult
    {
        private static readonly JsonSerializerSettings JsonSerializerSettings = new JsonSerializerSettings()
        {
            ContractResolver = new CamelCasePropertyNamesContractResolver()
        };

        protected ErrorResult(int statusCode) : base(statusCode)
        {
        }

        protected Dictionary<string, string> Dict = new Dictionary<string, string>()
        {
            {"ErrorType", string.Empty},
            {"Message", string.Empty}
        };

        public override async void ExecuteResult(ActionContext context)
        {
            base.ExecuteResult(context);

            var response = context.HttpContext.Response;
            response.ContentType = "application/json";


            var o = new
            {
                errors = new ArrayList()
                {
                    Dict
                }
            };

            await response.WriteAsync(JsonConvert.SerializeObject(o, JsonSerializerSettings));
        }
    }
}