using System;
using MonoTouch.MapKit;
using MonoTouch.UIKit;
using MonoTouch.Foundation;

namespace SimpleMapView
{
	public class SimpleMapDelegate : MKMapViewDelegate
	{
		protected string annotationIdentifier = "BasicAnnotation";

		public override void DidSelectAnnotationView (MKMapView mapView, MKAnnotationView view)
		{
			if (view.Annotation is AdvancedMapAnnotation) {
				var callback = ((AdvancedMapAnnotation)view.Annotation).ClickHandler;
				if (callback != null)
					callback ((AdvancedMapAnnotation)view.Annotation);
			}
		}

		public override MKAnnotationView GetViewForAnnotation (MKMapView mapView, NSObject annotation)
		{
			// todo: check that everything works well here..
			MKAnnotationView annotationView = mapView.DequeueReusableAnnotation(annotationIdentifier);   
			if (annotationView == null)
				annotationView = new MKPinAnnotationView(annotation, annotationIdentifier);
			else
				annotationView.Annotation = annotation;

			// configure our annotation view properties
			annotationView.CanShowCallout = true;
			annotationView.Selected = true;
			//(annotationView as MKPinAnnotationView).AnimatesDrop = true;

			// advanced markers
			if (annotation is AdvancedMapAnnotation) {
				(annotationView as MKPinAnnotationView).PinColor = (MKPinAnnotationColor)((AdvancedMapAnnotation)annotation).PinColor;
				var leftAccessoryView = ((AdvancedMapAnnotation)annotation).LeftCalloutAccessoryView;
				var rightAccessoryView = ((AdvancedMapAnnotation)annotation).RightCalloutAccessoryView;
				var callback = ((AdvancedMapAnnotation)annotation).ClickHandler;
				var markerImage = ((AdvancedMapAnnotation)annotation).MarkerImage;
				if (leftAccessoryView != null)
					annotationView.LeftCalloutAccessoryView = leftAccessoryView;
				if (rightAccessoryView != null)
					annotationView.RightCalloutAccessoryView = rightAccessoryView;
				if (callback != null)
					annotationView.CanShowCallout = false;
				if (markerImage != null) {
					annotationView.Image = markerImage;
					annotationView.Opaque = false;
				}
			}

			return annotationView;
		}

		// as an optimization, you should override this method to add or remove annotations as the
		// map zooms in or out.
		public override void RegionChanged (MKMapView mapView, bool animated)
		{

		}
	}
}

