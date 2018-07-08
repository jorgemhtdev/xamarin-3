using System;
using System.Collections.Generic;
using SkiaSharp.Views.Forms;

namespace MicrochartsDemo
{
    using Xamarin.Forms;

    public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
		}
        /*
	    private Microcharts.Entry Values()
	    {
	        var r = new Random();
	        Microcharts.Entry newValue = null;

	        var numberRandom = r.Next(1, 20);

            newValue = new Microcharts.Entry(numberRandom)
	        {
	            Label = $"Value number {numberRandom}",
	            Color = Color.Yellow.ToSKColor(),
	            ValueLabel = numberRandom.ToString(),
	            TextColor = Color.Red.ToSKColor()
	        };

            return newValue;
	    }
        */
	    protected override void OnAppearing()
	    {
            base.OnAppearing();

	        IList<Microcharts.Entry> firstSerie = new List<Microcharts.Entry>();
            IList<Microcharts.Entry> secondSerie = new List<Microcharts.Entry>();
	        IList<Microcharts.Entry> thirdSerie = new List<Microcharts.Entry>();
	        IList<Microcharts.Entry> fourthSerie = new List<Microcharts.Entry>();
	        IList<Microcharts.Entry> fifthSerie = new List<Microcharts.Entry>();


            var r = new Random();

	        for (var i = 1; i < 10; i++)
	        {	           
	            var numberRandom = r.Next(1, 20);

	            var newValue = new Microcharts.Entry(numberRandom)
	            {
	                Label = $"Value number {numberRandom}",
	                Color = Color.DeepSkyBlue.ToSKColor(),
	                ValueLabel = numberRandom.ToString(),
	                TextColor = Color.Black.ToSKColor()
	            };

                firstSerie.Add(newValue);
	            thirdSerie.Add(newValue);
	            fifthSerie.Add(newValue);

            }

	        var Audi = new Microcharts.Entry(10)
	        {
	            Label = $"Value number {10}",
	            Color = Color.Red.ToSKColor(),
	            ValueLabel = "Audi",
	            TextColor = Color.Red.ToSKColor()
	        };

            secondSerie.Add(Audi);

	        var BMW = new Microcharts.Entry(15)
	        {
	            Label = $"Value number {15}",
	            Color = Color.Gold.ToSKColor(),
                ValueLabel = "BMW",
                TextColor = Color.Gold.ToSKColor()
	        };

	        secondSerie.Add(BMW);

            var Porche = new Microcharts.Entry(33)
	        {
	            Label = $"Value number {33}",
	            Color = Color.LightSkyBlue.ToSKColor(),
                ValueLabel = "Porche",
                TextColor = Color.LightSkyBlue.ToSKColor()
	        };

	        secondSerie.Add(Porche);

            for (var i = 1; i < 10; i++)
	        {
	            var numberRandom = r.Next(1, 20);

	            var newValue = new Microcharts.Entry(numberRandom)
	            {
	                Label = $"Value number {numberRandom}",
	                Color = Color.Red.ToSKColor(),
	                ValueLabel = numberRandom.ToString(),
	                TextColor = Color.Black.ToSKColor()
	            };

	            fourthSerie.Add(newValue);
            }

            ChartViewFirst.Chart = new Microcharts.BarChart()
	        {
	            Entries = firstSerie,
                LabelTextSize = 20,
                Margin = 15
	        };

	        ChartViewSecond.Chart = new Microcharts.DonutChart()
	        {
	            Entries = secondSerie,
	            LabelTextSize = 20,
                HoleRadius = 0.1f,
	            Margin = 15
            };

	        ChartViewThird.Chart = new Microcharts.LineChart()
	        {
	            Entries = thirdSerie,
	            LabelTextSize = 20,
	            Margin = 15
            };

	        ChartViewFourth.Chart = new Microcharts.PointChart()
	        {
	            Entries = fourthSerie,
	            LabelTextSize = 20,
	            Margin = 15
            };

	        ChartViewFifth.Chart = new Microcharts.RadarChart()
	        {
	            Entries = fifthSerie,
	            LabelTextSize = 20,
	            Margin = 15
            };

            ChartViewSixth.Chart = new Microcharts.RadialGaugeChart()
	        {
	            Entries = secondSerie,
                StartAngle = 0.5f,
	            LabelTextSize = 20,
	            Margin = 15
            };
        }
	}
}
