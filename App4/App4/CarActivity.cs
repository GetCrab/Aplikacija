using System;
using System.Collections.Generic;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using Java.IO;
using Android.Graphics;
using Android.Provider;
using Android.Content.PM;
using System.Linq;
using Android.Support.V4.View;

using Android.Support.V7.App;
using Android.Views;
using Android.Views.InputMethods;
using Android.Support.Design.Widget;
using SupportToolbar = Android.Support.V7.Widget.Toolbar;
using Android.Support.V4.Widget;
using Android.Support.V4.App;
using Android.Content.Res;
using System.IO;
using FlexCel.Core;
using FlexCel.XlsAdapter;
using System.Reflection;
using System.Threading.Tasks;
using System.Threading;
using AnimatedLoadingViews;
using Android.Util;
using Android.Media;

namespace App4
{
    //,WindowSoftInputMode = SoftInput.StateVisible
    [Activity(Label = "", Theme ="@style/MyTheme")]
    public class CarActivity : ActionBarActivity
    {
        private const int maxNumberOfSavedCars = 20;

        public static class App
        {
            public static Java.IO.File _file;
            public static Java.IO.File _dir;
            public static Bitmap bitmap;
            public static Bitmap[] bitmap2 = new Bitmap[50];
            public static string[] pictureNames = new string[17];
            public static int pictureCounter = 0;
            public static int numberOfSavedPictures = 0;
            public static string[] allSavedPictures = new string[17];
        }

        private bool wait = false;

        FragmentPagerAdapter adapter;

        public static string carType = "", chassisNumber="", name="", address="", phone="", kilometres="";

        private static int counter = 0;

        public static bool didSomethingChangePreview = true;
        public static bool didSomethingChangeData = true;

        public static bool saveInFinish = false;

        private bool editingSaved = false;
        private string positionOfSaved = "0";
        public static bool isCancel = false;

        private Button mBtnInfo, mBtnPicture;
        private ImageButton mBtnBack;
        public static int btnPressed = 0;
        public static string myString;

        public static int numberOfDeletedPictures = 0;
        public static List<int> allDeletedPictures = new List<int>();
        public static List<int> landscapePictures = new List<int>();
        
        private static TextView mTxtViewPrice;
        //private ViewPager pager;

        public static string priceString = "0€";

        public static Dictionary<int, List<String>> holesQuantity = new Dictionary<int, List<string>>();
        public static Dictionary<int, List<String>> diameter = new Dictionary<int, List<string>>();

        public static int multiplier = 7;
        public static int savedMultiplier = 0;

        private SupportToolbar mToolBar;

        public static EditText mEditText;
        private ProgressBar mProgressBar;

        public static bool isLoading = false;

        private Button[] mBtnHoles = new Button[17];
        public static ImageView[] mImageHoles = new ImageView[17];
        
        public static Dictionary<string, string> receiptItems = new Dictionary<string, string>();
        public static string[] partShortcut = new string[17] { "HO", "D", "SCHIE", "H", "DR", "SR", "THR", "TR", "KR", "DL", "KL", "TL", "THL", "SL", "HE", "TOBEADDED", "TOBEADDED2"};

