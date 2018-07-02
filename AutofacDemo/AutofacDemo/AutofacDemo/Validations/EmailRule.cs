namespace AutofacDemo.Validations
{
    using System.Text.RegularExpressions;

    public class EmailRule : IValidationRule<string>
    {
        // ^[a-z0-9][-a-z0-9._]+@([-a-z0-9]+.)+[a-z]{2,5}$ Or  ^[a-z0-9] [-a-z0-9._]+@([-a - z0 - 9]+[.])+[a-z]{2,5}$
        private const string pattern = @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z";

        public string ValidationMessage { get; set; }

        public EmailRule() => ValidationMessage = "Should be an email address";

        public bool Check(string value) => !string.IsNullOrEmpty(value) && Regex.IsMatch(value, pattern, RegexOptions.IgnoreCase);

    }
}
