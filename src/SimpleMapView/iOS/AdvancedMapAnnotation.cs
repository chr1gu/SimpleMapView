using System;
using MonoTouch.CoreLocation;
using MonoTouch.UIKit;

namespace SimpleMapView
{
	public class AdvancedMapAnnotation : SimpleMapAnnotation
	{
		public AnnotationPinColor PinColor;

		public UIView RightCalloutAccessoryView;

		public UIView LeftCalloutAccessoryView;

		public UIImage MarkerImage;

		public Action<AdvancedMapAnnotation> ClickHandler;

		public AdvancedMapAnnotation (double latitude, double longitude, string title, string subtitle) : base(new CLLocationCoordinate2D (latitude, longitude), title, subtitle)
		{

		}
	}
}