        private static int[] rowsH = new int[55] { 1,2,3,4,5,6,7,8,9,10,13,16,19,22,25,28,31,34,37,40,45,50,55,60,65,70,75,80,85,90,95,100,110,120,130,140,150,160,170,180,190,200,210,220,230,240,250,260,270,280,300,325,350,375,400};
        private static int[] rowsV = Enumerable.Range(1, 50).ToArray();
        private static int[] columns = new int[7] { 20, 30, 40, 50, 60, 70, 80 };
        public static double[,] horizontalTable = new double[55, 7] { {6,7,8,9,10,11,12}, {7,9,10,12,13,15,17}, {8,10,12,14,16,19,22}, {9,12,14,17,19,23,27}, {10,13,16,19,23,27,32}, {11,15,18,22,25,31,37}, {12,16,20,24,28,35,42}, {13,18,22,27,31,39,47}, {14,19,24,29,34,43,52}, {15,21,26,32,37,47,57}, {17,23,29,36,43,55,68}, {19,25,32,40,44,64,80}, {20,27,35,44,54,72,91}, {22,29,37,48,59,79,100}, {23,30,40,51,64,85,108}, {24,32,42,54,69,92,116}, {25,33,44,58,74,98,124}, {26,35,46,61,78,104,131}, {27,36,48,64,83,111,139}, {28,38,50,68,88,117,147}, {30,40,54,73,98,128,160}, {32,43,57,78,104,138,173}, {33,45,61,84,112,149,186}, {35,48,64,89,120,159,199}, {37,50,68,95,128,170,212}, {39,53,71,101,138,180,225}, {40,55,75,106,144,191,233}, {42,58,78,112,152,201,241}, {44,60,82,117,160,212,0}, {46,63,85,123,166,222,0}, {47,65,89,128,176,0,0}, {49,68,92,134,184,0,0}, {53,73,99,145,200,0,0}, {56,78,106,156,216,0,0}, {60,83,113,166,0,0,0}, {63,88,120,177,0,0,0}, {67,93,127,188,0,0,0}, {70,98,134,199,0,0,0}, {74,103,141,210,0,0,0}, {77,108,148,0,0,0,0}, {80,113,155,0,0,0,0}, {84,118,162,0,0,0,0}, {87,123,169,0,0,0,0}, {91,128,176,0,0,0,0}, {94,133,183,0,0,0,0}, {98,138,190,0,0,0,0}, {102,143,197,0,0,0,0}, {104,147,203,0,0,0,0}, {106,151,209,0,0,0,0}, {109,155,215,0,0,0,0}, {114,163,0,0,0,0,0}, {122,174,0,0,0,0,0}, {129,186,0,0,0,0,0}, {137,197,0,0,0,0,0}, {145,209,0,0,0,0,0} };
        public static double[,] verticalTable = new double[50, 7] { {6,7,9,10,10,11,12}, {8,9,12,14,14,16,19}, {9,11,14,17,16,21,25}, {11,13,17,21,22,26,32}, {12,15,19,24,26,31,38}, {13,17,21,27,28,35,43}, {14,18,23,29,32,38,47}, {15,20,25,32,35,42,52}, {16,21,27,34,38,45,56}, {17,23,29,37,41,49,61}, {18,24,31,39,44,42,65}, {19,26,33,42,47,56,69}, {20,27,35,44,50,59,73}, {21,29,37,47,53,63,77}, {22,30,39,49,56,66,81}, {23,32,41,52,59,70,85}, {24,33,43,54,62,73,89}, {25,35,45,57,66,77,83}, {26,36,47,59,68,80,97}, {27,38,49,62,71,84,101}, {28,39,51,64,74,87,105}, {29,40,52,66,76,90,109}, {29,41,54,68,79,93,113}, {30,42,55,70,81,96,117}, {31,43,57,72,84,99,121}, {32,44,58,74,86,102,125}, {32,45,60,76,89,105,129}, {33,46,61,78,91,108,133}, {34,47,63,80,94,111,137}, {35,48,64,82,96,114,141}, {35,49,66,84,99,117,145}, {36,50,67,86,101,120,149}, {37,51,69,88,104,123,153}, {38,52,70,90,106,126,157}, {38,53,72,92,109,129,161}, {39,54,73,94,111,132,165}, {40,55,75,96,114,135,169}, {41,56,76,98,116,138,173}, {41,57,78,100,119,141,177}, {42,58,79,102,121,144,181}, {43,59,81,104,124,147,185}, {44,60,82,106,126,150,189}, {44,61,84,108,129,153,193}, {45,62,85,110,131,156,197}, {46,63,87,112,134,159,201}, {47,64,88,114,136,162,205}, {47,65,90,116,139,165,209}, {48,66,91,118,141,168,213}, {49,67,93,120,144,171,217}, {50,68,94,122,146,174,221} };

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.carLayout);

            //ovo sacuva varijablu u spremiste aplikacije tako da kad i izgasis aplikaciju ili kad ista napravis,
            //osim uninstallas, sacuva ti je zauvik 
            ISharedPreferences pref = Application.Context.GetSharedPreferences("MultiplierInfo", FileCreationMode.Private);
            multiplier = pref.GetInt("Multiplier", 7);

            //postavljanje toolbar-a
            mToolBar = FindViewById<SupportToolbar>(Resource.Id.toolbar);
            SetSupportActionBar(mToolBar);

            //progressbar za kad ucitava pdf
            mProgressBar = FindViewById<ProgressBar>(Resource.Id.progressBar1);

            //EditText u toolbaru, za ime auta
            mEditText = FindViewById<EditText>(Resource.Id.myEditText);
            //da se vrati tekst na pocetak ako je predug
            mEditText.FocusChange += (object sender, View.FocusChangeEventArgs e) =>
            {
                mEditText.SetSelection(0);
            };
                     
            //pager = FindViewById<ViewPager>(Resource.Id.imageView1);
            mBtnPicture = FindViewById<Button>(Resource.Id.btnPicture);
            mBtnBack = FindViewById<ImageButton>(Resource.Id.backButton);
            mBtnInfo = FindViewById<Button>(Resource.Id.btnInfo);
            mTxtViewPrice = FindViewById<TextView>(Resource.Id.txtPrice);

            //ovo je tu radi buga sa landscapeom
            mTxtViewPrice.Text = priceString;
            
            if(savedInstanceState == null)
            {
                //ovo ima mjesta za nadogradnju, sa ovim se ispunjava mapa sa 17 elemenata, a moze se mozda i napraviti
                //tako da se dodaje element u mapu sa svakim pritiskom na save u dialog_Holes
                for (int i = 0; i < 17; i++)
                {
                    //holesQuantity i diameter su na pocetku prazne mape lista za rupe
                    List<String> helpList = new List<string>();
                    holesQuantity.Add(i, helpList);
                    List<String> helpList2 = new List<string>();
                    diameter.Add(i, helpList2);
                }
            }

            for(int k = 0; k < 15; k++)
            {
                mBtnHoles[k] = FindViewById<Button>(Resources.GetIdentifier("button" + k, "id", PackageName));
                //mImageHoles[k] = FindViewById<ImageView>(Resources.GetIdentifier("imageHole" + k, "id", PackageName));
                mBtnHoles[k].Click += CarActivity_Click;
            }

            mBtnPicture.Click += MBtnPicture_Click;
            mBtnInfo.Click += MBtnInfo_Click;
            mBtnBack.Click += MBtnBack_Click;
            
