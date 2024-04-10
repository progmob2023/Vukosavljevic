namespace WeatherApp;

public partial class MainPage : ContentPage
{
    private const string ApiKey = "bf3375071b3286d4c7997a194f6196d5"; // Replace with your OpenWeatherMap API key

    public MainPage()
    {
        InitializeComponent();
    }

    private async void OnGetWeatherClicked(object sender, EventArgs e)
    {
        string cityName = cityEntry.Text;

        if (!string.IsNullOrEmpty(cityName))
        {
            WeatherData weatherData = await GetWeatherData(cityName);

            if (weatherData != null)
            {
                temperatureLabel.Text = $"Temperature: {weatherData.Main.Temperature}°C";
                pressureLabel.Text = $"Pressure: {weatherData.Main.Pressure} hPa";
                humidityLabel.Text = $"Humidity: {weatherData.Humidity}%";
                descriptionLabel.Text = $"Description: {weatherData.Weather[0].Description}";
                windSpeedLabel.Text = $"Wind Speed: {weatherData.Wind.Speed} m/s";

                // Update other labels with additional weather details as needed
            }
            else
            {
                // Handle error or inform user that data couldn't be retrieved
            }
        }
        else
        {
            // Inform user to enter a city name
        }
    }

    private async Task<WeatherData> GetWeatherData(string cityName)
    {
        try
        {
            HttpClient client = new HttpClient();
            string apiUrl = $"https://api.openweathermap.org/data/2.5/weather?q={cityName}&appid={ApiKey}&units=metric";
            string jsonResponse = await client.GetStringAsync(apiUrl);

            WeatherData weatherData = Newtonsoft.Json.JsonConvert.DeserializeObject<WeatherData>(jsonResponse);

            return weatherData;
        }
        catch (Exception ex)
        {
            // Handle exception, log, or return null
            return null;
        }
    }
}

