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
using Android.Graphics;

namespace App4
{
    public class dialog_Picture : DialogFragment
    {
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);

            var view = inflater.Inflate(Resource.Layout.pictureDialogLayout, container, false);
            
            ImageView imageView = view.FindViewById<ImageView>(Resource.Id.imageView1);

            int i = PictureActivity.currentButton;

            if (i < 0)
                return view;
            int h, r;
            bool isInLandscape = false;
            if (Resources.DisplayMetrics.WidthPixels > Resources.DisplayMetrics.HeightPixels)
                isInLandscape = true;

            int dp = (int)Math.Round(Resources.DisplayMetrics.WidthPixels / (Resources.DisplayMetrics.Ydpi / 160));
            int imageHelpWidth = 0;
            int imageHelpHeight = 0;
                if (isInLandscape)
                {
                    imageHelpWidth = Resources.DisplayMetrics.HeightPixels;
                    imageHelpHeight = Resources.DisplayMetrics.WidthPixels;
                }
                else
                {
                    imageHelpWidth = Resources.DisplayMetrics.WidthPixels;
                    imageHelpHeight = Resources.DisplayMetrics.HeightPixels;
                }
            
            

            //if (CarActivity.App.bitmap[i] != null)
            //{
                //Bitmap d = CarActivity.App.bitmap[i];
                Java.IO.File file = new Java.IO.File(CarActivity.App._dir, CarActivity.App.pictureNames[i]);
                Bitmap bitmap = file.Path.LoadAndResizeBitmap(Resources.DisplayMetrics.WidthPixels, Resources.DisplayMetrics.HeightPixels);
                if (CarActivity.landscapePictures.Contains(i))// && isInLandscape
                {
                    if (!isInLandscape)
                        r = Convert.ToInt32(imageHelpHeight / 3);
                    else
                        r = Convert.ToInt32(imageHelpHeight);
                    h = Convert.ToInt32(imageHelpWidth / 1.05);

                    if (isInLandscape)
                    {
                        int help = r;
                        r = h;
                        h = help;
                    }
                    var metrics = Resources.DisplayMetrics;
                    Matrix mtx = new Matrix();
                    //mtx.PostRotate(270);
                    
                    if(metrics.WidthPixels < metrics.HeightPixels)
                    {
                        mtx.PostRotate(0);
                    }
                    else
                    {
                        mtx.PostRotate(270);
                    }
                    Bitmap resizedBitmap = Bitmap.CreateBitmap(bitmap, 0, 0, bitmap.Width, bitmap.Height, mtx, false);
                    imageView.SetImageBitmap(Bitmap.CreateScaledBitmap(resizedBitmap, h, r, false));
                    mtx.Dispose();
                    mtx = null;
                resizedBitmap = null;
                }
                else
                {
                    h = Convert.ToInt32(imageHelpWidth / 1.1);
                    r = Convert.ToInt32(imageHelpHeight * 1.05);
                var metrics = Resources.DisplayMetrics;
                Matrix mtx = new Matrix();
                //mtx.PostRotate(270);

                if (metrics.WidthPixels < metrics.HeightPixels)
                {
                    mtx.PostRotate(0);
                }
                else
                {
                    mtx.PostRotate(270);
                }
                Bitmap resizedBitmap = Bitmap.CreateBitmap(bitmap, 0, 0, bitmap.Width, bitmap.Height, mtx, false);
                imageView.SetImageBitmap(Bitmap.CreateScaledBitmap(resizedBitmap, h, r, false));
                mtx.Dispose();
                mtx = null;
                resizedBitmap = null;
            }
            
            //}
            GC.Collect();
            return view;
        }
        
        public override void OnActivityCreated(Bundle savedInstanceState)
        {
            Dialog.Window.RequestFeature(WindowFeatures.NoTitle);
            base.OnActivityCreated(savedInstanceState);
        }        
    }
}