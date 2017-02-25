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

namespace PopulacaoColombiaMexico
{
    [Activity(Label = "VistaCapital")]
    public class VistaCapital : Activity
    {
        double DefaultValue;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.VistaCapital);

            EditText txtCapitalM = FindViewById<EditText>(Resource.Id.txtcapitalM);
            EditText txtCapitalC = FindViewById<EditText>(Resource.Id.txtcapitalC);

            ImageView ImagenMex = FindViewById<ImageView>(Resource.Id.imgMexico);
            ImageView imagenCol = FindViewById<ImageView>(Resource.Id.imgColombia);

            try
            {
                txtCapitalM.Text = Intent.GetDoubleExtra("CapitalM", DefaultValue).ToString();
                txtCapitalC.Text = Intent.GetDoubleExtra("CapitalC", DefaultValue).ToString();
                ImagenMex.SetImageResource(Resource.Id.imgMexico);
                imagenCol.SetImageResource(Resource.Id.imgColombia);
            }
            catch (Exception ex)
            {

                Toast.MakeText(this, ex.Message, ToastLength.Short);
            }
        }
    }
}