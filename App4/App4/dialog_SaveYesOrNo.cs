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
    public class dialog_SaveYesOrNo : DialogFragment
    {
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);

            var view = inflater.Inflate(Resource.Layout.SavePopUp, container, false);

            Button mbtnYes = view.FindViewById<Button>(Resource.Id.btnYes);
            Button mbtnNo = view.FindViewById<Button>(Resource.Id.btnNo);

            mbtnYes.Click += Mbtn_Click;
            mbtnNo.Click += Mbtn2_Click;

            return view;
        }

        private void Mbtn_Click(object sender, EventArgs e)
        {
            if ((CarActivity.receiptItems.Count == 0 || CarActivity.carType == "" || CarActivity.chassisNumber == ""))
            {
                Android.App.FragmentTransaction trans = FragmentManager.BeginTransaction();
                dialog_SaveIncomplete saveYesNo = new dialog_SaveIncomplete();
                saveYesNo.Show(trans, "Dialog");
                Dismiss();
            }
            else
            {
                //ovaj help je tu da sacuva kada ude u finnish od CarActivity
                CarActivity.saveInFinish = true;
                Activity.Finish();
                Dismiss();
            }            
        }

        private void Mbtn2_Click(object sender, EventArgs e)
        {
            CarActivity.holesQuantity.Clear();
            CarActivity.diameter.Clear();
            CarActivity.priceString = "0€";
            CarActivity.carType = "";
            CarActivity.chassisNumber = "";
            CarActivity.name = "";
            CarActivity.address = "";
            CarActivity.kilometres = "";
            CarActivity.phone = "";
            for (int n = 0; n < 16; n++)
                CarActivity.App.pictureNames[n] = null;
            CarActivity.App.pictureCounter = 0;
            Intent nextActivity = new Intent(Activity, typeof(MainActivity));
            StartActivity(nextActivity);
            Activity.Finish();
            Dismiss();
        }

        public override void OnActivityCreated(Bundle savedInstanceState)
        {
            Dialog.Window.RequestFeature(WindowFeatures.NoTitle);
            base.OnActivityCreated(savedInstanceState);
        }
    }
}