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

        public Bil SelectedBilMaerke { get; set; }

        public RelayCommand GemData { get; set; }
        public RelayCommand HentData { get; set; }

        public BilmaerkeViewModel()
        {
            OC_bilmaerker = new ObservableCollection<Bil>();

            //Testdata 
            OC_bilmaerker.Add(new Bil(1, 1, "Renault", "Model1", "Udstyr1", "Motor1"));
            OC_bilmaerker.Add(new Bil(2, 2, "Mercedes", "Model2", "Udstyr2", "Motor2"));
            OC_bilmaerker.Add(new Bil(3, 3, "Mærke1", "Model3", "Udstyr3", "Motor3"));

            HentData = new RelayCommand(HentDataFraDiskAsync);
        }

        /// <summary>
        /// Henter en json fil fra disken 
        /// </summary>
        private void HentDataFraDiskAsync()
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
                        if (order.BilMaerke == "Mercedes")
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