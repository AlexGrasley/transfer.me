using Microsoft.AspNetCore.Components;
using MudBlazor;
using System.Text.RegularExpressions;

namespace Client.Pages
{
    public partial class SignIn : ComponentBase
    {
        public static bool success;
        public static string[] errors = { };
        public static MudTextField<string> pwField1;
        public static MudForm form;

        //Will want to update this, eventually. Once user information is created, there is no need for password validation here. That will be done on account creation.

        public static IEnumerable<string> PasswordStrength(string pw)
        {
            if (string.IsNullOrWhiteSpace(pw))
            {
                yield return "Password is required!";
                yield break;
            }
            if (pw.Length < 8)
                yield return "Password must be at least 8 characters.";
            if (!Regex.IsMatch(pw, @"[A-Z]"))
                yield return "Password must contain at least one capital letter.";
            if (!Regex.IsMatch(pw, @"[a-z]"))
                yield return "Password must contain at least one lowercase letter.";
            if (!Regex.IsMatch(pw, @"[0-9]"))
                yield return "Password must contain at least one number.";
        }
    }
}
