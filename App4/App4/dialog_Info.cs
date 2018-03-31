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
using App4.Resources;

namespace App4
{
    public class dialog_Info : DialogFragment
    {
        EditText nameEditText, addressEditText, phoneEditText, carTypeEditText, chassisNumberEditText, kilometresEditText;

        string name = "", address = "", phone = "", carType = "", chassisNumber = "", kilometres = "";

        List<Info> listInfo;

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);

            var view = inflater.Inflate(Resource.Layout.infoLayout, container, false);

            Button mbtn = view.FindViewById<Button>(Resource.Id.btnSave);

            ListView mListView = view.FindViewById<ListView>(Resource.Id.infoListView);

            listInfo = new List<Info>();

            string[] infoNames = new string[6] { Activity.Resources.GetString(Resource.String.name), Activity.Resources.GetString(Resource.String.address), Activity.Resources.GetString(Resource.String.phone), Activity.Resources.GetString(Resource.String.type), Activity.Resources.GetString(Resource.String.chassisNumber), Activity.Resources.GetString(Resource.String.kilometres)};
            string[] infoEntered = new string[6] { CarActivity.name, CarActivity.address, CarActivity.phone, CarActivity.carType, CarActivity.chassisNumber, CarActivity.kilometres};

            for (int i = 0; i < 6; i++)
            {
                Info info;
                    info = new Info()
                    {
                        Id = i,
                        Text = infoNames[i],
                        EnteredText = infoEntered[i]
                    };
                

                listInfo.Add(info);
            }

            View buttonView = inflater.Inflate(Resource.Layout.buttonAtEndListViewLayout, container, false);

            buttonView.FindViewById<Button>(Resource.Id.btnSave).Click += MBtn_Click;

            mListView.AddFooterView(buttonView);

            CustomInfoAdapter adapter = new CustomInfoAdapter(Activity, listInfo);
            mListView.Adapter = adapter;

            /*nameEditText = view.FindViewById<EditText>(Resource.Id.name);
            addressEditText = view.FindViewById<EditText>(Resource.Id.address);
            phoneEditText = view.FindViewById<EditText>(Resource.Id.phone);
            carTypeEditText = view.FindViewById<EditText>(Resource.Id.type);
            chassisNumberEditText = view.FindViewById<EditText>(Resource.Id.chassisNumber);
            kilometresEditText = view.FindViewById<EditText>(Resource.Id.kilometres);

            if (savedInstanceState != null)
            {
                nameEditText.SetText(savedInstanceState.GetString("name"), TextView.BufferType.Editable);
                addressEditText.SetText(savedInstanceState.GetString("address"), TextView.BufferType.Editable);
                phoneEditText.SetText(savedInstanceState.GetString("phone"), TextView.BufferType.Editable);
                carTypeEditText.SetText(savedInstanceState.GetString("carType"), TextView.BufferType.Editable);
                chassisNumberEditText.SetText(savedInstanceState.GetString("chassisNumber"), TextView.BufferType.Editable);
                kilometresEditText.SetText(savedInstanceState.GetString("kilometres"), TextView.BufferType.Editable);
            }
            else
            {
                nameEditText.SetText(CarActivity.name, TextView.BufferType.Editable);
                addressEditText.SetText(CarActivity.address, TextView.BufferType.Editable);
                phoneEditText.SetText(CarActivity.phone, TextView.BufferType.Editable);
                carTypeEditText.SetText(CarActivity.carType, TextView.BufferType.Editable);
                chassisNumberEditText.SetText(CarActivity.chassisNumber, TextView.BufferType.Editable);
                kilometresEditText.SetText(CarActivity.kilometres, TextView.BufferType.Editable);
            }

            mbtn.Click += (s, e) =>
            {
                CarActivity.carType = carTypeEditText.Text;
                CarActivity.name = nameEditText.Text;
                CarActivity.address = addressEditText.Text;
                CarActivity.phone = phoneEditText.Text;
                CarActivity.chassisNumber = chassisNumberEditText.Text;
                CarActivity.kilometres = kilometresEditText.Text;
                Dismiss();
            };

            //da se vrati tekst na pocetak ako je predug
            nameEditText.FocusChange += (object sender, View.FocusChangeEventArgs e) =>
            {
                nameEditText.SetSelection(0);
            };
            
            addressEditText.FocusChange += (object sender, View.FocusChangeEventArgs e) =>
            {
                addressEditText.SetSelection(0);
            };

            kilometresEditText.FocusChange += (object sender, View.FocusChangeEventArgs e) =>
            {
                kilometresEditText.SetSelection(0);
            };

            chassisNumberEditText.FocusChange += (object sender, View.FocusChangeEventArgs e) =>
            {
                chassisNumberEditText.SetSelection(0);
            };

            phoneEditText.FocusChange += (object sender, View.FocusChangeEventArgs e) =>
            {
                phoneEditText.SetSelection(0);
            };

            carTypeEditText.FocusChange += (object sender, View.FocusChangeEventArgs e) =>
            {
                carTypeEditText.SetSelection(0);
            };

            nameEditText.FocusChange += (object sender, View.FocusChangeEventArgs e) =>
            {
                nameEditText.SetSelection(0);
            };

            carTypeEditText.FocusChange += (object sender, View.FocusChangeEventArgs e) =>
            {
                carTypeEditText.SetSelection(0);
            };

            kilometresEditText.FocusChange += (object sender, View.FocusChangeEventArgs e) =>
            {
                kilometresEditText.SetSelection(0);
            };

            phoneEditText.FocusChange += (object sender, View.FocusChangeEventArgs e) =>
            {
                phoneEditText.SetSelection(0);
            };

            addressEditText.FocusChange += (object sender, View.FocusChangeEventArgs e) =>
            {
                addressEditText.SetSelection(0);
            };

            chassisNumberEditText.FocusChange += (object sender, View.FocusChangeEventArgs e) =>
            {
                chassisNumberEditText.SetSelection(0);
            };*/

            //view.SetOnTouchListener(new ViewClickListener(Activity, nameEditText));

            return view;
        }

        private void MBtn_Click(object sender, EventArgs e)
        {
            CarActivity.name = listInfo[0].EnteredText;
            CarActivity.address = listInfo[1].EnteredText;
            CarActivity.phone = listInfo[2].EnteredText;
            CarActivity.carType = listInfo[3].EnteredText;
            CarActivity.chassisNumber = listInfo[4].EnteredText;
            CarActivity.kilometres = listInfo[5].EnteredText;
            CarActivity.didSomethingChangePreview = true;
            CarActivity.didSomethingChangeData = true;
            Dismiss();
        }

        //ovo je tu radi buga kad bi se tabbalo izvan aplikacije i onda vratilo u aplikaciju
        //i kada se mijenja iz portrait-a u landscape
        public override void OnSaveInstanceState(Bundle outState)
        {
            /*outState.PutString("name" , nameEditText.Text);
            outState.PutString("address" , addressEditText.Text);
            outState.PutString("phone" , phoneEditText.Text);
            outState.PutString("chassisNumber" , chassisNumberEditText.Text);
            outState.PutString("kilometres" , kilometresEditText.Text);
            outState.PutString("carType" , carTypeEditText.Text);*/
            base.OnSaveInstanceState(outState);
        }

        public override void OnActivityCreated(Bundle savedInstanceState)
        {
            //Dialog.Window.SetSoftInputMode(SoftInput.StateVisible);
            Dialog.Window.RequestFeature(WindowFeatures.NoTitle);
            base.OnActivityCreated(savedInstanceState);
        }

        public override void OnStart()
        {
            base.OnStart();
        }
    }
}