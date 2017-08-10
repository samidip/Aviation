using System;
using System.Collections.Generic;
using CoreGraphics;
using CoreAnimation;
using Foundation;

using TelerikUI;
using Telerik.XamarinForms.ChartRenderer.iOS;
using Telerik.XamarinForms.Chart;

namespace Aviation.iOS
{
    public class TelerikLineChartCustomRenderer : CartesianChartRenderer
    {
        public TelerikLineChartCustomRenderer()
        {
            
        }

		protected override void UpdateNativeWidget()
		{
			base.UpdateNativeWidget();
			this.Control.AllowAnimations = true;
		}

        protected override TKChartDelegate CreateChartDelegate(RadCartesianChart chart)
        {
            return new ChartWithAnimationDelegate(chart);
        }
    }

	public class ChartWithAnimationDelegate : CartesianChartDelegate
	{
        public ChartWithAnimationDelegate (RadCartesianChart chart) : base (chart)
        {
            
        }

		public override CAAnimation AnimationForSeries(TKChart chart, TKChartSeries series, TKChartSeriesRenderState state, CGRect rect)
		{
			var duration = 0.0;
			var animations = new List<CAAnimation>();
			for (int i = 0; i < (int)state.Points.Count; i++)
			{
				var pointKeyPath = state.AnimationKeyPathForPointAtIndex((uint)i);
				var keyPath = pointKeyPath + ".y";
				var point = state.Points.ObjectAtIndex((uint)i) as TKChartVisualPoint;
				var oldY = rect.Size.Height;

				if (i > 0)
				{
					var animation = new CAKeyFrameAnimation();
					animation.KeyPath = keyPath;
					animation.Duration = (double)(0.1 * i);
					animation.Values = new NSNumber[] { new NSNumber(oldY), new NSNumber(oldY), new NSNumber(point.Y) };
					animation.KeyTimes = new NSNumber[] { new NSNumber(0), new NSNumber(i / (i + 1.0)), new NSNumber(1.0) };
					animations.Add(animation);
					duration = animation.Duration;
				}
				else
				{
					var animation = new CABasicAnimation();
					animation.KeyPath = keyPath;
					animation.From = new NSNumber(oldY);
					animation.To = new NSNumber(point.Y);
					animation.Duration = 0.1;
					animations.Add(animation);
				}   
			}

			var group = new CAAnimationGroup();
			group.Duration = duration;
			group.Animations = animations.ToArray();
			return group;
		}
	}
}
