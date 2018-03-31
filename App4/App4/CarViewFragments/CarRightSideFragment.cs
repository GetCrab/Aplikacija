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
    class CarRightSideFragment : Android.Support.V4.App.Fragment
    {
        private Button mBtn5, mBtn6, mBtn7, mBtn8, mBtn9;

        public CarRightSideFragment() { }

        public static CarRightSideFragment newInstance()
        {
            CarRightSideFragment carRightSideFragment = new CarRightSideFragment();
            return carRightSideFragment;
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);

            var view = inflater.Inflate(Resource.Layout.carRightSideFragmentLayout, container, false);

            mBtn5 = view.FindViewById<Button>(Resource.Id.button5);
            mBtn6 = view.FindViewById<Button>(Resource.Id.button6);
            mBtn7 = view.FindViewById<Button>(Resource.Id.button7);
            mBtn8 = view.FindViewById<Button>(Resource.Id.button8);
            mBtn9 = view.FindViewById<Button>(Resource.Id.button9);
            mBtn5.Click += MBtn5_Click;
            mBtn6.Click += MBtn6_Click;
            mBtn7.Click += MBtn7_Click;
            mBtn8.Click += MBtn8_Click;
            mBtn9.Click += MBtn9_Click;

            ImageView imageView = view.FindViewById<ImageView>(Resource.Id.imageView1);
            return view;
        }

        private void MBtn5_Click(object sender, System.EventArgs e)
        {
            CarActivity.btnPressed = 5;
            FragmentTransaction trans = Activity.FragmentManager.BeginTransaction();
            var titleText = Resources.GetText(Resource.String.roofSparR);
            CarActivity.myString = titleText;
            dialog_Holes dialog_btn = new dialog_Holes();

            dialog_btn.Show(trans, "Dialog");
        }

        private void MBtn6_Click(object sender, System.EventArgs e)
        {
            CarActivity.btnPressed = 6;
            FragmentTransaction trans = Activity.FragmentManager.BeginTransaction();
            var titleText = Resources.GetText(Resource.String.sidePartRearR);
            CarActivity.myString = titleText;
            dialog_Holes dialog_btn = new dialog_Holes();
            dialog_btn.Show(trans, "Dialog");
        }

        private void MBtn7_Click(object sender, System.EventArgs e)
        {
            CarActivity.btnPressed = 7;
            FragmentTransaction trans = Activity.FragmentManager.BeginTransaction();
            var titleText = Resources.GetText(Resource.String.doorRearR);
            CarActivity.myString = titleText;
            dialog_Holes dialog_btn = new dialog_Holes();

            dialog_btn.Show(trans, "Dialog");
        }

        private void MBtn8_Click(object sender, System.EventArgs e)
        {
            CarActivity.btnPressed = 8;
            FragmentTransaction trans = Activity.FragmentManager.BeginTransaction();
            var titleText = Resources.GetText(Resource.String.doorFR);
            CarActivity.myString = titleText;
            dialog_Holes dialog_btn = new dialog_Holes();

            dialog_btn.Show(trans, "Dialog");
        }

        private void MBtn9_Click(object sender, System.EventArgs e)
        {
            CarActivity.btnPressed = 9;
            FragmentTransaction trans = Activity.FragmentManager.BeginTransaction();
            var titleText = Resources.GetText(Resource.String.fenderFR);
            CarActivity.myString = titleText;
            dialog_Holes dialog_btn = new dialog_Holes();

            dialog_btn.Show(trans, "Dialog");
        }
    }
}