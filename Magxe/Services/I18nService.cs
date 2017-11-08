using System.Collections.Generic;

namespace Magxe.Services
{
    internal static class I18NService
    {
        public static class Common
        {
            public static class Api
            {
                public static class Authentication
                {
                    public static string SampleBlogDescription = "Thoughts, stories and ideas.";
                }
            }
        }

        public static class Errors
        {
            public static class Api
            {
                public static class Authentication
                {
                    public static string SetupAlreadyCompleted = "Setup has already been completed.";
                    public static string SetupMustBeCompleted = "Setup must be completed before making this request.";
                }
            }

            public static class Models
            {
                public static class User
                {
                    public static string PasswordDoesNotComplyLength =
                        "Your password must be at least {minLength} characters long.";
                }
            }

            public static class ActionResult
            {
                public static class NoPermissionErrorResult
                {
                    public static string ErrorType = "NoPermissionError";
                    public static string Message = "You do not have permission to perform this request.";
                }

                public static class ValidationErrorResult
                {
                    public static string ErrorType = "ValidationError";
                    public static string Message = "The request failed validation.";
                }
            }
        }
    }
}