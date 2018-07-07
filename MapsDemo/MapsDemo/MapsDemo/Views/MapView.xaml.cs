using System.Collections;

namespace MapsDemo.Views
{
    using System;
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

		    LoadUbication(pin);
		}

	    private async void LoadUbication(CustomPin pin)
	    {
	        MyMap.CustomPins = new List<CustomPin> { pin };
	        MyMap.Pins.Add(pin);
	        MyMap.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(40.42551, -3.70458), Distance.FromKilometers(1.0)));
            //var currentLocation = await Plugin.Geolocator.CrossGeolocator.Current.GetPositionAsync(TimeSpan.FromSeconds(10));
        }

	    public void FinishRender()
	    {
	        //MyMap.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(40.42551, -3.70458), Distance.FromKilometers(1.0)));

            /*
	        ColorPins = new List<ColorPin>();
	        ((IList)ColorPins).Add(new ColorPin
	        {
	            Label = "Yo",
	            Position = Routes.First(),
	            PinColor =
	                Color.Blue
	        });

	        ((IList)ColorPins).Add(new ColorPin
	        {
	            Label = "Destino",
	            Position = Routes.Last(),
	            PinColor = Color.Red
	        });*/
	    }
    }
}