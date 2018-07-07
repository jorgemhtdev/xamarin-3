using System.Linq;

namespace MapsDemo.Controls
{
    using System.Collections;
    using System.Collections.Generic;
    using Xamarin.Forms;
    using Xamarin.Forms.Maps;

    public class RouteMap : BindableObject
    {
        public static readonly BindableProperty RoutesProperty = BindableProperty.Create( nameof(Routes), typeof(IEnumerable<Position>),  typeof(RouteMap));

        public IEnumerable<Position> Routes
        {
            get => (IEnumerable<Position>)this.GetValue(RoutesProperty);
            set => this.SetValue(RoutesProperty, value);
        }

        public static readonly BindableProperty  ColorPinsProperty = BindableProperty.Create(nameof(ColorPins), typeof(IEnumerable<ColorPin>), typeof(RouteMap));
        public IEnumerable<ColorPin> ColorPins
        {
            get
            {
                return
                    (IEnumerable<ColorPin>)this.GetValue(ColorPinsProperty);
            }
            set
            {
                this.SetValue(ColorPinsProperty,
                    value);
            }
        }
    }
}
