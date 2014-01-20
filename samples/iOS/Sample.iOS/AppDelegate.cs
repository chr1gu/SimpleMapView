using System;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using SimpleMapView;

namespace Sample.iOS
{
	[Register ("AppDelegate")]
	public partial class AppDelegate : UIApplicationDelegate
	{
		UIWindow window;

		public override bool FinishedLaunching (UIApplication app, NSDictionary options)
		{
			window = new UIWindow (UIScreen.MainScreen.Bounds);
			
			// Customize your SimpleMapView's controller
			var mapViewController = new SimpleMapViewController ();
			mapViewController.Title = "SimpleMapView in Action";

			// set type
			mapViewController.Type = SimpleMapView.MapType.Standard;

			// set region
			mapViewController.ShowRegionWithKilometerRadius (48.857, 2.351, 10);

			// add simple annotation
			mapViewController.AddAnnotation (48.870, 2.351, "Annotation", "with some text");

			// show users location
			mapViewController.ShowsUserLocation = true;

			// add advanced annotation with image
			var advancedAnnotation = new AdvancedMapAnnotation(48.857, 2.370, "Image", "in the left callout accessory view"){
				PinColor = AnnotationPinColor.Green,
				LeftCalloutAccessoryView = new UIImageView(UIImage.FromBundle("Maps.png"))
			};
			mapViewController.AddAdvancedAnnotation (advancedAnnotation);

			// add advanced annotation with disclosure
			var disclosureButton = UIButton.FromType (UIButtonType.DetailDisclosure);
			disclosureButton.TouchUpInside += (s, e) => {
				new UIAlertView("Disclosure alert", "You clicked on a disclosure", null, "OK", null).Show();
			};
			var advancedAnnotation2 = new AdvancedMapAnnotation(48.840, 2.386, "Advanced", "with custom disclosure & callback"){
				PinColor = AnnotationPinColor.Purple,
				RightCalloutAccessoryView = disclosureButton,
			};
			mapViewController.AddAdvancedAnnotation (advancedAnnotation2);

			// marker direct click callback
			var advancedAnnotation3 = new AdvancedMapAnnotation(48.830, 2.340, null, null){
				ClickHandler = (AdvancedMapAnnotation annotation) => {
					new UIAlertView("Annotation alert", "This annotation has a direct action instead of a callout", null, "OK", null).Show();
				}
			};
			mapViewController.AddAdvancedAnnotation (advancedAnnotation3);

			// custom marker image
			var advancedAnnotation4 = new AdvancedMapAnnotation(48.810, 2.320, "Marker with Image", null){
				MarkerImage = UIImage.FromBundle("Marker.png")
			};
			mapViewController.AddAdvancedAnnotation (advancedAnnotation4);

			// set root view controller
			window.RootViewController = new UINavigationController (mapViewController);
			window.MakeKeyAndVisible ();
			return true;
		}
	}
}
