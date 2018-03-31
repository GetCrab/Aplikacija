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
using Android.Graphics;
using Android.Support.V7.App;
using SupportToolbar = Android.Support.V7.Widget.Toolbar;
using Android.Support.V4.Widget;
using System.IO;
using FFImageLoading;
using FFImageLoading.Views;
using Android.Media;

namespace App4
{
    [Activity(Label = "TestActivity", Theme = "@style/MyTheme")]
    public class PictureActivity : ActionBarActivity
    {
        public static ImageViewAsync[] imageView = new ImageViewAsync[16];
        public static ImageView[] selectedImage = new ImageView[16];
        public static Button[] button = new Button[16];

        public static bool pressedYesOnDelete = false;

        public static List<int> selectedImages = new List<int>();
        
        public static int currentButton = -1;

        public static bool deleteMode = false;

        private static ImageButton mBtnBack,mBtnDelete;
        private SupportToolbar mToolBar;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.PictureLayout);

            mBtnBack = FindViewById<ImageButton>(Resource.Id.backButton);
            mBtnDelete = FindViewById<ImageButton>(Resource.Id.deleteButton);
            mToolBar = FindViewById<SupportToolbar>(Resource.Id.toolbar);
            SetSupportActionBar(mToolBar);
            mToolBar.Title = "";
            mBtnDelete.Visibility = ViewStates.Invisible;

            imageView[0] = FindViewById<ImageViewAsync>(Resource.Id.imageView1);
            imageView[1] = FindViewById<ImageViewAsync>(Resource.Id.imageView2);
            imageView[2] = FindViewById<ImageViewAsync>(Resource.Id.imageView3);
            imageView[3] = FindViewById<ImageViewAsync>(Resource.Id.imageView4);
            imageView[4] = FindViewById<ImageViewAsync>(Resource.Id.imageView5);
            imageView[5] = FindViewById<ImageViewAsync>(Resource.Id.imageView6);
            imageView[6] = FindViewById<ImageViewAsync>(Resource.Id.imageView7);
            imageView[7] = FindViewById<ImageViewAsync>(Resource.Id.imageView8);
            imageView[8] = FindViewById<ImageViewAsync>(Resource.Id.imageView9);
            imageView[9] = FindViewById<ImageViewAsync>(Resource.Id.imageView10);
            imageView[10] = FindViewById<ImageViewAsync>(Resource.Id.imageView11);
            imageView[11] = FindViewById<ImageViewAsync>(Resource.Id.imageView12);
            imageView[12] = FindViewById<ImageViewAsync>(Resource.Id.imageView13);
            imageView[13] = FindViewById<ImageViewAsync>(Resource.Id.imageView14);
            imageView[14] = FindViewById<ImageViewAsync>(Resource.Id.imageView15);
            imageView[15] = FindViewById<ImageViewAsync>(Resource.Id.imageView16);

            selectedImage[0] = FindViewById<ImageView>(Resource.Id.selected1);
            selectedImage[1] = FindViewById<ImageView>(Resource.Id.selected2);
            selectedImage[2] = FindViewById<ImageView>(Resource.Id.selected3);
            selectedImage[3] = FindViewById<ImageView>(Resource.Id.selected4);
            selectedImage[4] = FindViewById<ImageView>(Resource.Id.selected5);
            selectedImage[5] = FindViewById<ImageView>(Resource.Id.selected6);
            selectedImage[6] = FindViewById<ImageView>(Resource.Id.selected7);
            selectedImage[7] = FindViewById<ImageView>(Resource.Id.selected8);
            selectedImage[8] = FindViewById<ImageView>(Resource.Id.selected9);
            selectedImage[9] = FindViewById<ImageView>(Resource.Id.selected10);
            selectedImage[10] = FindViewById<ImageView>(Resource.Id.selected11);
            selectedImage[11] = FindViewById<ImageView>(Resource.Id.selected12);
            selectedImage[12] = FindViewById<ImageView>(Resource.Id.selected13);
            selectedImage[13] = FindViewById<ImageView>(Resource.Id.selected14);
            selectedImage[14] = FindViewById<ImageView>(Resource.Id.selected15);
            selectedImage[15] = FindViewById<ImageView>(Resource.Id.selected16);

            button[0] = FindViewById<Button>(Resource.Id.button1);
            button[1] = FindViewById<Button>(Resource.Id.button2);
            button[2] = FindViewById<Button>(Resource.Id.button3);
            button[3] = FindViewById<Button>(Resource.Id.button4);
            button[4] = FindViewById<Button>(Resource.Id.button5);
            button[5] = FindViewById<Button>(Resource.Id.button6);
            button[6] = FindViewById<Button>(Resource.Id.button7);
            button[7] = FindViewById<Button>(Resource.Id.button8);
            button[8] = FindViewById<Button>(Resource.Id.button9);
            button[9] = FindViewById<Button>(Resource.Id.button10);
            button[10] = FindViewById<Button>(Resource.Id.button11);
            button[11] = FindViewById<Button>(Resource.Id.button12);
            button[12] = FindViewById<Button>(Resource.Id.button13);
            button[13] = FindViewById<Button>(Resource.Id.button14);
            button[14] = FindViewById<Button>(Resource.Id.button15);
            button[15] = FindViewById<Button>(Resource.Id.button16);
            
