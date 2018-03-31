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
    class dialog_Delete : DialogFragment
    {
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);

            var view = inflater.Inflate(Resource.Layout.deleteLayout, container, false);

            Button mbtnYes = view.FindViewById<Button>(Resource.Id.btnYes);
            Button mbtnNo = view.FindViewById<Button>(Resource.Id.btnNo);

            mbtnYes.Click += (s, e) =>
            {
                PictureActivity.DeleteImage();

                PictureActivity.pressedYesOnDelete = true;

                PictureActivity.CancelingDeleteMode();

                Dismiss();
            };

            mbtnNo.Click += (s, e) =>
            {
                PictureActivity.pressedYesOnDelete = false;

                PictureActivity.CancelingDeleteMode();

                Dismiss();
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