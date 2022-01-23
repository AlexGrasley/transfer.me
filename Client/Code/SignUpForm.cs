using MudBlazor;
using System.Text.RegularExpressions;

namespace Client.Code
{
    public static class SignUpForm
    {
        public static bool Success;
        public static string[] Errors = { };
        public static MudTextField<string> FirstPasswordField;
        public static MudTextField<string> ConfirmationPasswordField;
        public static MudTextField<string> Username;
        public static MudTextField<string> EmailAddress;
        public static MudForm Form;

        public static IEnumerable<string> PasswordStrength(string pw)
        {
            if (string.IsNullOrWhiteSpace(pw) || string.IsNullOrEmpty(pw))
            {
                yield return "Password is required!";
                yield break;
            }
            if (pw.Length < 10)
                yield return "Password must be at least 10 characters.";
            if (!Regex.IsMatch(pw, @"[A-Z]"))
                yield return "Password must contain at least one capital letter.";
            if (!Regex.IsMatch(pw, @"[a-z]"))
                yield return "Password must contain at least one lowercase letter.";
            if (!Regex.IsMatch(pw, @"[0-9]"))
                yield return "Password must contain at least one number.";
        }
        public static IEnumerable<string> PasswordsMatch(string arg)
        {
            if (FirstPasswordField.Value != arg)
                yield return "Passwords must match!";
        }

        public static IEnumerable<string> EmailValid(string EmailAddress) 
        {
            if(string.IsNullOrEmpty(EmailAddress) || string.IsNullOrWhiteSpace(EmailAddress))
            {
                yield return "Email address cannot be empty";
            }
            if(!Regex.IsMatch(EmailAddress, @"@.*\."))
                yield return "Please enter a valid email address.";
        }
        public static IEnumerable<string> UsernameValid(string Username)
        {
            bool UsernameAvailable = true; //some logic to check if username exists in the database.
            if (string.IsNullOrEmpty(Username) || string.IsNullOrWhiteSpace(Username))
                yield return "Username cannot be empty";
            if (Regex.IsMatch(Username, @"[^a-zA-Z0-9_\.]"))
                yield return "Username can contain only numbers, letters and special characters: \"_\" \".\"";
            if (Username.Length < 6)
                yield return "Username must be at least 6 characters.";
            if (!UsernameAvailable)
                yield return "That username is already taken.";
        }
    }
}
