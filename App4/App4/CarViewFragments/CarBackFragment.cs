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
    class CarBackFragment : Android.Support.V4.App.Fragment
    {
        Button mBtn15;

        public CarBackFragment() { }

        public static CarBackFragment newInstance()
        {
            CarBackFragment carBackFragment = new CarBackFragment();
            return carBackFragment;
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);

            var view = inflater.Inflate(Resource.Layout.carBackFragmentLayout, container, false);
            mBtn15 = view.FindViewById<Button>(Resource.Id.button15);
            mBtn15.Click += MBtn15_Click;
            ImageView imageView = view.FindViewById<ImageView>(Resource.Id.imageView1);
            return view;
        }

        private void MBtn15_Click(object sender, System.EventArgs e)
        {
            CarActivity.btnPressed = 15;
            FragmentTransaction trans = Activity.FragmentManager.BeginTransaction();
            var titleText = Resources.GetText(Resource.String.tailgate);
            CarActivity.myString = titleText;
            dialog_Holes dialog_btn = new dialog_Holes();

            dialog_btn.Show(trans, "Dialog");
        }
    }
}