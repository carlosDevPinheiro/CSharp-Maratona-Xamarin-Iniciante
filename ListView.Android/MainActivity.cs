using Android.App;
using Android.Widget;
using Android.OS;
using ListView.Android;

namespace ListViewDemo.Android
{
    [Activity(Label = "ListView.Android", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.Main);
            EmpregadoList listaEmpregados = new EmpregadoList();
            var empregados = listaEmpregados.SelecionarEmpregados(20);

            ListView
        }
    }
}

