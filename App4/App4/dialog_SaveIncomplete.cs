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
    public class dialog_SaveIncomplete : DialogFragment
    {
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);

            var view = inflater.Inflate(Resource.Layout.saveIncompleteLayout, container, false);
            
            Button mbtn = view.FindViewById<Button>(Resource.Id.btnYes);
            Button mbtn2 = view.FindViewById<Button>(Resource.Id.btnNo);

            mbtn.Click += (s, e) =>
            {
                CarActivity.saveInFinish = true;
                Activity.Finish();
                Dismiss();
            };

            mbtn2.Click += (s, e) =>
            {
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