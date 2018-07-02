namespace AutofacDemo.Controls
{
    using System.Runtime.CompilerServices;
    using Xamarin.Forms;

    public class ExtendedEntry : Entry
    {
        private Color lineColorToApply;

        public static readonly BindableProperty LineColorProperty = BindableProperty.Create("LineColor", typeof(Color), typeof(ExtendedEntry), Color.Default);
        public static readonly BindableProperty FocusLineColorProperty = BindableProperty.Create("FocusLineColor", typeof(Color), typeof(ExtendedEntry), Color.Default);
        public static readonly BindableProperty IsValidProperty = BindableProperty.Create("IsValid", typeof(bool), typeof(ExtendedEntry), true);
        public static readonly BindableProperty InvalidLineColorProperty = BindableProperty.Create("InvalidLineColor", typeof(Color), typeof(ExtendedEntry), Color.Default);

        public ExtendedEntry()
        {
            Focused += OnFocused;
            Unfocused += OnUnfocused;

            ResetLineColor();
        }

        public Color LineColorToApply
        {
            get => lineColorToApply;
            private set
            {
                lineColorToApply = value;
                OnPropertyChanged(nameof(LineColorToApply));
            }
        }

        public Color LineColor
        {
            get => (Color)GetValue(LineColorProperty);
            set => SetValue(LineColorProperty, value);
        }

        public Color FocusLineColor
        {
            get => (Color)GetValue(FocusLineColorProperty);
            set => SetValue(FocusLineColorProperty, value);
        }

        public bool IsValid
        {
            get => (bool)GetValue(IsValidProperty);
            set => SetValue(IsValidProperty, value);
        }

        public Color InvalidLineColor
        {
            get => (Color)GetValue(InvalidLineColorProperty);
            set => SetValue(InvalidLineColorProperty, value);
        }

        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);

            if (propertyName == IsValidProperty.PropertyName)
            {
                CheckValidity();
            }
        }

        private void OnFocused(object sender, FocusEventArgs e)
        {
            IsValid = true;
            LineColorToApply = FocusLineColor != Color.Default
                ? FocusLineColor
                : GetNormalStateLineColor();
        }

        private void OnUnfocused(object sender, FocusEventArgs e) => ResetLineColor();

        private void ResetLineColor() => LineColorToApply = GetNormalStateLineColor();

        private void CheckValidity()
        {
            if (!IsValid)
            {
                LineColorToApply = InvalidLineColor;
            }
        }

        private Color GetNormalStateLineColor() => LineColor != Color.Default ? LineColor : TextColor;
    }
}

