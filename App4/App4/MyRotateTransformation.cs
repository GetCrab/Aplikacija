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
using FFImageLoading.Work;
using Android.Media;

namespace App4
{
    public class MyRotateTransformation : ITransformation
    {
        public string Key { get; }

        public IBitmap Transform(IBitmap bitmapHolder, string path, ImageSource source, bool isPlaceholder, string key)
        {
            var sourceBitmap = bitmapHolder.ToNative();
            return new BitmapHolder(Transform(sourceBitmap, path, source, isPlaceholder, key));
        }

        protected virtual Bitmap Transform(Bitmap sourceBitmap, string path, ImageSource source, bool isPlaceholder, string key)
        {
            ExifInterface exif = new ExifInterface(path);
            string orientation = exif.GetAttribute(ExifInterface.TagOrientation);
            
            Matrix mtx = new Matrix();
            mtx.PreRotate(90);
            sourceBitmap = Bitmap.CreateBitmap(sourceBitmap, 0, 0, sourceBitmap.Width, sourceBitmap.Height, mtx, false);
            mtx.Dispose();
            mtx = null;
                        
            return sourceBitmap;
        }
    }
}