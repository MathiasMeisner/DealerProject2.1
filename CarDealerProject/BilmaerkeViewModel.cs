using BilmærkeViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace CarDealerProject
{
    /*public partial class Booking
    {
        public int bookingID { get; set; }
        public int forhandlerID { get; set; }
        public string kundeEmail { get; set; }
        public int bilID { get; set; }
        public int medarbejderID { get; set; }
        public DateTime bookTime { get; set; }
    }*/

    public class BilmaerkeViewModel
    {
        //Ensure tha this is the same URL as applied under 
        //Properties->Web->Project URL in the web service project 
        const string serverUrl = "http://localhost:53751/";
        
        public int bookingID;
        public int forhandlerID;
        public string kundeEmail;
        public string kundeNavn;
        public string bilModel;
        public string forhandlerNavn;
        public int bilID;
        public int medarbejderID;
        public DateTime bookTime;

        public ObservableCollection<Bil> OC_bilmaerker { get; set; }
        public ObservableCollection<Forhandler> OC_forhandlere { get; set; }
        public ObservableCollection<Booking> OC_bookings { get; set; }

        public Bil SelectedBil { get; set; }
        public Forhandler SelectedForhandler { get; set; }
        public Booking SelectedBooking { get; set; }

        public RelayCommand GemData { get; set; }
        public RelayCommand HentData { get; set; }
        public RelayCommand HentMercedes { get; set; }
        public RelayCommand HentRenault { get; set; }
        public RelayCommand HentDacia { get; set; }
        public RelayCommand HentForhandlere { get; set; }
        public RelayCommand HentBookings { get; set; }
        public RelayCommand AddNyBooking { get; set; }

        public BilmaerkeViewModel()
        {
            OC_bilmaerker = new ObservableCollection<Bil>();
            OC_forhandlere = new ObservableCollection<Forhandler>();
            OC_bookings = new ObservableCollection<Booking>();

            /*//Testdata 
            OC_forhandlere.Add(new Forhandler(1, "Navn", "Adresse", "By", 84848484, "Email"));
            OC_forhandlere.Add(new Forhandler(2, "Navn", "Adresse", "By", 84848484, "Email"));
            OC_forhandlere.Add(new Forhandler(3, "Navn", "Adresse", "By", 84848484, "Email"));*/

            HentData = new RelayCommand(HentAllDataFraDiskAsync);
            HentMercedes = new RelayCommand(HentMercedesDataFraDiskAsync);
            HentRenault = new RelayCommand(HentRenaultDataFraDiskAsync);
            HentDacia = new RelayCommand(HentDaciaDataFraDiskAsync);

            HentForhandlere = new RelayCommand(HentForhandlereFraDiskAsync);
            HentBookings = new RelayCommand(HentBookingsFraDiskAsync);
            AddNyBooking = new RelayCommand(AddBooking);
        }

        private void HentAllDataFraDiskAsync()
        {
            HentDataFraDiskAsync("");
        }

        private void HentMercedesDataFraDiskAsync()
        {
            HentDataFraDiskAsync("Mercedes");
        }

        private void HentRenaultDataFraDiskAsync()
        {
            HentDataFraDiskAsync("Renault");
        }

        private void HentDaciaDataFraDiskAsync()
        {
            HentDataFraDiskAsync("Dacia");
        }

        private void HentForhandlereFraDiskAsync()
        {
            HentAllDataFraDiskAsync();
        }

        private void HentBookingsFraDiskAsync()
        {
            HentAllDataFraDiskAsync();
        }

        private void HentDataFraDiskAsync(string BilMaerke)
        {
            OC_bilmaerker.Clear();
            List<Bil> nyListe = new List<Bil>();
            //nyListe = await PersistencyService.HentDataFraDiskAsyncPS();

            OC_forhandlere.Clear();
            List<Forhandler> forhandlerListe = new List<Forhandler>();

            OC_bookings.Clear();
            List<Booking> bookingListe = new List<Booking>();

            //Setup client handler
            HttpClientHandler handler = new HttpClientHandler();
            handler.UseDefaultCredentials = true;

            using (var client = new HttpClient(handler))
            {
                //Initialize client
                client.BaseAddress = new Uri(serverUrl);
                client.DefaultRequestHeaders.Clear();

                //Request JSON format
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    //Get all the flower orders from the database
                    var flowerOrderResponse = client.GetAsync("api/bils").Result;
                    var forhandlerOrderResponse = client.GetAsync("api/forhandlers").Result;
                    var bookingOrderResponse = client.GetAsync("api/bookings").Result;

                    //Check response -> throw exception if NOT successful
                    flowerOrderResponse.EnsureSuccessStatusCode();
                    forhandlerOrderResponse.EnsureSuccessStatusCode();
                    bookingOrderResponse.EnsureSuccessStatusCode();

                    //Get the hotels as a ICollection
                    var orders = flowerOrderResponse.Content.ReadAsAsync<ICollection<Bil>>().Result;
                    var orders2 = forhandlerOrderResponse.Content.ReadAsAsync<ICollection<Forhandler>>().Result;
                    var orders3 = bookingOrderResponse.Content.ReadAsAsync<ICollection<Booking>>().Result;

                    foreach (var order in orders)
                    {
                        if (order.BilMaerke == BilMaerke)
                        this.OC_bilmaerker.Add(new Bil(order.BilID, order.ForhandlerID, order.BilMaerke, order.BilModel, order.BilUdstyr, order.BilMotor));
                    }

                    foreach (var order in orders2)
                    {
                        this.OC_forhandlere.Add(new Forhandler(order.ForhandlerID, order.ForhandlerNavn, order.ForhandlerAdresse, order.ForhandlerBy, order.ForhandlerTelefon, order.ForhandlerEmail));
                    }

                    foreach (var order in orders3)
                    {
                        this.OC_bookings.Add(new Booking(order.KundeNavn, order.KundeEmail, order.BilModel, order.ForhandlerNavn, order.BookTime));
                    }
                }
                catch
                {

                }
            }

            /*public void SelectBilMaerke()
            {
                if 
            }*/
        }

        public void AddBooking()
        {
            Booking booking = new Booking(kundeNavn, kundeEmail, bilModel, forhandlerNavn,  bookTime); 

            OC_bookings.Add(booking);

            //Setup client handler
            HttpClientHandler handler = new HttpClientHandler();
            handler.UseDefaultCredentials = true;

            using (var client = new HttpClient(handler))
            {
                //Initialize client
                client.BaseAddress = new Uri(serverUrl);
                client.DefaultRequestHeaders.Clear();

                //Request JSON format
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    Booking fo = new Booking(kundeNavn, kundeEmail, bilModel, forhandlerNavn, DateTime.Now);
                    //Get all the flower orders from the database
                    var bookingOrderResponse = client.PostAsJsonAsync<Booking>("api/bookings", fo).Result;

                    //Check response -> throw exception if NOT successful
                    bookingOrderResponse.EnsureSuccessStatusCode();

                    //Get the hotels as a ICollection
                    var orders3 = bookingOrderResponse.Content.ReadAsAsync<Booking>().Result;

                    //SletSelectedBlomst.RaiseCanExecuteChanged();
                }
                catch
                {

                }
            }
        }
    }
}