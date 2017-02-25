using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content;

namespace PopulacaoColombiaMexico
{
    [Activity(Label = "PopulacaoColombiaMexico", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        double CapitalM, CapitalC, IngressosM, IngressosC, EgressosM, EgressosC;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            // SetContentView (Resource.Layout.Main);
            SetContentView(Resource.Layout.Main);

            Button btnCalcular = FindViewById<Button>(Resource.Id.btnCalcular);
            EditText txtIngressoM = FindViewById<EditText>(Resource.Id.txtIngresopMexico);
            EditText txtIngressoC = FindViewById<EditText>(Resource.Id.txtIngresopColombia);
            EditText txtEgressoM = FindViewById<EditText>(Resource.Id.txtEgressoMexico);
            EditText txtEgressoC = FindViewById<EditText>(Resource.Id.txtEgressoColombia);



            btnCalcular.Click += delegate
            {
                try
                {
                    IngressosM = double.Parse(txtIngressoM.Text);
                    IngressosC = double.Parse(txtIngressoC.Text);
                    EgressosM = double.Parse(txtEgressoM.Text);
                    EgressosC = double.Parse(txtEgressoC.Text);

                    CapitalM = IngressosM - EgressosM;
                    CapitalC = IngressosC - EgressosC;
                    Cargar();

                }
                catch (System.Exception ex)
                {
                    Toast.MakeText(this, ex.Message, ToastLength.Short);
                }
            };
        }

        public void Cargar()
        {
            Intent objIntent = new Intent(this, typeof(VistaCapital));
            objIntent.PutExtra("CapitalM", CapitalM);
            objIntent.PutExtra("CapitalC", CapitalC);
            StartActivity(objIntent);
        }
    }
}

