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
using FlexCel.Core;
using FlexCel.XlsAdapter;

namespace App4.CarViewFragments
{
    class CarTopFragment : Android.Support.V4.App.Fragment
    {
        Button mBtn1, mBtn2, mBtn3, mBtn4;
        public CarTopFragment() { }

        public static CarTopFragment newInstance()
        {
            CarTopFragment carTopFragment = new CarTopFragment();
            return carTopFragment;
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);

            var view = inflater.Inflate(Resource.Layout.carTopFragmentLayout, container, false);

            mBtn1 = view.FindViewById<Button>(Resource.Id.button1);
            mBtn2 = view.FindViewById<Button>(Resource.Id.button2);
            mBtn3 = view.FindViewById<Button>(Resource.Id.button3);
            mBtn4 = view.FindViewById<Button>(Resource.Id.button4);
            mBtn1.Click += MBtn1_Click;
            mBtn2.Click += MBtn2_Click;
            mBtn3.Click += MBtn3_Click;
            mBtn4.Click += MBtn4_Click;

            ImageView imageView = view.FindViewById<ImageView>(Resource.Id.imageView1);
            return view;
        }

        private void MBtn1_Click(object sender, System.EventArgs e)
        {
            CarActivity.btnPressed = 1;
            FragmentTransaction trans = Activity.FragmentManager.BeginTransaction();
            var titleText = Resources.GetText(Resource.String.rearFlapAbove);
            CarActivity.myString = titleText;
            dialog_Holes dialog_btn = new dialog_Holes();

            dialog_btn.Show(trans, "Dialog");
        }

        private void MBtn2_Click(object sender, System.EventArgs e)
        {
            CarActivity.btnPressed = 2;
            FragmentTransaction trans = Activity.FragmentManager.BeginTransaction();
            var titleText = Resources.GetText(Resource.String.roof);
            CarActivity.myString = titleText;
            dialog_Holes dialog_btn = new dialog_Holes();
            dialog_btn.Show(trans, "Dialog");
        }

        private void MBtn3_Click(object sender, System.EventArgs e)
        {
            CarActivity.btnPressed = 3;
            FragmentTransaction trans = Activity.FragmentManager.BeginTransaction();
            var titleText = Resources.GetText(Resource.String.sunroof);
            CarActivity.myString = titleText;
            dialog_Holes dialog_btn = new dialog_Holes();

            /*XlsFile xls = new XlsFile(System.IO.Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "TestExcel.xls"));

            int XF = -1;
            object cell = xls.GetCellValueIndexed(3, 1, ref XF);*/

            dialog_btn.Show(trans, "Dialog");
        }

        private void MBtn4_Click(object sender, System.EventArgs e)
        {
            CarActivity.btnPressed = 4;
            FragmentTransaction trans = Activity.FragmentManager.BeginTransaction();
            var titleText = Resources.GetText(Resource.String.hood);
            CarActivity.myString = titleText;
            dialog_Holes dialog_btn = new dialog_Holes();
            /*string sss = System.IO.Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "ExcelFiles/TestExcel.xls");
            XlsFile xls = new XlsFile(System.IO.Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "test.xls"));
            xls.ActiveSheetByName = "Sheet1";
            xls.SetCellValue(3, 1, 11.3);

            xls.Save(System.IO.Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "TestExcel.xls"));
            */
           /* XlsFile xls = new XlsFile(true);
            string asda = System.IO.Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "bin/Debug/test2.xls");
            xls.Open(System.IO.Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "Book.xlsx"));            */
            dialog_btn.Show(trans, "Dialog");
        }
    }
}