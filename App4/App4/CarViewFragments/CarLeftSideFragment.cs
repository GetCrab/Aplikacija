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
    class CarLeftSideFragment : Android.Support.V4.App.Fragment
    {
        private Button mBtn10, mBtn11, mBtn12, mBtn13, mBtn14;

        public CarLeftSideFragment() { }

        public static CarLeftSideFragment newInstance()
        {
            CarLeftSideFragment carLeftSideFragment = new CarLeftSideFragment();
            return carLeftSideFragment;
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);

            var view = inflater.Inflate(Resource.Layout.carLeftSideFragmentLayout, container, false);

            mBtn10 = view.FindViewById<Button>(Resource.Id.button10);
            mBtn11 = view.FindViewById<Button>(Resource.Id.button11);
            mBtn12 = view.FindViewById<Button>(Resource.Id.button12);
            mBtn13 = view.FindViewById<Button>(Resource.Id.button13);
            mBtn14 = view.FindViewById<Button>(Resource.Id.button14);
            mBtn10.Click += MBtn10_Click;
            mBtn11.Click += MBtn11_Click;
            mBtn12.Click += MBtn12_Click;
            mBtn13.Click += MBtn13_Click;
            mBtn14.Click += MBtn14_Click;

            ImageView imageView = view.FindViewById<ImageView>(Resource.Id.imageView1);
            return view;
        }
    
        private void MBtn10_Click(object sender, System.EventArgs e)
        {
            CarActivity.btnPressed = 10;
            FragmentTransaction trans = Activity.FragmentManager.BeginTransaction();
            var titleText = Resources.GetText(Resource.String.roofSparL);
            CarActivity.myString = titleText;
            dialog_Holes dialog_btn = new dialog_Holes();

            dialog_btn.Show(trans, "Dialog");
        }

        private void MBtn11_Click(object sender, System.EventArgs e)
        {
            CarActivity.btnPressed = 11;
            FragmentTransaction trans = Activity.FragmentManager.BeginTransaction();
            var titleText = Resources.GetText(Resource.String.fenderFL);
            CarActivity.myString = titleText;
            dialog_Holes dialog_btn = new dialog_Holes();
            dialog_btn.Show(trans, "Dialog");
        }

        private void MBtn12_Click(object sender, System.EventArgs e)
        {
            CarActivity.btnPressed = 12;
            FragmentTransaction trans = Activity.FragmentManager.BeginTransaction();
            var titleText = Resources.GetText(Resource.String.doorFL);
            CarActivity.myString = titleText;
            dialog_Holes dialog_btn = new dialog_Holes();

            dialog_btn.Show(trans, "Dialog");
        }

        private void MBtn13_Click(object sender, System.EventArgs e)
        {
            CarActivity.btnPressed = 13;
            FragmentTransaction trans = Activity.FragmentManager.BeginTransaction();
            var titleText = Resources.GetText(Resource.String.doorRearL);
            CarActivity.myString = titleText;
            dialog_Holes dialog_btn = new dialog_Holes();

            dialog_btn.Show(trans, "Dialog");
        }

        private void MBtn14_Click(object sender, System.EventArgs e)
        {
            CarActivity.btnPressed = 14;
            FragmentTransaction trans = Activity.FragmentManager.BeginTransaction();
            var titleText = Resources.GetText(Resource.String.sidePartRearL);
            CarActivity.myString = titleText;
            dialog_Holes dialog_btn = new dialog_Holes();

            dialog_btn.Show(trans, "Dialog");
        }
    }
}