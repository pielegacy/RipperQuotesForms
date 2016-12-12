using System;
using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Xamarin.Forms.Platform.Android;

namespace Ripper_Quotes_Forms.Droid
{
	[Activity (Label = "Ripper Quotes", Theme="@style/MainTheme", Icon = "@drawable/Icon", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
	public class MainActivity : FormsAppCompatActivity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			global::Xamarin.Forms.Forms.Init (this, bundle);
            FormsAppCompatActivity.ToolbarResource = Resource.Layout.toolbar;
			LoadApplication (new Ripper_Quotes_Forms.App ());
		}
	}
}

