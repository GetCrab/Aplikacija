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
using Android.Support.V4.App;
using App4.CarViewFragments;

namespace App4
{
    class FragmentAdapter : FragmentPagerAdapter
    {
        private static int NUM_VIEWS = 5;

        public FragmentAdapter(Android.Support.V4.App.FragmentManager fragmentManager) : base(fragmentManager)
        {
        }


        public override int Count
        {
            get
            {
                return NUM_VIEWS;
            }
        }

        public override Android.Support.V4.App.Fragment GetItem(int position)
        {
            switch (position)
            {
                case 0: // Fragment # 0 - This will show FirstFragment
                    return (Android.Support.V4.App.Fragment)CarTopFragment.newInstance();
                case 1: // Fragment # 0 - This will show FirstFragment different title
                    return (Android.Support.V4.App.Fragment)CarRightSideFragment.newInstance();
                case 2: // Fragment # 1 - This will show SecondFragment
                    return (Android.Support.V4.App.Fragment)CarLeftSideFragment.newInstance();
                case 3: // Fragment # 1 - This will show SecondFragment
                    return (Android.Support.V4.App.Fragment)CarFrontFragment.newInstance();
                case 4: // Fragment # 1 - This will show SecondFragment
                    return (Android.Support.V4.App.Fragment)CarBackFragment.newInstance();
                default:
                    return null;
            }
        }
    }
}