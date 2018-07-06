namespace MapsDemo.Views
{
    using Controls;
    using System.Collections.Generic;
    using Xamarin.Forms;
    using Xamarin.Forms.Maps;
    using Xamarin.Forms.Xaml;

    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MapView : ContentPage
	{
		public MapView ()
		{
			InitializeComponent ();


		    var pin = new CustomPin
		    {
		        Type = PinType.Place,
		        Position = new Position(40.42551, -3.70458),
		        Label = "I am a pin :)",
		        Address = "Calle Espíritu Santo",
                Id = "Xamarin",
		    };

		    MyMap.CustomPins = new List<CustomPin> { pin };
		    MyMap.Pins.Add(pin);
		    MyMap.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(40.42551, -3.70458), Distance.FromMiles(1.0)));
        }
	}
}