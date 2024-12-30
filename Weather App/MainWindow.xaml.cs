using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using System.Text.Json;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Net.Http;
using System.Security.Policy;
using System.Diagnostics.Metrics;

namespace Weather_App
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            LoadWeatherIcon("https://openweathermap.org/img/wn/03n@2x.png");


        }

        public void LoadWeatherIcon(string imageUrl)
        {

            Dispatcher.Invoke(() =>
            {
                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri(imageUrl, UriKind.Absolute);
                bitmap.EndInit();
                WeatherIcon.Source = bitmap;
            });

        }

        public async Task<(double, double)> GetLocationData()
        {

            string cityName = CityName.Text;
            string stateCode = StateCode.Text;
            int countryCode = 0;
            
            int.TryParse(CountryCode.Text, out countryCode);
            
            string apiKey = "ee225abac35f7c3a380d484737c5bbd8";


            // api url
            string url = $"http://api.openweathermap.org/geo/1.0/direct?q={cityName},{stateCode},{countryCode}&&appid={apiKey}";

            // Http client object to make api calls
            using HttpClient client = new HttpClient();


            // try block to attempt getting api reponse
            try
            {

                // response message obj to hold resp data
                HttpResponseMessage resp = new HttpResponseMessage();

                // makes api call and waits for it
                resp = await client.GetAsync(url);

                // ensures call was successful
                resp.EnsureSuccessStatusCode();

                // takes response data and puts it into a string
                string respData = await resp.Content.ReadAsStringAsync();

                // calls json parser class and maps response to object
                List<LocationData>? locationData = JsonSerializer.Deserialize<List<LocationData>>(respData);

                // if the data is good, we then assign some of the output to the label in the UI
                if (locationData != null && locationData.Count > 0)
                {

                    LocationData location = locationData[0];

                    return (Convert.ToDouble(location.lat), Convert.ToDouble(location.lon));

                }

                else
                {

                    weatherOutput.Content = "Bad API Call";
                    return (0, 0); 

                }


            }

            catch (Exception ex) {
            
                Console.WriteLine(ex);
                return (0, 0);

            }

        }


        public async void GetWeatherData(object sender, RoutedEventArgs e)
        {

            double longitude, lattitude;
            string apiKey = "ee225abac35f7c3a380d484737c5bbd8";

            using HttpClient client = new HttpClient();

            try
            {

                (longitude, lattitude) = await GetLocationData();

                string weatherURL = $"https://api.openweathermap.org/data/2.5/weather?lat={lattitude}&lon={longitude}&appid={apiKey}";

                HttpResponseMessage weatherResp = new HttpResponseMessage();

                weatherResp = await client.GetAsync(weatherURL);

                weatherResp.EnsureSuccessStatusCode();

                string weatherRespData = await weatherResp.Content.ReadAsStringAsync();

                Console.WriteLine(weatherRespData);

                CurrentWeatherData? weatherData = JsonSerializer.Deserialize<CurrentWeatherData>(weatherRespData);

                Console.WriteLine(weatherData);

                if (weatherRespData != null)
                {

                    weatherOutput_Location.Content = $"{CityName.Text}";
                    weatherOutput.Content = $"Current Temp: {weatherData.main.temp}\n\nCurrent Weather: {weatherData.weather[0].main}";


                    await Task.Delay(100);

                    LoadWeatherIcon($"https://openweathermap.org/img/wn/{weatherData.weather[0].icon}@2x.png");

                }

                else
                {

                    weatherOutput.Content = "No data found";

                }

            }

            catch (Exception ex)
            {

                Console.WriteLine(ex);

            }

        }

    }
}