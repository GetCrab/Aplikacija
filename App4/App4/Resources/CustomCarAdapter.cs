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
    public class ViewHolderCar : Java.Lang.Object
    {
        public TextView TxtName { get; set; }
        public TextView TxtPrice { get; set; }
    }

    class CustomCarAdapter : BaseAdapter
    {
        private Activity activity;
        private List<Car> cars;

        public CustomCarAdapter(Activity activity, List<Car> cars)
        {
            this.activity = activity;
            this.cars = cars;
        }

        public override int Count => cars.Count;

        public override Java.Lang.Object GetItem(int position)
        {
            return null;
        }

        public override long GetItemId(int position)
        {
            return cars[position].Id;
        }

        public override void NotifyDataSetChanged()
        {
            base.NotifyDataSetChanged();
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var view = convertView ?? activity.LayoutInflater.Inflate(Resource.Layout.carCardListViewLayout, parent, false);

            TextView name = view.FindViewById<TextView>(Resource.Id.txtName);
            TextView price = view.FindViewById<TextView>(Resource.Id.txtPrice);

            name.Text = cars[position].Name;
            price.Text = cars[position].Price;

            return view;
        }
    }
}