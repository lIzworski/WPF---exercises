using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kolory.ModelWidoku
{
    using Model;
    using System.Windows.Input;

    public class ModelWidokuMPAM : INotifyPropertyChanged
    {

        ModelMPAM model = PlikHelper.Odczyt();
        public double Wartosc { get { return model.Wartosc; } set { model.Wartosc = value; onPropertyChanged(nameof(Wartosc)); /*PlikHelper.Zapisz();*/ model.Zapisz(); } }

        private ICommand resetuj = null;

        public ICommand Resetuj
        {
            get
            {
                if (resetuj == null) resetuj = new RelayCommand(
                    (object o) =>
                    {
                        model.resetuj();
                        onPropertyChanged(nameof(Wartosc));
                    },
                    (object o) =>
                    {
                        return model.Wartosc > 0;
                    } );
                return resetuj; 
            }
        }


        public event PropertyChangedEventHandler? PropertyChanged;

        public void onPropertyChanged(string NazwaWłasnosci)
        {
            if(PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(NazwaWłasnosci));
            }
        }
    }
}
