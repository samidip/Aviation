using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;

[assembly: Xamarin.Forms.ExportRenderer(typeof(Telerik.XamarinForms.DataControls.RadListView), typeof(Telerik.XamarinForms.DataControlsRenderer.iOS.ListViewRenderer))]


namespace Aviation.iOS
{
	[Register("AppDelegate")]
	public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
	{
		public override bool FinishedLaunching(UIApplication app, NSDictionary options)
		{
			global::Xamarin.Forms.Forms.Init();

			Telerik.XamarinForms.Common.iOS.TelerikForms.Init();
			new Telerik.XamarinForms.DataControlsRenderer.iOS.ListViewRenderer();

			LoadApplication(new App());

			return base.FinishedLaunching(app, options);
		}
	}
}
