using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net;
using Newtonsoft.Json;

using Xamarin.Forms;

namespace proyectoMoviles.views
{
    public partial class ListadoMarvel : ContentPage
    {
        public ListadoMarvel()
        {
            InitializeComponent();
        }

// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
        public class Comics
        {
            public int available { get; set; }
            public string collectionURI { get; set; }
            public List<Item> items { get; set; }
            public int returned { get; set; }
        }

        public class Data
        {
            public int offset { get; set; }
            public int limit { get; set; }
            public int total { get; set; }
            public int count { get; set; }
            public List<Result> results { get; set; }
        }

        public class Events
        {
            public int available { get; set; }
            public string collectionURI { get; set; }
            public List<Item> items { get; set; }
            public int returned { get; set; }
        }

        public class Item
        {
            public string resourceURI { get; set; }
            public string name { get; set; }
            public string type { get; set; }
        }

        public class Result
        {
            public int id { get; set; }
            public string name { get; set; }
            public string description { get; set; }
            public DateTime modified { get; set; }
            public Thumbnail thumbnail { get; set; }
            public string resourceURI { get; set; }
            public Comics comics { get; set; }
            public Series series { get; set; }
            public Stories stories { get; set; }
            public Events events { get; set; }
            public List<Url> urls { get; set; }
        }

        public class Root
        {
            public int code { get; set; }
            public string status { get; set; }
            public string copyright { get; set; }
            public string attributionText { get; set; }
            public string attributionHTML { get; set; }
            public string etag { get; set; }
            public Data data { get; set; }
        }

        public class Series
        {
            public int available { get; set; }
            public string collectionURI { get; set; }
            public List<Item> items { get; set; }
            public int returned { get; set; }
        }

        public class Stories
        {
            public int available { get; set; }
            public string collectionURI { get; set; }
            public List<Item> items { get; set; }
            public int returned { get; set; }
        }

        public class Thumbnail
        {
            public string path { get; set; }
            public string extension { get; set; }
        }

        public class Url
        {
            public string type { get; set; }
            public string url { get; set; }
        }

        private async void Button_Clicked(System.Object sender, System.EventArgs e)
        {
            var request = new HttpRequestMessage();
            request.RequestUri = new Uri("https://gateway.marvel.com:443/v1/public/characters?ts=1&apikey=ef0032a6dc394ad08a9a92d945c18298&hash=bed1f6d38c9a8e4c317e237f3c5f1cd1");
            request.Method = HttpMethod.Get;
            request.Headers.Add("accpet", "application/json");
            var client = new HttpClient();
            HttpResponseMessage response = await client.SendAsync(request);
           
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    var resultado = JsonConvert.DeserializeObject<Item>(content);

                Console.WriteLine(resultado.resourceURI);
                //ListDemo.ItemsSource = (resultado.resourceURI);

                }          
         
        }
    }
}

