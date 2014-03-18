using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace Hello_Android
{
	[Activity (Label = "Hello_Android", MainLauncher = true)]
	public class MainActivity : Activity
	{
		//int count = 1;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			//Create the user interface in code
			var layout = new LinearLayout (this);
			layout.Orientation = Orientation.Vertical;

			var aLabel = new TextView (this);
			aLabel.Text = "Hello, Xamarin.Android";

			var aButton = new Button (this);
			aButton.Text = "Say Hello";
			aButton.Click += (sender, e) => {
				string endPoint = @"http://openlibrary.org/authors/OL1A.json?=history";
				var client = new APIConnection (endPoint);
				var json = client.MakeRequest ();
				aLabel.Text = json;
			};
			layout.AddView (aLabel);
			layout.AddView (aButton);
			SetContentView (layout);
		}
			
	}
}


