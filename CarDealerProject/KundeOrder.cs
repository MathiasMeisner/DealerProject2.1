using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CarDealerProject
{
    public class Kunde : INotifyPropertyChanged
    {
        private string kundeEmail;
        public string KundeEmail
        {
            get { return kundeEmail; }
            set
            {
                kundeEmail = value;
                OnPropertyChanged();
            }
        }

        private string navn;
        public string Navn
        {
            get { return navn; }
            set
            {
                navn = value;
                OnPropertyChanged();
            }
        }

        private int telefon;
        public int Telefon
        {
            get { return telefon; }
            set
            {
                telefon = value;
                OnPropertyChanged();
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public Kunde(string kundeEmail, string navn, int telefon)
        {
            this.KundeEmail = kundeEmail;
            this.Navn = navn;
            this.Telefon = telefon;
        }
    }
}
