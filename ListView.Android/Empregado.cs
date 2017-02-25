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

namespace ListView.Android
{
    public class Empregado
    {
        private string _nome;
        private string _cargo;
        private string _email;

        public Empregado(string nome, string cargo, string email)
        {
            this.Nome = nome;
            this.Cargo = cargo;
            this.Email = email;
        }

        public string Nome { get { return _nome; } set { _nome = value; } }
        public string Cargo { get { return _cargo; } set { _cargo = value; } }
        public string Email { get { return _email; } set { _email = value; } }
    }

    public class EmpregadoList
    {
        public Empregado[] SelecionarEmpregados(int numero)
        {
            Empregado[] empregados = new Empregado[numero];
            String[] cargos = { "Gerente", "Supervisor", "Diretor", "Operador" };
            Random rdm = new Random();

            for (int i = 0; i < numero; i++)
            {
                var nome = Guid.NewGuid().ToString().Substring(0, 10);

                var novoEmpregado = new Empregado(
                    nome,
                    cargos[rdm.Next(0, 3)],
                    nome + "@lafan.com"
                    );
                empregados[i] = novoEmpregado;               
            }

            return empregados;
        }
    }
}