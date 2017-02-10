using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;
using Xamarin.Forms;

[assembly: ExportRenderer(typeof(Telerik.XamarinForms.DataControls.RadListView), typeof(Telerik.XamarinForms.DataControlsRenderer.iOS.ListViewRenderer))]
[assembly: ExportRenderer(typeof(Telerik.XamarinForms.Primitives.RadSideDrawer), typeof(Telerik.XamarinForms.PrimitivesRenderer.iOS.SideDrawerRenderer))]
[assembly: ExportRenderer(typeof(Telerik.XamarinForms.Input.RadAutoComplete), typeof(Telerik.XamarinForms.InputRenderer.iOS.AutoCompleteRenderer))]
[assembly: ExportRenderer(typeof(Telerik.XamarinForms.Chart.RadCartesianChart), typeof(Telerik.XamarinForms.ChartRenderer.iOS.CartesianChartRenderer))]

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
			new Telerik.XamarinForms.InputRenderer.iOS.AutoCompleteRenderer();
			new Telerik.XamarinForms.DataVisualization.Gauges.RadRadialGauge();
			new Telerik.XamarinForms.ChartRenderer.iOS.CartesianChartRenderer();

			LoadApplication(new App());

			return base.FinishedLaunching(app, options);
		}
	}
}
