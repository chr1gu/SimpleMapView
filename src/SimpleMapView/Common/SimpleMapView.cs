using System;
using MonoTouch.MapKit;

namespace SimpleMapView
{
	public enum MapType
	{
		Standard = MKMapType.Standard,
		Satellite = MKMapType.Satellite,
		Hybrid = MKMapType.Hybrid
	}

	public enum AnnotationPinColor
	{
		Green = MKPinAnnotationColor.Green,
		Red = MKPinAnnotationColor.Red,
		Purple = MKPinAnnotationColor.Purple
	}

	public class SimpleMapView
	{
		/// <summary>Converts miles to latitude degrees</summary>
		public static double MilesToLatitudeDegrees(double miles)
		{
			double earthRadius = 3960.0; // in miles
			double radiansToDegrees = 180.0/Math.PI;
			return (miles/earthRadius) * radiansToDegrees;
		}

		/// <summary>Converts miles to longitudinal degrees at a specified latitude</summary>
		public static double MilesToLongitudeDegrees(double miles, double atLatitude)
		{
			double earthRadius = 3960.0; // in miles
			double degreesToRadians = Math.PI/180.0;
			double radiansToDegrees = 180.0/Math.PI;
			// derive the earth's radius at that point in latitude
			double radiusAtLatitude = earthRadius * Math.Cos(atLatitude * degreesToRadians);
			return (miles / radiusAtLatitude) * radiansToDegrees;
		}

		/// <summary>Converts kilometres to latitude degrees</summary>
		public static double KilometresToLatitudeDegrees(double kms)
		{
			double earthRadius = 6371.0; // in kms
			double radiansToDegrees = 180.0/Math.PI;
			return (kms/earthRadius) * radiansToDegrees;
		}

		/// <summary>Converts kilometres to longitudinal degrees at a specified latitude</summary>
		public static double KilometresToLongitudeDegrees(double kms, double atLatitude)
		{
			double earthRadius = 6371.0; // in kms
			double degreesToRadians = Math.PI/180.0;
			double radiansToDegrees = 180.0/Math.PI;
			// derive the earth's radius at that point in latitude
			double radiusAtLatitude = earthRadius * Math.Cos(atLatitude * degreesToRadians);
			return (kms / radiusAtLatitude) * radiansToDegrees;
		}
	}
}
