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
using Com.Joanzapata.Pdfview;
using System.Reflection;
using Java.IO;

namespace App4
{
    public class dialog_Preview : DialogFragment
    {
        PDFView preview;

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);

            var view = inflater.Inflate(Resource.Layout.previewLayout, container, false);

            preview = view.FindViewById<PDFView>(Resource.Id.preview);
            preview.LayoutParameters.Height = Convert.ToInt32(Resources.DisplayMetrics.HeightPixels / 1.43);

            File file = new File(System.IO.Path.Combine(System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "BSTReceiptPdf.pdf"));
            preview.FromFile(file).Load();

            return view;
        }

        public override void OnActivityCreated(Bundle savedInstanceState)
        {
            Dialog.Window.RequestFeature(WindowFeatures.NoTitle);
            base.OnActivityCreated(savedInstanceState);
        }
    }
}