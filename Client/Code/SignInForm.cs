using MudBlazor;
using System.Text.RegularExpressions;

namespace Client.Code
{
    public static class SignInForm
    {
        public static bool success;
        public static string[] errors = { };
        public static MudTextField<string> pwField1;
        public static MudForm form;

        public static IEnumerable<string> PasswordStrength(string pw)
        {
            if (string.IsNullOrWhiteSpace(pw))
            {
                yield return "Password is required!";
                yield break;
            }
            if (pw.Length < 8)
                yield return "Password must be at least of length 8";
            if (!Regex.IsMatch(pw, @"[A-Z]"))
                yield return "Password must contain at least one capital letter";
            if (!Regex.IsMatch(pw, @"[a-z]"))
                yield return "Password must contain at least one lowercase letter";
            if (!Regex.IsMatch(pw, @"[0-9]"))
                yield return "Password must contain at least one digit";
        }

        public static string PasswordMatch(string arg)
        {
            if (pwField1.Value != arg)
                return "Passwords don't match";
            return null;
        }

    }
}
