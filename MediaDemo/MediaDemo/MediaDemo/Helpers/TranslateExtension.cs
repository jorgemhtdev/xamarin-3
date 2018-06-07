namespace MediaDemo.Helpers
{
    using Plugin.Multilingual;
    using System;
    using System.Reflection;
    using System.Resources;
    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;

    [ContentProperty("Text")]
	public class TranslateExtension : IMarkupExtension
	{
		const string ResourceId = "MediaDemo.Resources.AppResources";

		static readonly Lazy<ResourceManager> resmgr = new Lazy<ResourceManager>(() => new ResourceManager(ResourceId, typeof(TranslateExtension).GetTypeInfo().Assembly));
		
		public string Text { get; set; }

        public object ProvideValue(IServiceProvider serviceProvider)
		{
			if (Text == null) return "";

			var ci = CrossMultilingual.Current.CurrentCultureInfo;

			var translation = resmgr.Value.GetString(Text, ci);

			return translation;
		}
    }
}
