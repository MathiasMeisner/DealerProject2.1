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

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public Booking(int bookingID, int forhandlerID, string kundeEmail, int bilID, int medarbejderID, DateTime bookTime)
        {
            this.BookingID = bookingID;
            this.ForhandlerID = forhandlerID;
            this.KundeEmail = kundeEmail;
            this.BilID = bilID;
            this.MedarbejderID = medarbejderID;
            this.BookTime = bookTime;
        }
    }
}