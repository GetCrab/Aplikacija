using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content;
using SupportToolbar = Android.Support.V7.Widget.Toolbar;
using Android.Support.V4.Widget;
using Android.Support.V7.App;
using Android.Views;
using System;
using AT.Markushi.UI;
using System.Collections.Generic;
using App4.Resources;

namespace App4
{
    [Activity(Label = "BST", MainLauncher = true, Theme = "@style/MyTheme")]
    public class MainActivity : ActionBarActivity
    {
        private SupportToolbar mToolBar;
        private MyActionBarDrawerToggle mDrawerToggle;
        private DrawerLayout mDrawerLayout;
        private ListView mLeftDrawer;
        EditText mEditText;
        List<Car> listCars;

        private const int maxNumberOfSavedCars = 20;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            mToolBar = FindViewById<SupportToolbar>(Resource.Id.toolbar);
            mDrawerLayout = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
            mLeftDrawer = FindViewById<ListView>(Resource.Id.left_drawer);
            SetSupportActionBar(mToolBar);

            /*mDrawerToggle = new MyActionBarDrawerToggle(
                this,
                mDrawerLayout,
                Resource.String.openDrawer,
                Resource.String.closeDrawer);

            mDrawerLayout.SetDrawerListener(mDrawerToggle);
            SupportActionBar.SetHomeButtonEnabled(true);
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            SupportActionBar.SetDisplayShowTitleEnabled(true);
            mDrawerToggle.SyncState();*/

            CircleButton mbtn = FindViewById<CircleButton>(Resource.Id.btnNew);

            mEditText = FindViewById<EditText>(Resource.Id.myEditText);

            mbtn.Click += (s, e) =>
            {
                Intent nextActivity = new Intent(this, typeof(CarActivity));
                nextActivity.PutExtra("ListViewClick", "-1");
                StartActivity(nextActivity);
                Finish();
            };

            string[] carNames = new string[maxNumberOfSavedCars];
            string[] carPrices = new string[maxNumberOfSavedCars];

            ISharedPreferences pref = Application.Context.GetSharedPreferences("Cars", FileCreationMode.Private);
            for(int i = 0; i < maxNumberOfSavedCars; i++)
            {
                carNames[i] = pref.GetString("CarName" + i.ToString(), "Not found");
            }

            for (int i = 0; i < maxNumberOfSavedCars; i++)
            {
                carPrices[i] = pref.GetString("CarPrice" + i.ToString(), "Not found");
            }

            ListView mListView = FindViewById<ListView>(Resource.Id.listOfCars);

            bool isListFull = pref.GetBoolean("IsListFull", false);
            int positionCurrentCar = pref.GetInt("NumberOfCars",0);

            listCars = new List<Car>();
            List<Car> listOfNewerCars = new List<Car>();

            for (int i = 0; i < maxNumberOfSavedCars; i++)
            {
                Car car;
                if (!carNames[i].Equals("Not found"))
                {
                    car = new Car()
                    {
                        Id = i,
                        Name = carNames[i],
                        Price = carPrices[i]
                    };
                }
                else
                {
                    break;
                }
                if (isListFull && i < positionCurrentCar)
                    listOfNewerCars.Add(car);
                else
                    listCars.Insert(0, car);
            }

            if (isListFull)
                foreach (Car car in listOfNewerCars)
                    listCars.Insert(0, car);                

            CustomCarAdapter adapter = new CustomCarAdapter(this, listCars);
            mListView.Adapter = adapter;

            mListView.ItemClick += (s, e) =>
            {
                StartingActivity(e.Position.ToString());                
            };
        }

        private void StartingActivity(string listViewPosition)
        {
            int listViewPositionInt = Int32.Parse(listViewPosition);
            Intent activity = new Intent(this, typeof(CarActivity));
            activity.PutExtra("ListViewPosition", listViewPosition);
            activity.PutExtra("CarName", listCars[listViewPositionInt].Name);
            activity.PutExtra("CarPrice", listCars[listViewPositionInt].Price);
            StartActivity(activity);
            Finish();
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            mDrawerToggle.OnOptionsItemSelected(item);
            return base.OnOptionsItemSelected(item);
        }
        
        public override void OnBackPressed()
        {
            Finish();
        }        
    }
}

