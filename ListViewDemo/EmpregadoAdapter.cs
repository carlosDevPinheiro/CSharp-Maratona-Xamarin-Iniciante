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

namespace ListViewDemo
{
    public class EmpregadoAdapter : BaseAdapter<Empregado>
    {
        Empregado[] dados;

        public EmpregadoAdapter(Empregado[] dados)
        {
            this.dados = dados;
        }

        public override Empregado this[int position]
        {
            get
            {
                return dados[position];
            }
        }

        public override int Count
        {
            get
            {
                return dados.Count();
            }
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var inflater = LayoutInflater.From(parent.Context); // criando um contexto onde vamos trbalhar geralmene é Actitvy onde a interface do usuario é Mostrada

            ///<summary>
            /// inflate(); => Obtenho a instancia da view
            /// 1º parametro => o layout que vou usar 
            /// 2º parametro => tambem informo o parente,
            /// 3º parametro => se quero atacha-lo como root digo que nao 
            /// </summary>
            var view = inflater.Inflate(Resource.Layout.EmpregadoItem, parent, false);

            // agora vamos criar nossos elementos 
            var txvNome = view.FindViewById<TextView>(Resource.Id.txvNome);
            var txvEmail = view.FindViewById<TextView>(Resource.Id.txvEmail);

            // passando os valores das proproedades para os elementos criados
            txvNome.Text = dados[position].Nome;
            txvEmail.Text = dados[position].Email;

            // retornar a view que acabamos de Criar
            return view;
        }
    }
}