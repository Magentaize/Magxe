using Microsoft.AspNetCore.Mvc;

namespace Magxe.Data.Validation
{
    internal static class Password
    {
        private static readonly string[] DisallowedPasswords =
        {
            "password", "magxe", "ghost", "passw0rd", "1234567890", "0987654321", "qwertyuiop", "qwertzuiop",
            "asdfghjkl;", "abcdefghij", "1q2w3e4r5t", "12345asdfg"
        };

        public static IActionResult ValidatePassword(string password, string email, string blogTitle)
        {
            if (password.Length < 10) ;
            return null;
        }
    }
}