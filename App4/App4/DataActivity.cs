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
using System.Reflection;
using Java.IO;
using Com.Joanzapata.Pdfview;
using Android.Support.V7.App;
using SupportToolbar = Android.Support.V7.Widget.Toolbar;

namespace App4
{
    [Activity(Label = "", Theme = "@style/MyTheme")]
    class DataActivity : ActionBarActivity
    {        
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.dataLayout);

            SupportToolbar mToolBar = FindViewById<SupportToolbar>(Resource.Id.toolbar);
            SetSupportActionBar(mToolBar);
            mToolBar.Title = "";

            PDFView preview = FindViewById<PDFView>(Resource.Id.preview);

            File file = new File(System.IO.Path.Combine(System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "dataPdf.pdf"));
            preview.FromFile(file).Load();

            ImageButton mBtnBack = FindViewById<ImageButton>(Resource.Id.backButton);
            mBtnBack.Click += (s, e) =>
            {
                Finish();
            };
        }

        public override void OnBackPressed()
        {
            Finish();            
        }
    }
}