using FormsAssistControl.Model.Entities;
using FormsAssistControl.Model.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FormsAssistControl.ViewModel
{
    public class DiretorioEstudanteVM : ObservableBaseObject
    {
        public ObservableCollection<Estudante> Estudantes { get; set; }

        private bool _ocupado = false;
        public bool Ocupado
        {
            get { return _ocupado; }
            set { _ocupado = value; OnPropertyChanged(); }
        }

  
        /// O Commando é responsavel por invocar alguma ação quando for chamado pelo botão a qual esta vinculado       
        public Command  CarregarDiretorioCommand { get; set; }

        public DiretorioEstudanteVM()
        {
            Estudantes = new ObservableCollection<Estudante>();
            Ocupado = false;
            CarregarDiretorioCommand = new Command(() =>
            {
                CarregarDiretotio();
            });
        }

        async void CarregarDiretotio()
        {
            if (!Ocupado)
            {
                Ocupado = true;

                // simular um delay de 3 segundos
                await Task.Delay(3000);

                var diretorioCarragdo = DiretorioEstudanteServicos.CarregarDiretorioEstudante();

                foreach (var estudante in diretorioCarragdo.Estudantes)
                {
                    Estudantes.Add(estudante);
                }

                Ocupado = false;
            }
               
        }
    }
}
