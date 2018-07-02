namespace AutofacDemo.Validations
{
    public class PasswordRule : IValidationRule<string>
    {
        const int minLength = 6;

        public string ValidationMessage { get; set; }

        public PasswordRule() => ValidationMessage = "Should be a password";

        public bool Check(string value) => !string.IsNullOrEmpty(value) && value.Length >= minLength;
    }
}
