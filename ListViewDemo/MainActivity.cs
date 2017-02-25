using Android.App;
using Android.Widget;
using Android.OS;

namespace ListViewDemo
{
    [Activity(Label = "ListViewDemo", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.Main);
            EmpregadoList listaEmpregados = new EmpregadoList();
            var empregados = listaEmpregados.SelecionarEmpregados(20);

            // listV iew criado para apresentar os dados
            ListView lvEmpregados = FindViewById<ListView>(Resource.Id.empregados);

            #region Usando o Aadpter do Android
            ///<summary>
            /// requer um adaptador para colocar os dados, vamos usar ArrayAdapter e ele precisa de tres parametros
            /// 1 . um contexto, nesse caso éssa MainActivity
            /// 2 . um Layout para aparesentar os dados Vamos usar o SimplesListItem1 do properio android
            /// 3. a lista de dados que sera aparesentada
            /// </summary>

            //ArrayAdapter<Empregado> Adapter = new ArrayAdapter<Empregado>(this, Android.Resource.Layout.SimpleListItem1, empregados); 
            #endregion

            #region Usando o Adapter que criamos para empregadod

            EmpregadoAdapter adapter = new EmpregadoAdapter(empregados);

            #endregion

            // Passando adaptador para o ListView
            lvEmpregados.Adapter = adapter;

        }
    }
}