            if (IsThereAnAppToTakePictures())
            {
                CreateDirectoryForPictures();
                Button button = FindViewById<Button>(Resource.Id.picture);
                button.Click += TakeAPicture;
            }

            //postavi sve za ViewPager
            /*var viewPager = FindViewById<ViewPager>(Resource.Id.imageView1);
            adapter = new FragmentAdapter(SupportFragmentManager);
            viewPager.Adapter = adapter;*/

            //dohvati informacije ako je korisnik usao u sacuvano auto
            string text = Intent.GetStringExtra("ListViewPosition") ?? "Data not available";
            string savedCarName = Intent.GetStringExtra("CarName") ?? "Data not available";
            string savedCarPrice = Intent.GetStringExtra("CarPrice") ?? "Data not available";

            //ovo je tu radi buga kod pribacivanja u landscape(neke varijable zapamti neke ne, mozda ima neke veze sa tim
            //koja je varijabla static koja nije)
            if(!text.Equals("-1") && !text.Equals("Data not available") && savedInstanceState != null)
            {
                ISharedPreferences pref2 = Application.Context.GetSharedPreferences("Cars", FileCreationMode.Private);
                int help = 0;
                int position = 0;
                if (pref2.GetBoolean("IsListFull", false))
                {
                    if (Int32.Parse(text) > pref2.GetInt("NumberOfCars", 0))
                        help = maxNumberOfSavedCars + pref2.GetInt("NumberOfCars", 0);
                    else
                        help = pref2.GetInt("NumberOfCars", 0);
                }
                else
                {
                    help = pref2.GetInt("NumberOfCars", 0);
                }
                position = help - Int32.Parse(text) - 1;
                positionOfSaved = position.ToString();
                editingSaved = true;
            }

            //ucitaj sacuvani auto
            if (!text.Equals("-1") && !text.Equals("Data not available") && savedInstanceState == null)
            {
                editingSaved = true;
                mEditText.Text = savedCarName;
                mTxtViewPrice.Text = savedCarPrice;
                ISharedPreferences pref2 = Application.Context.GetSharedPreferences("Cars", FileCreationMode.Private);
                int help = 0;
                int position = 0;
                if (pref2.GetBoolean("IsListFull", false))
                {
                    if (Int32.Parse(text) >= pref2.GetInt("NumberOfCars", 0))
                        help = maxNumberOfSavedCars + pref2.GetInt("NumberOfCars", 0);
                    else
                        help = pref2.GetInt("NumberOfCars", 0);
                }
                else
                {
                    help = pref2.GetInt("NumberOfCars", 0);
                }
                position = help - Int32.Parse(text) - 1;
                positionOfSaved = position.ToString();

                string content;
                using (StreamReader sr = new StreamReader(System.IO.Path.Combine(System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "testTxt" + position.ToString() + ".txt")))
                {
                    content = sr.ReadToEnd();
                    //ovo je tu zato sta procita i \n na kraju stream-a
                    content = content.Remove(content.Length - 1);
                    string[] elements = content.Split('$');

                    for(int u = 0; u < 17; u++)
                    {
                        string[] holes = elements[u].Split('|');
                        if (!holes[0].Equals("0"))
                        {
                            for (int p = 0; p < holes.Length; p++)
                            {
                                holesQuantity.GetValueOrDefault(u).Add(holes[p]);
                            }
                        }
                    }

                    for (int u = 17; u < 34; u++)
                    {
                        string[] holes = elements[u].Split('|');
                        if (!holes[0].Equals("0"))
                        {
                            for (int p = 0; p < holes.Length; p++)
                            {
                                diameter.GetValueOrDefault(u-17).Add(holes[p]);
                            }
                        }
                    }
                    carType = elements[34];
                    chassisNumber = elements[35];
                    name = elements[36];
                    address = elements[37];
                    kilometres = elements[38];
                    phone = elements[39];

                    //multiplier funkcionira tako da ako udes u saveani auto on u tom autu ima multiplier kojeg si imao
                    //kada si ga saveao, tako da npr ako napravis novi auto i promijenis mutiplier ne promijeni za sve
                    //ostale aute
                    ISharedPreferences prefM = Application.Context.GetSharedPreferences("MultiplierInfo", FileCreationMode.Private);
                    savedMultiplier = prefM.GetInt("Multiplier", 7);
                    multiplier = Int32.Parse(elements[40]);
                    ISharedPreferencesEditor editM = prefM.Edit();
                    editM.PutInt("Multiplier", multiplier);
                    editM.Apply();

                    int landscapePicturesCounter = Int32.Parse(elements[41]);

                    for (int u = 0; u < landscapePicturesCounter; u++)
                        landscapePictures.Add(Int32.Parse(elements[42 + u]));
                    int m = 0;
                    for (int u = 42 + landscapePicturesCounter; u < elements.Length; u++)
                    {
                        App.allSavedPictures[m] = elements[u] + "$";
                        m++;
                    }                    

                    for (int u = 42 + landscapePicturesCounter; u < elements.Length; u++)
                    {
                        //byte[] imageAsBytes = Base64.Decode(elements[u], Base64Flags.Default);
                        //App.bitmap[u - 42 - landscapePicturesCounter] = BitmapFactory.DecodeByteArray(imageAsBytes, 0, imageAsBytes.Length);
                        App.pictureNames[u - 42 - landscapePicturesCounter] = elements[u];
                        App.pictureCounter++;
                    }
                    App.numberOfSavedPictures = App.pictureCounter;
                    MBtnPrice_Click();
                }
            }