            button[0].Click += (s, e) =>
            {
                HandlingButtons(0);
            };
            button[1].Click += (s, e) =>
            {
                HandlingButtons(1);
            };
            button[2].Click += (s, e) =>
            {
                HandlingButtons(2);
            };
            button[3].Click += (s, e) =>
            {
                HandlingButtons(3);
            };
            button[4].Click += (s, e) =>
            {
                HandlingButtons(4);
            };
            button[5].Click += (s, e) =>
            {
                HandlingButtons(5);
            };
            button[6].Click += (s, e) =>
            {
                HandlingButtons(6);
            };
            button[7].Click += (s, e) =>
            {
                HandlingButtons(7);
            };
            button[8].Click += (s, e) =>
            {
                HandlingButtons(8);
            };
            button[9].Click += (s, e) =>
            {
                HandlingButtons(9);
            };
            button[10].Click += (s, e) =>
            {
                HandlingButtons(10);
            };
            button[11].Click += (s, e) =>
            {
                HandlingButtons(11);
            };
            button[12].Click += (s, e) =>
            {
                HandlingButtons(12);
            };
            button[13].Click += (s, e) =>
            {
                HandlingButtons(13);
            };
            button[14].Click += (s, e) =>
            {
                HandlingButtons(14);
            };
            button[15].Click += (s, e) =>
            {
                HandlingButtons(15);
            };

            button[0].LongClick += (s, e) =>
            {
                HandlingLongClick(0);
            };
            button[1].LongClick += (s, e) =>
            {
                HandlingLongClick(1);
            };
            button[2].LongClick += (s, e) =>
            {
                HandlingLongClick(2);
            };
            button[3].LongClick += (s, e) =>
            {
                HandlingLongClick(3);
            };
            button[4].LongClick += (s, e) =>
            {
                HandlingLongClick(4);
            };
            button[5].LongClick += (s, e) =>
            {
                HandlingLongClick(5);
            };
            button[6].LongClick += (s, e) =>
            {
                HandlingLongClick(6);
            };
            button[7].LongClick += (s, e) =>
            {
                HandlingLongClick(7);
            };
            button[8].LongClick += (s, e) =>
            {
                HandlingLongClick(8);
            };
            button[9].LongClick += (s, e) =>
            {
                HandlingLongClick(9);
            };
            button[10].LongClick += (s, e) =>
            {
                HandlingLongClick(10);
            };
            button[11].LongClick += (s, e) =>
            {
                HandlingLongClick(11);
            };
            button[12].LongClick += (s, e) =>
            {
                HandlingLongClick(12);
            };
            button[13].LongClick += (s, e) =>
            {
                HandlingLongClick(13);
            };
            button[14].LongClick += (s, e) =>
            {
                HandlingLongClick(14);
            };
            button[15].LongClick += (s, e) =>
            {
                HandlingLongClick(15);
            };

            mBtnBack.Click += MBtnBack_Click;
            mBtnDelete.Click += MBtnDelete_Click;
            int pictureCounter = CarActivity.App.pictureCounter;

            var metrics = Resources.DisplayMetrics;

            int widthInDp;
            int heightInDp;
            //ne kuzim ovo bas najbolje kako funkcionira, zasad ovako radi, ja mislim da je problem sa fitXY 
            //u axml al nisam siguran (triba bi bit grid 4*4, znaci da bi se svaki trebao dijeliti sa 4 ali tako neradi)
            if (metrics.WidthPixels < metrics.HeightPixels)
            {
                widthInDp = (int)((metrics.WidthPixels)) / 4;
                heightInDp = (int)((metrics.HeightPixels)) / 5;
            }
            else
            {
                widthInDp = (int)((metrics.WidthPixels)) / 4;
                heightInDp = (int)Math.Round(((metrics.HeightPixels)) / 2.2);
            }
            
            for (int i = 0; i < pictureCounter; i++)
            {
                if(CarActivity.App.pictureNames[i] != null)
                {
                    Java.IO.File file = new Java.IO.File(CarActivity.App._dir, CarActivity.App.pictureNames[i]);
                    if (File.Exists(file.Path))
                    {
                        button[i].Visibility = ViewStates.Visible;
                        
                        string dasda = file.Path;
                        ExifInterface exif = new ExifInterface(file.Path);
                        string orientation = exif.GetAttribute(ExifInterface.TagOrientation);
                        if (orientation.Equals("6"))
                            ImageService.Instance.LoadFile(file.Path).DownSample(width: (270), height: (480)).Transform(new MyRotateTransformation()).Into(imageView[i]);
                        else
                        //ImageService.Instance.LoadFile(file.Path).DownSample(width: (270), height: (400),allowUpscale:true).Into(imageView[i]);
                            ImageService.Instance.LoadFile(file.Path).DownSample(width: (270), height: (480)).Into(imageView[i]);


                    }
                    else if (CarActivity.App.pictureNames[i] != null)
                    {
                        selectedImages.Add(i);
                        DeleteImage();
                        i--;
                    }
                }
                
                /*using (Bitmap bitmap = file.Path.LoadAndResizeBitmap(widthInDp, heightInDp))
                         this.RunOnUiThread(
                         () => imageView[i].SetImageBitmap(Bitmap.CreateScaledBitmap(bitmap, widthInDp, heightInDp, false))

                     );*/  //GC.Collect();
                           /*if (CarActivity.App.bitmap[i] != null)
                           {
                               Bitmap d = CarActivity.App.bitmap[i];
                               imageView[i].SetImageBitmap(Bitmap.CreateScaledBitmap(d, widthInDp, heightInDp, false));
                           }*/
            }

