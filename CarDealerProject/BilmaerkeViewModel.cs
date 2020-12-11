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
    public class BilmaerkeViewModel
    {
        //Ensure tha this is the same URL as applied under 
        //Properties->Web->Project URL in the web service project 
        const string serverUrl = "http://localhost:53751/";

        public ObservableCollection<Bil> OC_bilmaerker { get; set; }
        public ObservableCollection<Forhandler> OC_forhandlere { get; set; }

        public Bil SelectedBil { get; set; }
        public Forhandler SelectedForhandler { get; set; }

        public RelayCommand GemData { get; set; }
        public RelayCommand HentData { get; set; }
        public RelayCommand HentMercedes { get; set; }
        public RelayCommand HentRenault { get; set; }
        public RelayCommand HentDacia { get; set; }

        public BilmaerkeViewModel()
        {
            OC_bilmaerker = new ObservableCollection<Bil>();
            OC_forhandlere = new ObservableCollection<Forhandler>();

            //Testdata 
            OC_forhandlere.Add(new Forhandler(1, "Navn", "Adresse", "By", 84848484, "Email"));
            OC_forhandlere.Add(new Forhandler(2, "Navn", "Adresse", "By", 84848484, "Email"));
            OC_forhandlere.Add(new Forhandler(3, "Navn", "Adresse", "By", 84848484, "Email"));

            HentData = new RelayCommand(HentAllDataFraDiskAsync);
            HentMercedes = new RelayCommand(HentMercedesDataFraDiskAsync);
            HentRenault = new RelayCommand(HentRenaultDataFraDiskAsync);
            HentDacia = new RelayCommand(HentDaciaDataFraDiskAsync);
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

        private void HentDataFraDiskAsync(string BilMaerke)
        {
            OC_bilmaerker.Clear();
            List<Bil> nyListe = new List<Bil>();
            //nyListe = await PersistencyService.HentDataFraDiskAsyncPS();

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

                    //Check response -> throw exception if NOT successful
                    flowerOrderResponse.EnsureSuccessStatusCode();

                    //Get the hotels as a ICollection
                    var orders = flowerOrderResponse.Content.ReadAsAsync<ICollection<Bil>>().Result;

                    foreach (var order in orders)
                    {
                        if (order.BilMaerke == BilMaerke)
                        this.OC_bilmaerker.Add(new Bil(order.BilID, order.ForhandlerID, order.BilMaerke, order.BilModel, order.BilUdstyr, order.BilMotor));
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
    }
}