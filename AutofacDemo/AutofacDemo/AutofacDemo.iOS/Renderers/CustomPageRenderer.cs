using AutofacDemo.iOS.Renderers;
using AutofacDemo.Utils;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(Page), typeof(CustomPageRenderer))]
namespace AutofacDemo.iOS.Renderers
{
    public class CustomPageRenderer : PageRenderer
    {
        IElementController ElementController => Element as IElementController;

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);

            var color = NavigationBarAttachedProperty.GetTextColor(Element);
            NavigationBarAttachedProperty.SetTextColor(Element, color);
        }
    }
}