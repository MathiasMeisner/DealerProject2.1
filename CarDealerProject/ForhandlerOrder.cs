using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CarDealerProject
{
    public class Forhandler : INotifyPropertyChanged
    {
        private int forhandlerID;
        public int ForhandlerID
        {
            get { return forhandlerID; }
            set
            {
                forhandlerID = value;
                OnPropertyChanged();
            }
        }

        private string forhandlerNavn;
        public string ForhandlerNavn
        {
            get { return forhandlerNavn; }
            set
            {
                forhandlerNavn = value;
                OnPropertyChanged();
            }
        }

        private string forhandlerAdresse;
        public string ForhandlerAdresse
        {
            get { return forhandlerAdresse; }
            set
            {
                forhandlerAdresse = value;
                OnPropertyChanged();
            }
        }

        private string forhandlerBy;
        public string ForhandlerBy
        {
            get { return forhandlerBy; }
            set
            {
                forhandlerBy = value;
                OnPropertyChanged();
            }
        }

        private int forhandlerTelefon;
        public int ForhandlerTelefon
        {
            get { return forhandlerTelefon; }
            set
            {
                forhandlerTelefon = value;
                OnPropertyChanged();
            }
        }

        private string forhandlerEmail;
        public string ForhandlerEmail
        {
            get { return forhandlerEmail; }
            set
            {
                forhandlerEmail = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public Forhandler(int forhandlerID, string forhandlerNavn, string forhandlerAdresse, string forhandlerBy, int forhandlerTelefon, string forhandlerEmail)
        {
            this.ForhandlerID = forhandlerID;
            this.ForhandlerNavn = forhandlerNavn;
            this.ForhandlerAdresse = forhandlerAdresse;
            this.ForhandlerBy = forhandlerBy;
            this.ForhandlerTelefon = forhandlerTelefon;
            this.ForhandlerEmail = forhandlerEmail;
        }
    }
}