            //ulazi u ovaj if samo kad se pokrene activity, tj. ne ulazi kad se recimo pribaci iz portrait
            //u landscape
            if (savedInstanceState == null && !editingSaved)
            {
                mEditText.RequestFocus();
                Window.SetSoftInputMode(SoftInput.StateVisible);      
            }
        }

        private void CarActivity_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            switch (btn.Id)
            {
                case Resource.Id.button0:
                    HandleButtons(1, "hood");
                    break;
                case Resource.Id.button1:
                    HandleButtons(2, "sunroof");
                    break;
                case Resource.Id.button2:
                    HandleButtons(3, "roof");
                    break;
                case Resource.Id.button3:
                    HandleButtons(4, "rearFlapAbove");
                    break;
                case Resource.Id.button4:
                    HandleButtons(5, "fenderFL");
                    break;
                case Resource.Id.button5:
                    HandleButtons(6, "doorFL");
                    break;
                case Resource.Id.button6:
                    HandleButtons(7, "doorRearL");
                    break;
                case Resource.Id.button7:
                    HandleButtons(8, "sidePartRearL");
                    break;
                case Resource.Id.button8:
                    HandleButtons(9, "fenderFR");
                    break;
                case Resource.Id.button9:
                    HandleButtons(10, "doorFR");
                    break;
                case Resource.Id.button10:
                    HandleButtons(11, "doorRearR");
                    break;
                case Resource.Id.button11:
                    HandleButtons(12, "sidePartRearR");
                    break;
                case Resource.Id.button12:
                    HandleButtons(13, "roofSparL");
                    break;
                case Resource.Id.button13:
                    HandleButtons(14, "roofSparR");
                    break;
                case Resource.Id.button14:
                    HandleButtons(15, "tailgate");
                    break;
            }
        }
        
        private void HandleButtons(int pressed, string title)
        {
            btnPressed = pressed;
            Android.App.FragmentTransaction trans = FragmentManager.BeginTransaction();
            myString = Resources.GetText(Resources.GetIdentifier(title, "string", PackageName));
            dialog_Holes dialog_btn = new dialog_Holes();

            dialog_btn.Show(trans, "Dialog");
        }

        private void MBtnInfo_Click(object sender, EventArgs e)
        {            
            Android.App.FragmentTransaction trans = FragmentManager.BeginTransaction();
            dialog_Info dialogInfo = new dialog_Info();
            dialogInfo.Show(trans, "Dialog");
        }

        private void MBtnBack_Click(object sender, EventArgs e)
        {
            Android.App.FragmentTransaction trans = FragmentManager.BeginTransaction();
            dialog_SaveYesOrNo saveYesNo = new dialog_SaveYesOrNo();
            saveYesNo.Show(trans, "Dialog");
        }

        private void MBtnPicture_Click(object sender, EventArgs e)
        {
            Intent nextActivity = new Intent(this, typeof(PictureActivity));
            StartActivity(nextActivity);
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            var inflater = MenuInflater;
            inflater.Inflate(Resource.Menu.toolbar,menu);
            return base.OnCreateOptionsMenu(menu);
        }

        //options item je desno gori
        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            int id = item.ItemId;            
            switch (id)
            {
                case Resource.Id.save:
                    MBtnSave_Click(true);
                    return true;
                case Resource.Id.multiplier:
                    Android.App.FragmentTransaction trans = FragmentManager.BeginTransaction();
                    dialog_Multiplier dialogMultiplier = new dialog_Multiplier();
                    dialogMultiplier.Show(trans, "Dialog");
                    return true;
                case Resource.Id.preview:
                    SavingPdf(true);
                    return true;
                case Resource.Id.data:
                    SavingDataPdf();
                    return true;
            }
            return base.OnOptionsItemSelected(item);
        }

        private async void SavingPdf(bool preview)
        {
            //samo ako se nesto prominilo opet stvori pdf, ako ne samo ga ucitaj
            if (didSomethingChangePreview)
            {
                mProgressBar.Visibility = ViewStates.Visible;
                wait = true;
                await myMethod();
            }

            //ucitaj pdf samo ako se to trazi, tj. nemoj ucitat pdf ako pozoves ovu funkciju u finnish-u
            if (preview)
            {
                Android.App.FragmentTransaction trans = FragmentManager.BeginTransaction();
                dialog_Preview dialogPreview = new dialog_Preview();
                dialogPreview.Show(trans, "Dialog");
            }

            if (didSomethingChangePreview)
            {
                wait = false;
                mProgressBar.Visibility = ViewStates.Gone;
            }
            didSomethingChangePreview = false;
        }

        //bez ove funkcije se nemoze napraviti loading circle, nju se ceka na izvrsavanje i onda se nastavlja kod
        //funkcije koja ju je pozvala
        async Task myMethod()
        {            
            await Task.Run(() => {
                XlsFile xls = new XlsFile(true);

                using (var template = Assets.Open("BSTReceipt.xlsx"))
                {
                    //nemoze se ucitati iz asseta tako da triba napravit ovaj stream
                    using (var memtemplate = new MemoryStream())
                    {
                        template.CopyTo(memtemplate);
                        memtemplate.Position = 0;
                        xls.Open(memtemplate);
                    }
                }

                //ako ima vise od 6 stavki ides u drugi sheet od excela, te osiguraj da su svi ostali redovi prazni
                if (receiptItems.Count > 6)
                {
                    xls.ActiveSheetByName = "Rechnung (mehr Zeilen)";
                    for (int z = receiptItems.Count; z < 10; z++)
                        xls.SetCellFromString(21 + z, 5, "");
                }
                else
                {
                    xls.ActiveSheetByName = "Rechnung";
                    for (int z = receiptItems.Count; z < 7; z++)
                        xls.SetCellFromString(21 + z, 5, "");
                }

                int u = 0;
                foreach (KeyValuePair<string, string> entry in receiptItems)
                {
                    xls.SetCellValue(21 + u, 1, carType + " Fg. Nr. " + chassisNumber);
                    xls.SetCellFromString(21 + u, 9, entry.Value);
                    xls.SetCellValue(21 + u, 12, entry.Key);
                    u++;
                }
                xls.SetCellValue(17, 12, DateTime.Today.ToString("dd.MM.yyy"));

                using (var pdf = new FlexCel.Render.FlexCelPdfExport(xls, true))
                {
                    pdf.Export(System.IO.Path.Combine(System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "BSTReceiptPdf.pdf"));
                }
                xls.Save(System.IO.Path.Combine(System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "BSTReceipt.xlsx"));
            });
        }

        private async void SavingDataPdf()
        {
            if (didSomethingChangeData)
            {
                mProgressBar.Visibility = ViewStates.Visible;
                wait = true;
                await myDataMethod();

                wait = false;
                mProgressBar.Visibility = ViewStates.Gone;
            }

            Intent activity = new Intent(this, typeof(DataActivity));
            this.StartActivity(activity);            
            didSomethingChangeData = false;
        }

        async Task myDataMethod()
        {
            await Task.Run(() => {
                XlsFile xls = new XlsFile(true);

                using (var template = Assets.Open("BSTTable.xlsx"))
                {
                    //nemoze se ucitati iz asseta tako da triba napravit ovaj stream
                    using (var memtemplate = new MemoryStream())
                    {
                        template.CopyTo(memtemplate);
                        memtemplate.Position = 0;
                        xls.Open(memtemplate);
                    }
                }
               
                xls.ActiveSheetByName = "Table";

                xls.SetCellValue(10, 1, name);
                xls.SetCellValue(11, 1, address);
                xls.SetCellValue(13, 2, phone);
                xls.SetCellValue(14, 1, carType);
                xls.SetCellValue(14, 5, chassisNumber);
                xls.SetCellValue(16, 5, kilometres);

                //ovo je raspored po tablici, brojeva botuna u aplikaciji, znaci 9 je broj botuna "fender front right",
                //to je prvi red u tablici, te je zato tu prvi element polja
                //0 je jer nismo jos napravili za kombi
                int[] partsByNumbers = new int[17] { 9,11,8,7,12,13,6,14,0,0,4,2,15,1,10,5,3 };
                string[] partsByShort = new string[17] { "KR", "KL", "TR", "THR", "TL", "THL", "SR", "SL", "TOBEADDED", "TOBEADDED2", "H", "D", "HE", "HO", "DL", "DR", "SCHIE"};

                int u = 0;
                for(int k = 0; k < 17; k++)
                {
                    if (partsByNumbers[k] == 0)
                        continue;

                    if (holesQuantity.GetValueOrDefault(partsByNumbers[k] - 1).Count > 0)
                    {
                        string allHoles = "";
                        holesQuantity.GetValueOrDefault(partsByNumbers[k] - 1).ForEach(hole =>
                        {
                            allHoles = allHoles + hole.ToString() + "|";
                        });
                        allHoles = allHoles.Remove(allHoles.Length - 1);

                        xls.SetCellValue(21 + k, 3, allHoles);

                        allHoles = "";
                        diameter.GetValueOrDefault(partsByNumbers[k] - 1).ForEach(hole =>
                        {
                            allHoles = allHoles + hole.ToString() + "|";
                        });
                        allHoles = allHoles.Remove(allHoles.Length - 1);

                        xls.SetCellValue(21 + k, 6, allHoles);

                        double totalAW = 0;
                        int holes;
                        double thisDiameter;
                        if (partsByNumbers[k] < 5)
                        {
                            holesQuantity.GetValueOrDefault(partsByNumbers[k] - 1).ForEach(hole =>
                            {
                                if (Int32.TryParse(hole, out holes) && double.TryParse(diameter.GetValueOrDefault(partsByNumbers[k] - 1)[counter], out thisDiameter))
                                {
                                    double thisPartPrice = horizontalTable[FindClosest(rowsH, holes), FindClosest(columns, thisDiameter)];
                                    totalAW = totalAW + thisPartPrice;
                                }
                                counter++;
                            });
                        }
                        else
                        {
                            holesQuantity.GetValueOrDefault(partsByNumbers[k] - 1).ForEach(hole =>
                            {
                                if (Int32.TryParse(hole, out holes) && double.TryParse(diameter.GetValueOrDefault(i)[counter], out thisDiameter))
                                {
                                    double thisPartPrice = verticalTable[FindClosest(rowsV, holes), FindClosest(columns, thisDiameter)];
                                    totalAW = totalAW + thisPartPrice;
                                }
                                counter++;
                            });                            
                        }
                        counter = 0;
                        xls.SetCellValue(21 + k, 8, totalAW);
                        xls.SetCellValue(21 + k, 14, receiptItems[partsByShort[k]]);
                    }
                }
                xls.SetCellValue(46, 11, DateTime.Today.ToString("dd.MM.yyy"));

                using (var pdf = new FlexCel.Render.FlexCelPdfExport(xls, true))
                {
                    pdf.Export(System.IO.Path.Combine(System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "dataPdf.pdf"));
                }
            });
        }
        
        //ovo je tu radi buga sa tipkovnicom
        int i;
        public override void OnWindowFocusChanged(bool hasFocus)
        {
            base.OnWindowFocusChanged(hasFocus);
            if (hasFocus && i!=0)
            {
                InputMethodManager imm = (InputMethodManager)GetSystemService(Context.InputMethodService);
                imm.HideSoftInputFromWindow(mEditText.WindowToken, 0);
                Window.SetSoftInputMode(SoftInput.StateAlwaysHidden);
            }
            i++;
        }

        public override void Finish()
        {
            //ovo je tu da sacuva ako se pritislo yes u dialog_SaveYesOrNo, MBtnSave_Click poziva base.Finish()
            if (saveInFinish)
            {
                MBtnSave_Click(false);
                saveInFinish = false;
            }
            else
            {
                base.Finish();
            }
        }
        
        //ovo je tu zato sta inace kad si focusan na EditText i pritisnes negdi drugo na ekranu, ne makne focus
        //sa EditTexta niti makne tipkovnicu
        public override bool DispatchTouchEvent(MotionEvent ev)
        {
            //ovaj if je tu za kad se ucitava pdf, da blokira svaki input
            if (wait)
                return false;
            
            if (ev.Action == MotionEventActions.Down) {
                View v = CurrentFocus;
                if (v.GetType() != typeof(EditText)) {
                    Rect outRect = new Rect();
                    v.GetGlobalVisibleRect(outRect);
                    if (!outRect.Contains((int)ev.RawX, (int) ev.RawY)) {
                        v.ClearFocus();
                        InputMethodManager imm = (InputMethodManager)GetSystemService(Context.InputMethodService);                        
                        imm.HideSoftInputFromWindow(v.WindowToken, 0);
                    }
                }
            }
            return base.DispatchTouchEvent(ev);
        }

        private void CreateDirectoryForPictures()
        {            
            App._dir = new Java.IO.File(
                Android.OS.Environment.GetExternalStoragePublicDirectory(
                    Android.OS.Environment.DirectoryPictures), "CameraAppDemo");
            if (!App._dir.Exists())
            {
                App._dir.Mkdirs();
            }
        }

        private bool IsThereAnAppToTakePictures()
        {
            Intent intent = new Intent(MediaStore.ActionImageCapture);
            IList<ResolveInfo> availableActivities =
                PackageManager.QueryIntentActivities(intent, PackageInfoFlags.MatchDefaultOnly);
            return availableActivities != null && availableActivities.Count > 0;
        }

        private void TakeAPicture(object sender, EventArgs eventArgs)
        {
            if (App.pictureCounter == 16)
            {
                Android.App.FragmentTransaction trans = FragmentManager.BeginTransaction();
                dialog_FullGallery dialogFullGallery = new dialog_FullGallery();
                dialogFullGallery.Show(trans, "Dialog");
                return;
            }
            
            Intent intent = new Intent(MediaStore.ActionImageCapture);
            App._file = new Java.IO.File(App._dir, String.Format("myPhoto_{0}.jpg", Guid.NewGuid()));
            intent.PutExtra(MediaStore.ExtraOutput, Android.Net.Uri.FromFile(App._file));
            StartActivityForResult(intent, 0);
        }

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);

            //da nebi nepotrebno obradivao podatke kada se uopce ne slika
            if(resultCode == Result.Ok)
            {
                Intent mediaScanIntent = new Intent(Intent.ActionMediaScannerScanFile);
                Android.Net.Uri contentUri = Android.Net.Uri.FromFile(App._file);
                mediaScanIntent.SetData(contentUri);
                SendBroadcast(mediaScanIntent);

                // Display in ImageView. We will resize the bitmap to fit the display.
                // Loading the full sized image will consume to much memory
                // and cause the application to crash.

                int height = Resources.DisplayMetrics.HeightPixels / 4;
                int width = Resources.DisplayMetrics.WidthPixels / 4;
                //App.bitmap2[App.pictureCounter] = App._file.Path.LoadAndResizeBitmap(width, height);
                App.pictureNames[App.pictureCounter] = App._file.Name;
                if (width > height)
                    landscapePictures.Add(App.pictureCounter);

                App.pictureCounter++;
            }

            // Dispose of the Java side bitmap.
            GC.Collect();
        }

        //kad god se pritisne back na ovom activityu on nece nikad ic back, sta je zasad 
        //ok, ali triba pazit na to, SaveYesOrNo clear-a holesQuality i diameter
        public override void OnBackPressed()
        {
            //ako ucitava nesto
            if (wait)
                return;

            Android.App.FragmentTransaction trans = FragmentManager.BeginTransaction();
            dialog_SaveYesOrNo saveYesNo = new dialog_SaveYesOrNo();
            saveYesNo.Show(trans, "Dialog");
        }        

        public static void MBtnPrice_Click()
        {
            int holes;
            double thisDiameter;
            receiptItems.Clear();
            for (int i = 0; i < 17; i++)
            {
                //ako je broj botuna manji od 4 znaci da je to horizontalna podloga
                if (i < 4)
                {
                    holesQuantity.GetValueOrDefault(i).ForEach(hole => 
                    {                        
                        if (Int32.TryParse(hole, out holes) && double.TryParse(diameter.GetValueOrDefault(i)[counter], out thisDiameter))
                        {              
                            double thisPartPrice = horizontalTable[FindClosest(rowsH, holes), FindClosest(columns, thisDiameter)];
                            
                            //receiptItems sadrzi cijene za sve rupe na jednom dijelu
                            if (receiptItems.ContainsKey(partShortcut[i]))
                                receiptItems[partShortcut[i]] = (Int32.Parse(receiptItems[partShortcut[i]]) + (thisPartPrice * multiplier)).ToString();
                            else
                                receiptItems.Add(partShortcut[i], (thisPartPrice * multiplier).ToString());
                        }
                        //counter je tu za pomicanje po rupama u listi, koja je u mapi (za kada jedan dio ima vise razlicitih rupa)
                        counter++;
                    });       
                }
                else
                {
                    holesQuantity.GetValueOrDefault(i).ForEach(hole =>
                    {
                        if (Int32.TryParse(hole, out holes) && double.TryParse(diameter.GetValueOrDefault(i)[counter], out thisDiameter))
                        {
                            double thisPartPrice = verticalTable[FindClosest(rowsV, holes), FindClosest(columns, thisDiameter)];
                            
                            if (receiptItems.ContainsKey(partShortcut[i]))
                                receiptItems[partShortcut[i]] = (thisPartPrice * multiplier).ToString();
                            else
                                receiptItems.Add(partShortcut[i], (thisPartPrice * multiplier).ToString());
                        }             
                        counter++;
                    });
                }
                counter = 0;
            }

            double sum = 0;
            foreach (var entry in receiptItems.Values)
            {
                double unit;
                if(Double.TryParse(entry, out unit))
                    sum = sum + unit;
            }

            //ako se ta rupa neradi onda da se zna da je greska(sum je 0 kada tog podatka nema u tablici AW)
            if (sum == 0)
            {
                mTxtViewPrice.Text = "-";
                priceString = "-";
            }
            else
            {
                mTxtViewPrice.Text = sum.ToString() + "€";
                priceString = sum.ToString() + "€";
            }
        }

        //trazenje najblize kolicine i promjera rupa, da nademo odgovarajuci AW u tablici koju nam je on dao
        private static int FindClosest(int[] array,double closestTo)
        {
            double difference = 1000.0;
            int closest = 1000;
            for (int i = (array.Length - 1); i >= 0; i--)
            {
                if (Math.Abs(array[i]-closestTo) < difference)
                {
                    difference = Math.Abs(array[i] - closestTo);
                    closest = i;
                }
            }
            return closest;
        }

        async Task mySavingMethod()
        {
            await Task.Run(() => {
                string str = "";

                for (int u = 0; u < 17; u++)
                {
                    if (holesQuantity.GetValueOrDefault(u).Count == 0)
                    {
                        str = str + "0";
                    }
                    else
                    {
                        holesQuantity.GetValueOrDefault(u).ForEach(hole =>
                        {
                            str = str + hole + "|";
                        });
                        str = str.Remove(str.Length - 1);
                    }
                    str = str + "$";
                }

                for (int u = 0; u < 17; u++)
                {
                    if (diameter.GetValueOrDefault(u).Count == 0)
                    {
                        str = str + "0";
                    }
                    else
                    {
                        diameter.GetValueOrDefault(u).ForEach(hole =>
                        {
                            str = str + hole + "|";
                        });
                        str = str.Remove(str.Length - 1);
                    }
                    str = str + "$";
                }

                str = str + carType + "$" + chassisNumber + "$" + name + "$" + address + "$" + kilometres + "$" + phone + "$";

                str = str + multiplier.ToString() + "$";

                str = str + landscapePictures.Count + "$";
                for (int a = 0; a < landscapePictures.Count; a++)
                    str = str + landscapePictures[a] + "$";

                for(int t = 0; t < App.allSavedPictures.Length; t++)
                {
                    if (!allDeletedPictures.Contains(t))
                        str = str + App.allSavedPictures[t];
                }
                
                int start = (App.numberOfSavedPictures - numberOfDeletedPictures) < 0 ? 0 : (App.numberOfSavedPictures - numberOfDeletedPictures);

                int pictureC = App.pictureCounter;
                for (int u = start; u < pictureC; u++)
                {
                    /*if (App.bitmap[u] != null)
                    {
                        using (var stream = new MemoryStream())
                        {
                            App.bitmap[u].Compress(Bitmap.CompressFormat.Png, 0, stream);

                            var bytes = stream.ToArray();
                            str = str + Convert.ToBase64String(bytes) + "$";
                        }
                    }
                    else
                    {
                        break;
                    }*/
                    str = str + App.pictureNames[u] + "$";
                }

                str = str.Remove(str.Length - 1);

                string position = "";
                ISharedPreferences pref = Application.Context.GetSharedPreferences("Cars", FileCreationMode.Private);
                ISharedPreferencesEditor edit = pref.Edit();
                if (!editingSaved)
                {
                    int numberOfSavedCars = pref.GetInt("NumberOfCars", 0);
                    if (numberOfSavedCars == maxNumberOfSavedCars)
                    {
                        edit.PutBoolean("IsListFull", true);
                        position = "0";
                        edit.PutInt("NumberOfCars", 1);
                        edit.PutString("CarName0", mEditText.Text);
                        edit.PutString("CarPrice0", mTxtViewPrice.Text);
                    }
                    else
                    {
                        position = numberOfSavedCars.ToString();
                        edit.PutString("CarName" + numberOfSavedCars.ToString(), mEditText.Text);
                        edit.PutString("CarPrice" + numberOfSavedCars.ToString(), mTxtViewPrice.Text);
                        edit.PutInt("NumberOfCars", numberOfSavedCars + 1);
                    }
                    edit.Apply();
                }
                else
                {
                    position = positionOfSaved;
                    edit.PutString("CarName" + positionOfSaved, mEditText.Text);
                    edit.PutString("CarPrice" + positionOfSaved, mTxtViewPrice.Text);
                    edit.Apply();
                }

                AssetManager assets = this.Assets;
                using (var streamWriter = new StreamWriter(System.IO.Path.Combine(System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "testTxt" + position + ".txt")))
                {
                    streamWriter.WriteLine(str);
                }
            });
        }

        private async void MBtnSave_Click(bool check)
        {
            //ako su podaci nepotpuni...
            if ((receiptItems.Count == 0 || carType == "" || chassisNumber == "") && check)
            {
                Android.App.FragmentTransaction trans = FragmentManager.BeginTransaction();
                dialog_SaveIncomplete saveYesNo = new dialog_SaveIncomplete();
                saveYesNo.Show(trans, "Dialog");
                return;
            }

            mProgressBar.Visibility = ViewStates.Visible;
            wait = true;
            await mySavingMethod();
            wait = false;
            mProgressBar.Visibility = ViewStates.Gone;

            FinnishActivity();
        }

        public void FinnishActivity()
        {
            //mora se sve ocistit jer su varijable static pa ih zapamti kod novog pokretanja activitya
            holesQuantity.Clear();
            diameter.Clear();
            receiptItems.Clear();
            priceString = "0€";
            carType = "";
            chassisNumber = "";
            name = "";
            address = "";
            kilometres = "";
            phone = "";
            App.numberOfSavedPictures = 0;
            numberOfDeletedPictures = 0;
            allDeletedPictures.Clear();
            landscapePictures.Clear();
            for (int n = 0; n < 16; n++)
            {
                //App.bitmap[n] = null;
                App.allSavedPictures[n] = null;
                App.pictureNames[n] = null;
            }
            App.pictureCounter = 0;
            didSomethingChangePreview = true;
            didSomethingChangeData = true;
            isLoading = false;

            if (editingSaved)
            {
                ISharedPreferences prefM = Application.Context.GetSharedPreferences("MultiplierInfo", FileCreationMode.Private);
                ISharedPreferencesEditor editM = prefM.Edit();
                editM.PutInt("Multiplier", savedMultiplier);
                editM.Apply();
            }

            Intent nextActivity = new Intent(this, typeof(MainActivity));
            StartActivity(nextActivity);
            base.Finish();
        }
    }

    public static class BitmapHelpers
    {
        public static Bitmap LoadAndResizeBitmap(this string fileName, int width, int height)
        {
            // First we get the the dimensions of the file on disk
            BitmapFactory.Options options = new BitmapFactory.Options { InJustDecodeBounds = true };
            BitmapFactory.DecodeFile(fileName, options);

            // Next we calculate the ratio that we need to resize the image by
            // in order to fit the requested dimensions.
            int outHeight = options.OutHeight;
            int outWidth = options.OutWidth;
            int inSampleSize = 1;

            if (outHeight > height || outWidth > width)
            {
                inSampleSize = outWidth > outHeight
                                   ? outHeight / height
                                   : outWidth / width;
            }

            if (outHeight < outWidth)
            {
                options.OutHeight = outWidth;
                options.OutWidth = outHeight;
            }
            
            // Now we will load the image and have BitmapFactory resize it for us.
            //options.InSampleSize = inSampleSize;
            options.InSampleSize = inSampleSize;
            options.InJustDecodeBounds = false;
            Bitmap resizedBitmap = BitmapFactory.DecodeFile(fileName, options);
            
            ExifInterface exif = new ExifInterface(fileName);

            if (width > height)
            {                
                Matrix mtxL = new Matrix();
                mtxL.PostRotate(90);
                resizedBitmap = Bitmap.CreateBitmap(resizedBitmap, 0, 0, resizedBitmap.Width, resizedBitmap.Height, mtxL, false);
                mtxL.Dispose();
                mtxL = null;
            }

            string orientation = exif.GetAttribute(ExifInterface.TagOrientation);
            

            switch (orientation)
            {
                case "6": // portrait
                    Matrix mtx = new Matrix();
                    mtx.PreRotate(90);
                    resizedBitmap = Bitmap.CreateBitmap(resizedBitmap, 0, 0, resizedBitmap.Width, resizedBitmap.Height, mtx, false);
                    mtx.Dispose();
                    mtx = null;
                    break;
            }

            return resizedBitmap;
        }
    }
}