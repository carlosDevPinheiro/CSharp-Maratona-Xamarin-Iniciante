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
using System.IO;
using SQLite;

namespace SQLiteBD
{
    [Activity(Label = "Vista Capital")]
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

                var path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);

                path = Path.Combine(path, "Base.db3");

                var conn = new SQLiteConnection(path);

                var elementos = from s in conn.Table<Informacoes>()
                                select s;
                foreach (var fila in elementos)
                {
                    Toast.MakeText(this, fila.IngressosMexico.ToString(), ToastLength.Short).Show();

                    Toast.MakeText(this, fila.IngressosColombia.ToString(), ToastLength.Short).Show();

                    Toast.MakeText(this, fila.EgressosMexixo.ToString(), ToastLength.Short).Show();

                    Toast.MakeText(this, fila.EgressoaColombia.ToString(), ToastLength.Short).Show();
                }
            }
            catch (Exception ex)
            {

                Toast.MakeText(this, ex.Message, ToastLength.Short);
            }
        }
    }
}