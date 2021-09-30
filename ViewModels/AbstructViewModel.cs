using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake.ViewModels {
    public abstract class AbstructViewModel : INotifyPropertyChanged {
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
