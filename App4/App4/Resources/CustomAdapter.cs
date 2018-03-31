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
using Java.Lang;
using Android.Views.InputMethods;

namespace App4.Resources
{
    public class ViewHolder : Java.Lang.Object
    {
        public TextView TxtHolesQuantity { get; set; }
        public EditText HolesQuantity { get; set; }
        public TextView TxtDiameter { get; set; }
        public EditText Diameter { get; set; }
    }

    class CustomAdapter : BaseAdapter
    {
        private Activity activity;
        private List<Hole> holes;

        public CustomAdapter(Activity activity, List<Hole> holes)
        {
            this.activity = activity;
            this.holes = holes;
        }

        public override int Count => holes.Count;

        public override Java.Lang.Object GetItem(int position)
        {
            return null;
        }

        public override long GetItemId(int position)
        {
            return holes[position].Id;
        }

        public override void NotifyDataSetChanged()
        {
            base.NotifyDataSetChanged();
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var view = convertView ?? activity.LayoutInflater.Inflate(Resource.Layout.holesListViewItemLayout, parent, false);
            
            EditText holesQuantity = view.FindViewById<EditText>(Resource.Id.holeNumber);
            var diameter = view.FindViewById<EditText>(Resource.Id.diameter);

            //ovo je tu radi buga
            if(position == 0)
            {
                TextView holes = view.FindViewById<TextView>(Resource.Id.txtHoleNumber);
                holes.Text = activity.GetString(Resource.String.holeNumber);
                TextView diam = view.FindViewById<TextView>(Resource.Id.txtDiameter);
                diam.Text = activity.GetString(Resource.String.diameter);
            }
            //parent.Window.SetSoftInputMode(SoftInput.StateVisible);
            if (position > 0)
            {
                TextView holes = view.FindViewById<TextView>(Resource.Id.txtHoleNumber);
                holes.Text = activity.GetString(Resource.String.holeNumber).Replace(":", "") + "(" + (position + 1).ToString() + "):";
                TextView diameterTxt = view.FindViewById<TextView>(Resource.Id.txtDiameter);
                diameterTxt.Text = activity.GetString(Resource.String.diameter).Replace(":", "") + "(" + (position + 1).ToString() + "):";
            }
            holesQuantity.Text = holes[position].HolesQuantity;
            diameter.Text = holes[position].Diameter;

            /*holesQuantity.FocusChange += (object sender, View.FocusChangeEventArgs e) =>
            {
                holes[position].HolesQuantity = holesQuantity.Text;
            };

    */
            //if (!diameters.Contains(diameter))
            //diameters.Add(diameter);
            diameter.Tag = position;
            holesQuantity.Tag = position;
            diameter.AfterTextChanged += delegate
            {
                int number=0;
                if(Int32.TryParse(diameter.Tag.ToString(),out number))
                    if(diameter.HasFocus)
                        holes[number].Diameter = diameter.Text;
            };
            view.SetOnTouchListener(new ViewClickListener(activity, holesQuantity));
            //diameter.SetTag(position,holders[position]);

            //activity.Window.SetSoftInputMode(SoftInput.AdjustPan);
            //holesQuantity.RequestFocus();
            InputMethodManager imm = (InputMethodManager)activity.GetSystemService(Context.InputMethodService);
            //imm.ToggleSoftInput(0, HideSoftInputFlags.NotAlways);
            
            imm.HideSoftInputFromWindow(holesQuantity.WindowToken, 0);

            holesQuantity.AfterTextChanged += delegate
            {
                int number = 0;
                if (Int32.TryParse(holesQuantity.Tag.ToString(), out number))
                    if (holesQuantity.HasFocus)
                        holes[number].HolesQuantity = holesQuantity.Text;
            };

            /*diameter.FocusChange += (object sender, View.FocusChangeEventArgs e) =>
            {
                holes[position].Diameter = diameter.Text;
            };*/

            return view;
        }
    }
}