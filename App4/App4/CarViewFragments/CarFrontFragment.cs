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

namespace App4.CarViewFragments
{
    class CarFrontFragment : Android.Support.V4.App.Fragment
    {
        public CarFrontFragment() { }

        public static CarFrontFragment newInstance()
        {
            CarFrontFragment carFrontFragment = new CarFrontFragment();
            return carFrontFragment;
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);

            var view = inflater.Inflate(Resource.Layout.carFrontFragmentLayout, container, false);
            ImageView imageView = view.FindViewById<ImageView>(Resource.Id.imageView1);
            return view;
        }
    }
}