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
using Android.Views.InputMethods;
using App4.Resources;

namespace App4
{
    class dialog_Holes : DialogFragment
    {
        private TextView mText1;
        private EditText txtHoleNumber, txtDiameter;

        List<Hole> listHoles;
        CustomAdapter adapter;
        public static EditText hhh;
        int counter = 0;

        List<Hole> holesAfterPause = new List<Hole>();

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);

            var view = inflater.Inflate(Resource.Layout.holesLayout, container, false);

            mText1 = view.FindViewById<TextView>(Resource.Id.title);
            mText1.Text = CarActivity.myString;

            CarActivity.isCancel = true;
            List<string> help = CarActivity.holesQuantity.GetValueOrDefault(CarActivity.btnPressed - 1);

            /*if (savedInstanceState != null)
            {
                help.AddRange(holes);
            }*/
            

            ListView mListView = view.FindViewById<ListView>(Resource.Id.holesListView);

            listHoles = new List<Hole>();

            //ovo je tu radi buga, kad se mijenja iz portrait u landscape
            if(savedInstanceState == null)
            {
                for (counter = 0; counter < (help.Count + 1); counter++)
                {
                    Hole hole;
                    if (counter < help.Count)
                    {
                        hole = new Hole()
                        {
                            Id = counter,
                            HolesQuantity = help[counter],
                            Diameter = CarActivity.diameter.GetValueOrDefault(CarActivity.btnPressed - 1)[counter]
                        };
                    }
                    else
                    {
                        hole = new Hole()
                        {
                            Id = counter,
                            HolesQuantity = "",
                            Diameter = ""
                        };
                    }
                    listHoles.Add(hole);
                }
            }
            else
            {
                string[] holesArray = new string[savedInstanceState.GetStringArray("holesArray").Length];
                string[] diameterArray = new string[savedInstanceState.GetStringArray("diameterArray").Length];

                holesArray = savedInstanceState.GetStringArray("holesArray");
                diameterArray = savedInstanceState.GetStringArray("diameterArray");
                
                int count = holesArray.Length > diameterArray.Length ? holesArray.Length : diameterArray.Length;

                for (counter = 0; counter < count; counter++)
                {
                    Hole hole;
                    hole = new Hole()
                    {
                        Id = counter,
                        HolesQuantity = holesArray[counter],
                        Diameter = diameterArray[counter]
                    };
                    listHoles.Add(hole);
                }
            }            

            View buttonView = inflater.Inflate(Resource.Layout.buttonAtEndListViewLayout, container, false);
            
            buttonView.FindViewById<Button>(Resource.Id.btnSave).Click += MBtn_Click;

            mListView.AddFooterView(buttonView);

            adapter = new CustomAdapter(Activity, listHoles);
            mListView.Adapter = adapter;
            
            Button mBtnAdd = view.FindViewById<Button>(Resource.Id.btnAdd);
            mBtnAdd.Click += delegate {
                listHoles.Add(new Hole() { Id = counter, HolesQuantity = "", Diameter = "" });
                counter++;
                adapter.NotifyDataSetChanged();
            };

            //ovo je tu da makne tipkovnicu ako se pritisne igdje drugo osim na EditText u fragmentu
            //view.SetOnTouchListener(new ViewClickListener(Activity, view.FindViewById<EditText>(Resource.Id.help)));

