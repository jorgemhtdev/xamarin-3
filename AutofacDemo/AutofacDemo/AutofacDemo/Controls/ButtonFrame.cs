namespace AutofacDemo.Controls
{
    using System.Runtime.CompilerServices;
    using Xamarin.Forms;

    public class ButtonFrame : Frame
    {
        public ButtonFrame() => HasShadow = true;

        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);

            if (propertyName == ContentProperty.PropertyName)
            {
                ContentUpdated();
            }
        }

        private void ContentUpdated() => BackgroundColor = Content.BackgroundColor;
    }
}
