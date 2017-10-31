using System.Collections.Generic;

namespace Magxe.Controllers.ActionResults
{
    internal class ValidationErrorResult : ErrorResult
    {
        public ValidationErrorResult(string message = null) : this(message,null)
        {
        }

        public ValidationErrorResult(string message, Dictionary<string, string> appendDict) : base(422)
        {
            Dict["ErrorType"] = "ValidationError";
            Dict["Message"] = message ?? "The request failed validation.";

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