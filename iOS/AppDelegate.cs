using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;
using Xamarin.Forms;

[assembly: Xamarin.Forms.ExportRenderer(typeof(Telerik.XamarinForms.DataControls.RadListView), typeof(Telerik.XamarinForms.DataControlsRenderer.iOS.ListViewRenderer))]
[assembly: ExportRenderer(typeof(Telerik.XamarinForms.Primitives.RadSideDrawer), typeof(Telerik.XamarinForms.PrimitivesRenderer.iOS.SideDrawerRenderer))]


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
			new Telerik.XamarinForms.PrimitivesRenderer.iOS.SideDrawerRenderer();

			LoadApplication(new App());

			return base.FinishedLaunching(app, options);
		}
	}
}