            if (deleteMode)
            {
                mBtnDelete.Visibility = ViewStates.Visible;
            }
            foreach(int entry in selectedImages)
            {                
                selectedImage[entry].Visibility = ViewStates.Visible;
            }
        }       

        private void HandlingButtons(int buttonNumber)
        {
            if (deleteMode && selectedImages.Contains(buttonNumber) && selectedImages.Count == 1)
            {
                CancelingDeleteMode();
            }
            else if (deleteMode && selectedImages.Contains(buttonNumber))
            {
                selectedImage[buttonNumber].Visibility = ViewStates.Invisible;
                selectedImages.Remove(buttonNumber);
            }
            else if (deleteMode)
            {
                selectedImage[buttonNumber].Visibility = ViewStates.Visible;
                selectedImages.Add(buttonNumber);
            }
            else
            {
                currentButton = buttonNumber;

                FragmentTransaction trans = FragmentManager.BeginTransaction();
                dialog_Picture dialog_Picture = new dialog_Picture();
                dialog_Picture.Show(trans, "Dialog");
            }
        }        

        private void HandlingLongClick(int buttonNumber)
        {
            deleteMode = true;
            mBtnDelete.Visibility = ViewStates.Visible;
            selectedImage[buttonNumber].Visibility = ViewStates.Visible;
            selectedImages.Add(buttonNumber);
        }

        protected override void OnSaveInstanceState(Bundle outState)
        {
            base.OnSaveInstanceState(outState);
        }

        public static void CancelingDeleteMode()
        {
            deleteMode = false;
            mBtnDelete.Visibility = ViewStates.Invisible;
            for(int i = 0; i < CarActivity.App.pictureCounter; i++)
            {
                selectedImage[i].Visibility = ViewStates.Invisible;
            }
            selectedImages.RemoveAll(p => true);
        }

        private void MBtnBack_Click(object sender, EventArgs e)
        {
            Finish();
        }

        private void MBtnDelete_Click(object sender, EventArgs e)
        {
            Android.App.FragmentTransaction trans = FragmentManager.BeginTransaction();
            dialog_Delete dialogDelete = new dialog_Delete();
            dialogDelete.Show(trans, "Dialog");
        }

        int i;
        public override void OnWindowFocusChanged(bool hasFocus)
        {
            base.OnWindowFocusChanged(hasFocus);
            if (hasFocus && i != 0 && pressedYesOnDelete)
            {
                this.Recreate();
            }
            pressedYesOnDelete = false;
            i++;
        }

        public static void DeleteImage()
        {
            int pictureCounter = CarActivity.App.pictureCounter;
            int selectedCount = selectedImages.Count;
            CarActivity.numberOfDeletedPictures = CarActivity.numberOfDeletedPictures + selectedCount;
            List<int> help = new List<int>();
            selectedImages.ForEach(s => {
                int add = CarActivity.allDeletedPictures.FindAll(p => (p <= s)).Count;
                int ppp = add + CarActivity.allDeletedPictures.FindAll(p => (p + add) <= s).Count;

                help.Add(s + ppp);
            });

            help.ForEach(y => CarActivity.allDeletedPictures.Add(y));

            for (int i = 0; i < pictureCounter; i++)
            {
                if (selectedImages.Contains(i))
                {
                    for (int u = i; u < pictureCounter; u++)
                    {
                        //CarActivity.App.bitmap[u] = CarActivity.App.bitmap[u + 1];
                        CarActivity.App.pictureNames[u] = CarActivity.App.pictureNames[u + 1];
                    }
                    selectedImages.Remove(i);
                    for (int z = 0; z < selectedImages.Count; z++)
                        selectedImages[z] = selectedImages[z] - 1;
                    i--;
                }
            }

            for (int i = 0; i < pictureCounter; i++)
            {
                button[i].Visibility = ViewStates.Invisible;
            }

            CarActivity.App.pictureCounter = CarActivity.App.pictureCounter - selectedCount;
        }

        public override void OnBackPressed()
        {
            if (deleteMode)
            {
                CancelingDeleteMode();
            }
            else
            {
                Finish();
            }
        }

        public override void Finish()
        {
            selectedImages.Clear();
            deleteMode = false;
            currentButton = -1;
            base.Finish();
        }
    }
}