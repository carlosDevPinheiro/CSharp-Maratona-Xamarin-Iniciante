using FormsAssistControl.Model.Entities;
using FormsAssistControl.View;
using FormsAssistControl.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FormsAssistControl
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            //vamos atribuir um contexto para a view atraves do bindingContext
            this.BindingContext = new DiretorioEstudanteVM();

            //
            lvEstudantes.ItemSelected += LvEstudantes_Slecionado;
        }

        private void LvEstudantes_Slecionado(object sender, SelectedItemChangedEventArgs e)
        {
            Estudante estudanteSelecionado = (Estudante)e.SelectedItem;

            if (estudanteSelecionado == null)
                            return;
            Navigation.PushAsync(new EstudanteDetalhes(estudanteSelecionado));

            lvEstudantes.SelectedItem = null;
        }
    }
}
