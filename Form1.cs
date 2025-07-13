using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http.Headers;
using Newtonsoft.Json.Linq;

namespace Project13_WeatherAppRapid
{
    public partial class Form1: Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://open-weather13.p.rapidapi.com/city?city=istanbul&lang=EN"),
                Headers =
                {
                     { "x-rapidapi-key", "adf14d4d98msh51e3e71d526a830p119691jsnab7eb2c6a8a3" },
                     { "x-rapidapi-host", "open-weather13.p.rapidapi.com" },
                },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();

                var json = JObject.Parse(body);
                var fahrenheit = json["main"]["temp"].ToString();
                var wind = json["wind"]["speed"].ToString();
                var humidity = json["main"]["humidity"].ToString();
 
                lblFahrenheit.Text = fahrenheit;
                lblWind.Text = wind;
                lblHumidity.Text = humidity;
 
                double celsius = (double.Parse(fahrenheit) - 32);
                double celsiusValue = celsius / 1.8;
                lblCelsius.Text = celsiusValue.ToString("0.00"); // virgülden sonra 2 sayi almayi saglar
            }
        }

        private void lblWind_Click(object sender, EventArgs e)
        {

        }
    }
}
