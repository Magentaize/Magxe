using Magxe.Services;

namespace Magxe.Controllers.ActionResults
{
    internal class NoPermissionErrorResult : ErrorResult
    {
        public NoPermissionErrorResult(string message = null) : base(403)
        {
            Dict["ErrorType"] = I18NService.Errors.ActionResult.NoPermissionErrorResult.ErrorType;
            Dict["Message"] = message ?? I18NService.Errors.ActionResult.NoPermissionErrorResult.Message;
        }
    }
}