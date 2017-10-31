namespace Magxe.Controllers.ActionResults
{
    internal class NoPermissionErrorResult : ErrorResult
    {
        public NoPermissionErrorResult(string message = null) : base(403)
        {
            Dict["ErrorType"] = "NoPermissionError";
            Dict["Message"] = message ?? "You do not have permission to perform this request.";
        }
    }
}