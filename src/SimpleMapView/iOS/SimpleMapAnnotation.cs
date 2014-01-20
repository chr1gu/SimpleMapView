using System;
using MonoTouch.CoreLocation;
using MonoTouch.MapKit;

namespace SimpleMapView
{
	public class SimpleMapAnnotation : MKAnnotation
	{
		public override CLLocationCoordinate2D Coordinate {get;set;}
		string title, subtitle;

		public override string Title
		{
			get { return title; }
		}

		public override string Subtitle
		{
			get { return subtitle; }
		}

		public SimpleMapAnnotation (CLLocationCoordinate2D coordinate, string title, string subtitle) 
		{
			this.Coordinate = coordinate;
			this.title = title;
			this.subtitle = subtitle;
		}
	}
}
