using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Globalization;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using proyectoMoviles.models;
using System.Linq;

namespace proyectoMoviles.views
{
    public partial class ListadoMarvel : ContentPage
    {
        public ListadoMarvel()
        {
            InitializeComponent();
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

                    result resultado = JsonConvert.DeserializeObject <result>(content);
                List<Result> result = new List<Result>();

                foreach(var item in resultado.data.results)
                {
                    result.Add(item);
                    
                }
                
                    ListDemo.ItemsSource = new ObservableCollection <Result>(result);


            





            }          
        }
    }
}

