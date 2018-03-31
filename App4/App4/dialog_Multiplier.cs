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
    public class dialog_Multiplier : DialogFragment
    {
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);

            var view = inflater.Inflate(Resource.Layout.multiplierLayout, container, false);

            Button mbtn = view.FindViewById<Button>(Resource.Id.btnSave);
            EditText mEditText = view.FindViewById<EditText>(Resource.Id.multiplier);
            Dialog.Window.SetSoftInputMode(SoftInput.StateVisible);

            ISharedPreferences prefBefore = Application.Context.GetSharedPreferences("MultiplierInfo", FileCreationMode.Private);
            mEditText.Text = prefBefore.GetInt("Multiplier", 7).ToString();
            mEditText.SetSelection(mEditText.Text.Length);

            mbtn.Click += (s, e) =>
            {
                int multiplier;
                ISharedPreferences pref = Application.Context.GetSharedPreferences("MultiplierInfo", FileCreationMode.Private);
                ISharedPreferencesEditor edit = pref.Edit();     
                if (Int32.TryParse(mEditText.Text, out multiplier))
                    edit.PutInt("Multiplier", multiplier);
                else
                    edit.PutInt("Multiplier", 7);
                edit.Apply();

                CarActivity.multiplier = pref.GetInt("Multiplier", 7);
                CarActivity.didSomethingChangePreview = true;
                CarActivity.didSomethingChangeData = true;
                CarActivity.MBtnPrice_Click();                
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