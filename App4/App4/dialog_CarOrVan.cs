using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace App4
{
    public class dialog_CarOrVan : DialogFragment
    {
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);

            var view = inflater.Inflate(Resource.Layout.CarOrVanLayout, container, false);

            Button mbtn = view.FindViewById<Button>(Resource.Id.btnCar);
            Button mbtn2 = view.FindViewById<Button>(Resource.Id.btnVan);

            mbtn.Click += (s, e) =>
            {
                Intent nextActivity = new Intent(Activity, typeof(CarActivity));
                StartActivity(nextActivity);
                Activity.Finish();
                Dismiss();
            };

            mbtn2.Click += (s, e) =>
            {
                //Intent nextActivity = new Intent(this, typeof(CarActivity));
                //StartActivity(nextActivity);
            };
            return view;
        }

        public override void OnActivityCreated(Bundle savedInstanceState)
        {
            Dialog.Window.RequestFeature(WindowFeatures.NoTitle);
            base.OnActivityCreated(savedInstanceState);
        }
    }
}