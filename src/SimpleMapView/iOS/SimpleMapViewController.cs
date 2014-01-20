using System;
using MonoTouch.UIKit;
using MonoTouch.MapKit;
using MonoTouch.CoreLocation;

namespace SimpleMapView
{
	public partial class SimpleMapViewController : UIViewController
	{
		private MapType _type;

		public MapType Type {
			get { return _type; }
			set {
				_type = value;
				MapView.MapType = (MKMapType)value;
			}
		}

		public bool ShowsUserLocation
		{
			get { return MapView.ShowsUserLocation; }
			set { MapView.ShowsUserLocation = value; }
		}

		public MKMapView MapView;

		public SimpleMapViewController ()
		{
			MapView = new MKMapView (View.Bounds);
			MapView.AutoresizingMask = UIViewAutoresizing.FlexibleDimensions;
			MapView.Delegate = new SimpleMapDelegate();
			View.AddSubview(MapView);
		}

		public void ShowRegion (double latitude, double longitude)
		{
			CLLocationCoordinate2D coords = new CLLocationCoordinate2D(latitude, longitude);
			MKCoordinateSpan span = new MKCoordinateSpan(SimpleMapView.MilesToLatitudeDegrees(2), SimpleMapView.MilesToLongitudeDegrees(2, coords.Latitude));
			MapView.Region = new MKCoordinateRegion(coords, span);
		}

		public void ShowRegionWithKilometerRadius (double latitude, double longitude, double radius)
		{
			CLLocationCoordinate2D coords = new CLLocationCoordinate2D(latitude, longitude);
			MKCoordinateSpan span = new MKCoordinateSpan(SimpleMapView.KilometresToLatitudeDegrees (radius), SimpleMapView.KilometresToLongitudeDegrees(radius, coords.Latitude));
			MapView.Region = new MKCoordinateRegion(coords, span);
		}

		public void ShowRegionWithMilesRadius (double latitude, double longitude, double radius)
		{
			CLLocationCoordinate2D coords = new CLLocationCoordinate2D(latitude, longitude);
			MKCoordinateSpan span = new MKCoordinateSpan(SimpleMapView.MilesToLatitudeDegrees(radius), SimpleMapView.MilesToLongitudeDegrees(radius, coords.Latitude));
			MapView.Region = new MKCoordinateRegion(coords, span);
		}

		public void AddAnnotation (double latitude, double longitude)
		{
			this.AddAnnotation (latitude, longitude, null, null);
		}

		public void AddAnnotation (double latitude, double longitude, string title, string description)
		{
			var annotation = new SimpleMapAnnotation (new CLLocationCoordinate2D(latitude, longitude), title, description);
			MapView.AddAnnotation (annotation);
		}

		public void AddAdvancedAnnotation(AdvancedMapAnnotation annotation)
		{
			MapView.AddAnnotation (annotation);
		}
	}
}