            return view;
        }

        public override void OnPause()
        {
            //test();
            foreach(Hole hole in listHoles)
                holesAfterPause.Add(hole);
            base.OnPause();
        }

        public override void OnSaveInstanceState(Bundle outState)
        {
            string[] holesArray = new string[listHoles.Count];
            string[] diameterArray = new string[listHoles.Count];
            int i = 0;
            foreach(Hole hole in listHoles)
            {
                holesArray[i] = hole.HolesQuantity;
                diameterArray[i] = hole.Diameter;
                i++;
            }
            outState.PutStringArray("holesArray", holesArray);
            outState.PutStringArray("diameterArray", diameterArray);
            base.OnSaveInstanceState(outState);
        }

        public override void OnResume()
        {
            base.OnResume();
        }

        public override void OnCancel(IDialogInterface dialog)
        {
            InputMethodManager mgr = (InputMethodManager)Activity.GetSystemService(Context.InputMethodService);
            bool mmmm = mgr.IsAcceptingText;
            if(mgr.IsAcceptingText)
                CarActivity.isCancel = true;
            base.OnCancel(dialog);
        }

        

        private void MBtn_Click(object sender, EventArgs e)
        {
            /*if ((txtDiameter.Text != null) && (txtHoleNumber.Text != null) && (txtDiameter.Text != "") && (txtHoleNumber.Text != ""))
            {
                CarActivity.holesQuantity.GetValueOrDefault(CarActivity.btnPressed - 1).Add(txtHoleNumber.Text);
                CarActivity.diameter.GetValueOrDefault(CarActivity.btnPressed - 1).Add(txtDiameter.Text);
                CarActivity.MBtnPrice_Click();
            }else if(((txtDiameter.Text == "") || (txtHoleNumber.Text == "")) &&
                CarActivity.holesQuantity.GetValueOrDefault(CarActivity.btnPressed - 1).Count != 0 &&
                CarActivity.diameter.GetValueOrDefault(CarActivity.btnPressed - 1).Count != 0)
            {
                CarActivity.holesQuantity.GetValueOrDefault(CarActivity.btnPressed - 1).RemoveAt(0);
                CarActivity.diameter.GetValueOrDefault(CarActivity.btnPressed - 1).RemoveAt(0);
                CarActivity.MBtnPrice_Click();
            }*/
            bool help = false;

            CarActivity.holesQuantity.GetValueOrDefault(CarActivity.btnPressed - 1).Clear();
            CarActivity.diameter.GetValueOrDefault(CarActivity.btnPressed - 1).Clear();
            for (int i=0; i < listHoles.Count; i++)
            {
                //View mView = adapter.GetView(i, null, null);
                //EditText txtHoleNumber = mView.FindViewById<EditText>(Resource.Id.holeNumber);
                //EditText txtDiameter = mView.FindViewById<EditText>(Resource.Id.diameter);
                //txtHoleNumber.ClearFocus();
                string holesQuantity = listHoles[i].HolesQuantity;
                string diameter = listHoles[i].Diameter;

                if ((diameter != null) && (holesQuantity != null) && (diameter != "") && (holesQuantity != ""))
                {
                    CarActivity.holesQuantity.GetValueOrDefault(CarActivity.btnPressed - 1).Add(holesQuantity);
                    CarActivity.diameter.GetValueOrDefault(CarActivity.btnPressed - 1).Add(diameter);
                    CarActivity.MBtnPrice_Click();
                    help = true;
                }
                /*else if (((diameter == "") || (holesQuantity == "")) &&
                   CarActivity.holesQuantity.GetValueOrDefault(CarActivity.btnPressed - 1).Count != 0 &&
                   CarActivity.diameter.GetValueOrDefault(CarActivity.btnPressed - 1).Count != 0)
                {
                    CarActivity.holesQuantity.GetValueOrDefault(CarActivity.btnPressed - 1).RemoveAt(0);
                    CarActivity.diameter.GetValueOrDefault(CarActivity.btnPressed - 1).RemoveAt(0);
                    CarActivity.MBtnPrice_Click();
                }*/
            }
            if (help)
            {
                //CarActivity.mImageHoles[CarActivity.btnPressed - 1].Visibility = ViewStates.Visible;
            }
            else
            {
                //CarActivity.mImageHoles[CarActivity.btnPressed - 1].Visibility = ViewStates.Invisible;
            }
            CarActivity.didSomethingChangePreview = true;
            CarActivity.didSomethingChangeData = true;
            //ovo je tu jer je bia bug da kada je tipkovnica ukljucena u fragmentu i pritisne se save, fragment se
            //ugasi ali tipkovnica ostane
            //InputMethodManager mgr = (InputMethodManager)Activity.GetSystemService(Context.InputMethodService);
            //mgr.HideSoftInputFromWindow(txtDiameter.WindowToken, 0);

            Dismiss();
        }               
        
        private void test()
        {
            CarActivity.holesQuantity.GetValueOrDefault(CarActivity.btnPressed - 1).Clear();
            CarActivity.diameter.GetValueOrDefault(CarActivity.btnPressed - 1).Clear();
            for (int i = 0; i < listHoles.Count; i++)
            {
                string holesQuantity = listHoles[i].HolesQuantity;
                string diameter = listHoles[i].Diameter;

                if ((diameter != null) && (holesQuantity != null) && (diameter != "") && (holesQuantity != ""))
                {
                    CarActivity.holesQuantity.GetValueOrDefault(CarActivity.btnPressed - 1).Add(holesQuantity);
                    CarActivity.diameter.GetValueOrDefault(CarActivity.btnPressed - 1).Add(diameter);
                    CarActivity.MBtnPrice_Click();
                }
            }
        }

        public override void OnActivityCreated(Bundle savedInstanceState)
        {
            Dialog.Window.RequestFeature(WindowFeatures.NoTitle);
            base.OnActivityCreated(savedInstanceState);
        }
        
        public override void OnStart()
        {
            //if (CarActivity.holesQuantity.GetValueOrDefault(CarActivity.btnPressed - 1).Count != 0)        
                //txtHoleNumber.SetText(CarActivity.holesQuantity.GetValueOrDefault(CarActivity.btnPressed - 1)[0], TextView.BufferType.Editable);
            //if (CarActivity.diameter.GetValueOrDefault(CarActivity.btnPressed - 1).Count != 0)
                //txtDiameter.SetText(CarActivity.diameter.GetValueOrDefault(CarActivity.btnPressed - 1)[0], TextView.BufferType.Editable);
            base.OnStart();
        }
    }
   
    public class ViewClickListener : Java.Lang.Object, View.IOnTouchListener
    {
        private Context mContext;
        private EditText mEdittext;

        public ViewClickListener(Context context, EditText edittext)
        {
            mEdittext = edittext;
            mContext = context;
        }

        public void OnCancel(IDialogInterface dialog)
        {
        }

        public bool OnTouch(View v, MotionEvent e)
        {
            CarActivity.isCancel = false;
            InputMethodManager imm = (InputMethodManager)mContext.GetSystemService(Context.InputMethodService);
            imm.HideSoftInputFromWindow(mEdittext.WindowToken, 0);
            mEdittext.ClearFocus();
            return true;
        }
    }
}