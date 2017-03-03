using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormsAssistControl.Model.Entities
{
    public class Estudante : ObservableBaseObject
    {
        private string _name;
        private string _lastName;
        private string _turma;
        private string _numeroAluno;
        private double _media;


        public string Name
        {
            get { return _name; }
            set { _name = value; OnPropertyChanged(); }
        }

        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; OnPropertyChanged(); }
        }

        public string Turma
        {
            get { return _turma; }
            set { _turma = value; OnPropertyChanged(); }
        }

        public string NumeroAluno
        {
            get { return _numeroAluno; }
            set { _numeroAluno = value; OnPropertyChanged(); }
        }

        public double Media
        {
            get { return _media; }
            set { _media = value; OnPropertyChanged(); }
        }
    }
}
