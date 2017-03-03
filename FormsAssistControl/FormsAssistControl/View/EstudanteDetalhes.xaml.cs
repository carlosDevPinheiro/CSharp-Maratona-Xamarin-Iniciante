using FormsAssistControl.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FormsAssistControl.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EstudanteDetalhes : ContentPage
    {
        public EstudanteDetalhes(Estudante estudanteSelecionado)
        {
            InitializeComponent();
            this.BindingContext = estudanteSelecionado;
            
        }
    }
}
