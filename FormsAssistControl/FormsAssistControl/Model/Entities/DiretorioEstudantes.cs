using System.Collections.ObjectModel;

namespace FormsAssistControl.Model.Entities
{
    public class DiretorioEstudantes : ObservableBaseObject
    {
        private ObservableCollection<Estudante> _estudantes = new ObservableCollection<Estudante>();

        public ObservableCollection<Estudante> Estudantes
        {
            get { return _estudantes; }
            set { _estudantes = value; OnPropertyChanged(); }
        }
    }
}
