namespace AutofacDemo.Validations
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using Xamarin.Forms;

    public class ValidatableObject<T> : BindableObject, IValidity
    {
        private readonly List<IValidationRule<T>> validations;
        private readonly ObservableCollection<string> errors;
        private T value;
        private bool isValid;

        public List<IValidationRule<T>> Validations => validations;

        public ObservableCollection<string> Errors => errors;

        public T Value
        {
            get => value;
            set
            {
                this.value = value;
                OnPropertyChanged();
            }
        }

        public bool IsValid
        {
            get => isValid;

            set
            {
                isValid = value;
                errors.Clear();
                OnPropertyChanged();
            }
        }

        public ValidatableObject()
        {
            isValid = true;
            errors = new ObservableCollection<string>();
            validations = new List<IValidationRule<T>>();
        }

        public bool Validate()
        {
            Errors.Clear();

            IEnumerable<string> errors = validations.Where(v => !v.Check(Value))
                .Select(v => v.ValidationMessage);

            foreach (var error in errors)
            {
                Errors.Add(error);
            }

            IsValid = !Errors.Any();

            return this.IsValid;
        }
    }
}
