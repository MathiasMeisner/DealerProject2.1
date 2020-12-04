using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CarDealerProject
{
    public class Medarbejder : INotifyPropertyChanged
    {
        private int medarbejderID;
        public int MedarbejderID
        {
            get { return medarbejderID; }
            set
            {
                medarbejderID = value;
                OnPropertyChanged();
            }
        }

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

        private string medarbejderNavn;
        public string MedarbejderNavn
        {
            get { return medarbejderNavn; }
            set
            {
                medarbejderNavn = value;
                OnPropertyChanged();
            }
        }

        private int medarbejderTelefon;
        public int MedarbejderTelefon
        {
            get { return medarbejderTelefon; }
            set
            {
                medarbejderTelefon = value;
                OnPropertyChanged();
            }
        }

        private int superBruger;
        public int SuperBruger
        {
            get { return superBruger; }
            set
            {
                superBruger = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public Medarbejder(int medarbejderID, int forhandlerID, string medarbejderNavn, int medarbejderTelefon, int superBruger)
        {
            this.MedarbejderID = medarbejderID;
            this.ForhandlerID = forhandlerID;
            this.MedarbejderNavn = medarbejderNavn;
            this.MedarbejderTelefon = medarbejderTelefon;
            this.SuperBruger = superBruger;
        }
    }
}