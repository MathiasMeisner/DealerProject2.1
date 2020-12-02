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
    public class BilmærkeViewModel
    {
        /*private string navnBlomst;
        private int antalBlomst;
        private string farveBlomst;*/

        //Ensure tha this is the same URL as applied under 
        //Properties->Web->Project URL in the web service project 
        const string serverUrl = "http://localhost:53751/";

        public ObservableCollection<Bil> OC_bilmærker { get; set; }

        /*public string NavnBlomst { get => navnBlomst; set => navnBlomst = value; }
        public int AntalBlomst { get => antalBlomst; set => antalBlomst = value; }
        public string FarveBlomst { get => farveBlomst; set => farveBlomst = value; }*/

        //public OrdreBlomst SelectedOrdreBlomst { get; set; }

        //public RelayCommand AddNyBlomst { get; set; }
        //public RelayCommand SletSelectedBlomst { get; set; }
        public RelayCommand GemData { get; set; }
        public RelayCommand HentData { get; set; }

        public BilmærkeViewModel()
        {
            OC_bilmærker = new ObservableCollection<Bil>();

            /*//Testdata 
            OC_blomster.Add(new OrdreBlomst("Tulipan", 4, "Rød"));
            OC_blomster.Add(new OrdreBlomst("Tulipan", 3, "Hvid"));
            OC_blomster.Add(new OrdreBlomst("Tulipan", 2, "Gul"));*/

            /*AddNyBlomst = new RelayCommand(AddBlomst);
            SletSelectedBlomst = new RelayCommand(SletBlomst, canDeleteBlomsterListe);

            SelectedOrdreBlomst = new OrdreBlomst();*/

            //GemData = new RelayCommand(GemDataTilDiskAsync);
            HentData = new RelayCommand(HentDataFraDiskAsync);
            //DanData();
        }


        /*/// <summary>
        /// metode til at tilføje en ny ordreblomst til listen
        /// </summary>
        public void AddBlomst()
        {
            OrdreBlomst oBlomst = new OrdreBlomst(NavnBlomst, AntalBlomst, FarveBlomst);

            OC_blomster.Add(oBlomst);

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
                    FlowerOrder fo = new FlowerOrder() { FlowerName = NavnBlomst, Quantity = AntalBlomst, Color = FarveBlomst };
                    //Get all the flower orders from the database
                    var flowerOrderResponse = client.PostAsJsonAsync<FlowerOrder>("api/flowerorders", fo).Result;

                    //Check response -> throw exception if NOT successful
                    flowerOrderResponse.EnsureSuccessStatusCode();

                    //Get the hotels as a ICollection
                    var flowerOrder = flowerOrderResponse.Content.ReadAsAsync<FlowerOrder>().Result;

                    SletSelectedBlomst.RaiseCanExecuteChanged();
                }
                catch
                {

                }
            }
        }*/

        /*private void SletBlomst()
        {
            OC_blomster.Remove(SelectedOrdreBlomst);
            SletSelectedBlomst.RaiseCanExecuteChanged();
        }*/

        /*private bool canDeleteBlomsterListe()
        {
            return OC_blomster.Count > 0;
        }*/

        /// <summary>
        /// Gemmer json data fra liste i localfolder
        /// </summary>
        /*private async void GemDataTilDiskAsync()
        {
            //this.jsonBilmærker = GetJson();

            //StorageFile file = await localfolder.CreateFileAsync(filnavn, CreationCollisionOption.ReplaceExisting);

            //await FileIO.WriteTextAsync(file, this.jsonBilmærker);

            // await FileIO.WriteTextAsync(file, GetJson());
            /*SletSelectedBlomst.RaiseCanExecuteChanged();
        }*/

        /// <summary>
        /// Henter en json fil fra disken 
        /// </summary>
        private void HentDataFraDiskAsync()
        {
            OC_bilmærker.Clear();
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
                    var orders = flowerOrderResponse.Content.ReadAsAsync<ICollection<Bildb>>().Result;

                    foreach (var order in orders)
                    {

                        this.OC_bilmærker.Add(new Bil(order.BilID, order.ForhandlerID, order.BilMærke, order.BilModel, order.BilUdstyr, order.BilMotor));
                    }

                    /*foreach (var blomst in nyListe)
                    {
                        this.OC_blomster.Add(blomst);
                    }*/
                    //SletSelectedBlomst.RaiseCanExecuteChanged();
                }
                catch
                {

                }
            }

            //StorageFile file = await localfolder.GetFileAsync(filnavn);
            //string jsonText = await FileIO.ReadTextAsync(file);
            //this.OC_blomster.Clear();
            //IndsætJson(jsonText);
        }

    }
}