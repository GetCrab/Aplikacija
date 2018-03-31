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

namespace App4.Resources
{
    public class ViewHolderInfo : Java.Lang.Object
    {
        public TextView TxtName { get; set; }
        public TextView TxtPrice { get; set; }
    }

    class CustomInfoAdapter : BaseAdapter
    {
        private Activity activity;
        private List<Info> info;

        public CustomInfoAdapter(Activity activity, List<Info> info)
        {
            this.activity = activity;
            this.info = info;
        }

        public override int Count => info.Count;

        public override Java.Lang.Object GetItem(int position)
        {
            return null;
        }

        public override long GetItemId(int position)
        {
            return info[position].Id;
        }

        public override void NotifyDataSetChanged()
        {
            base.NotifyDataSetChanged();
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var view = convertView ?? activity.LayoutInflater.Inflate(Resource.Layout.infoListViewLayout, parent, false);

            TextView txtField = view.FindViewById<TextView>(Resource.Id.txtField);
            EditText editTxtField = view.FindViewById<EditText>(Resource.Id.editTxtField);

            txtField.Text = info[position].Text;
            editTxtField.Text = info[position].EnteredText;

            switch (position)
            {
                case 0:
                    editTxtField.InputType = Android.Text.InputTypes.TextFlagCapWords | Android.Text.InputTypes.TextFlagNoSuggestions;
                    break;
                case 1:
                    editTxtField.InputType = Android.Text.InputTypes.TextFlagCapWords | Android.Text.InputTypes.TextFlagNoSuggestions;
                    break;
                case 2:
                    editTxtField.InputType = Android.Text.InputTypes.ClassNumber | Android.Text.InputTypes.TextFlagNoSuggestions;
                    break;
                case 3:
                    editTxtField.InputType = Android.Text.InputTypes.TextFlagCapWords | Android.Text.InputTypes.TextFlagNoSuggestions;
                    break;
                case 4:
                    editTxtField.InputType = Android.Text.InputTypes.ClassNumber | Android.Text.InputTypes.TextFlagNoSuggestions;
                    break;
                case 5:
                    editTxtField.InputType = Android.Text.InputTypes.ClassNumber | Android.Text.InputTypes.TextFlagNoSuggestions;
                    break;
            }

            view.SetOnTouchListener(new ViewClickListener(activity, editTxtField));

            editTxtField.Tag = position;
            editTxtField.AfterTextChanged += delegate
            {
                int number = 0;
                if (Int32.TryParse(editTxtField.Tag.ToString(), out number))
                    if (editTxtField.HasFocus)
                        info[number].EnteredText = editTxtField.Text;
            };

            return view;
        }
    }
}