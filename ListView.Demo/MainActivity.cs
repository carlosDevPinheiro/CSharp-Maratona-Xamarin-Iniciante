using Android.App;
using Android.Widget;
using Android.OS;

namespace ListView.Demo
{
    [Activity(Label = "ListView.Demo", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.Main);
            EmpregadoList listaEmpregados = new EmpregadoList();
            var empregados = listaEmpregados.SelecionarEmpregados(20);

            ListView lvEmpregados = FindViewById<ListView>
        }
    }
}

