using System.Collections.Generic;
using Magxe.Services;

namespace Magxe.Controllers.ActionResults
{
    internal class ValidationErrorResult : BaseErrorResult
    {
        public ValidationErrorResult(string message = null) : this(message,null)
        {
        }

        public ValidationErrorResult(string message, Dictionary<string, string> appendDict) : base(422)
        {
            Dict["ErrorType"] = I18NService.Errors.ActionResult.ValidationErrorResult.ErrorType;
            Dict["Message"] = message ?? I18NService.Errors.ActionResult.ValidationErrorResult.Message;

            if (appendDict != null)
            {
                foreach (var kvp in appendDict)
                {
                    Dict[kvp.Key] = kvp.Value;
                }
            }
        }
    }
}