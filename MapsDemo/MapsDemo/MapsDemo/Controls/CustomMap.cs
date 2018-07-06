namespace MapsDemo.Controls
{
    using Xamarin.Forms.Maps;
    using System.Collections.Generic;

    public class CustomMap : Map
    {
        public List<CustomPin> CustomPins { get; set; }
    }
}
