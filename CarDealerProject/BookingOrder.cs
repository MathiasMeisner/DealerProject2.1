using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CarDealerProject
{
    public class Booking : INotifyPropertyChanged
    {
        private int bookingID;
        public int BookingID
        {
            get { return bookingID; }
            set
            {
                bookingID = value;
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

        private int bilID;
        public int BilID
        {
            get { return bilID; }
            set
            {
                bilID = value;
                OnPropertyChanged();
            }
        }

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

        private DateTime bookTime;
        public DateTime BookTime
        {
            get { return bookTime; }
            set
            {
                bookTime = value;
                OnPropertyChanged();
            }
        }

        private string kundeNavn;
        public string KundeNavn
        {
            get { return kundeNavn; }
            set
            {
                kundeNavn = value;
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

        private string bilModel;
        public string BilModel
        {
            get { return bilModel; }
            set
            {
                bilModel = value;
                OnPropertyChanged();
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public Booking(int bookingID, string kundeNavn, string kundeEmail, string bilModel, string forhandlerNavn, DateTime bookTime)
        {
            this.BookingID = bookingID;
            this.KundeNavn = kundeNavn;
            this.KundeEmail = kundeEmail;
            this.BilModel = bilModel;
            this.ForhandlerNavn = forhandlerNavn;
            this.BookTime = bookTime;
        }
    }
}