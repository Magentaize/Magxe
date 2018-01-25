using Magxe.Services;

namespace Magxe.Controllers.ActionResults
{
    internal class ArgumentOutOfRangeErrorResult : BaseErrorResult
    {
        public ArgumentOutOfRangeErrorResult(string message = null) : base(400)
        {
            Dict["ErrorType"] = I18NService.Errors.ActionResult.ArgumentOutOfRangeErrorResult.ErrorType;
            Dict["Message"] = message ?? I18NService.Errors.ActionResult.ArgumentOutOfRangeErrorResult.Message;
        }
    }
}