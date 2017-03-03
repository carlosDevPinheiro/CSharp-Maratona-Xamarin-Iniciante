using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace FormsAssistControl.Model.Entities
{
    public class ObservableBaseObject : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = delegate
        {

        };

        // CallerMemberName => de maneira automatica se obtem o nome da propriedade que o invocou
        public void OnPropertyChanged([CallerMemberName] string name="")
        {
            // verificar se a propriedade que chamou não seja null, se sim retorna vazio
            if (PropertyChanged == null)
                return;

            PropertyChanged.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
