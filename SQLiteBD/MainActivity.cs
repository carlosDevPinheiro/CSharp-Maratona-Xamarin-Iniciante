using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content;
using System.IO;
using SQLite;

namespace SQLiteBD
{
    [Activity(Label = "SQLite", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        double CapitalM, CapitalC, IngressosM, IngressosC, EgressosM, EgressosC;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

          
            SetContentView(Resource.Layout.Main);

            // caminho onde vamos salvar o BD
            var path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);

            // combinando o caminho com nome do banco de dados
            path = Path.Combine(path, "Base.db3");

            var conn = new SQLiteConnection(path);

            // criando uma tabela na conexao
            conn.CreateTable<Informacoes>();

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

                    var inserir = new Informacoes();

                    inserir.IngressosMexico = IngressosM;
                    inserir.IngressosColombia = IngressosC;
                    inserir.EgressosMexixo = EgressosM;
                    inserir.EgressoaColombia = EgressosC;

                    conn.Insert(inserir);
                    Toast.MakeText(this, "Salvando em SQLite", ToastLength.Long).Show();

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

    public class Informacoes
    {
        public double IngressosMexico { get; set;}
        public double IngressosColombia { get; set; }
        public double EgressosMexixo { get; set; }
        public double EgressoaColombia { get; set; }

    }
}

