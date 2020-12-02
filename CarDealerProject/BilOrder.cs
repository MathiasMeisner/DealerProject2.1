using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CarDealerProject
{
    public partial class Bildb
    {
        public int BilID { get; set; }
        public int ForhandlerID { get; set; }
        public string BilMærke { get; set; }
        public string BilModel { get; set; }
        public string BilUdstyr { get; set; }
        public string BilMotor { get; set; }
    }

    public class Bil : INotifyPropertyChanged
    {
        // TEST

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

        private string bilMærke;
        public string BilMærke
        {
            get { return BilMærke; }
            set
            {
                bilMærke = value;
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

        private string bilUdstyr;
        public string BilUdstyr
        {
            get { return bilUdstyr; }
            set
            {
                bilUdstyr = value;
                OnPropertyChanged();
            }
        }

        private string bilMotor;
        public string BilMotor
        {
            get { return bilMotor; }
            set
            {
                bilMotor = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public Bil(int bilID, int forhandlerID, string bilMærke, string bilModel, string bilUdstyr, string bilMotor)
        {
            this.BilID = bilID;
            this.ForhandlerID = forhandlerID;
            this.BilMærke = bilMærke;
            this.BilModel = bilModel;
            this.BilUdstyr = bilUdstyr;
            this.BilMotor = bilMotor;
        }
    }
}