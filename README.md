# SimpleMapView

SimpleMapView is a Xamarin component written in C#. Currently it works only with Xamarin.iOS. The goal of SimpleMapView is to interact with Maps in an even easier way without having to know the MapKit framework.

### Usage
The simplest example of using SimpleMapView looks something like this:

```csharp  
using SimpleMapView;

// in your AppDelegate.cs
window = new UIWindow (UIScreen.MainScreen.Bounds);

var mapViewController = new SimpleMapViewController ();
mapViewController.Title = "Paris";
mapViewController.ShowRegion (48.857, 2.351);
window.RootViewController = new UINavigationController (mapViewController);
```

###Features
- Xamarin.iOS
- Simplified Api - only a few lines of code
- Specify display region
- Specify map type
- Add multiple markers
- Simple marker overlay
- Change map type
- Displays current location
- Add custom marker images
- Marker callback functions

###Upcomming Features
- Add custom overlay
- Hide/show markers if region changes
- Search with http://maps.googleapis.com/maps/api/geocode/json?address=Bern&sensor=false
- Android Support

###Samples
Samples for implementing SimpleMapView can be found in the /*sample*/ folder.

###License
TBD
