using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CurrentWeatherChecker
{
    internal class GetWeatherAPI
    {
        private const string apiKey = "4f0f7751f19cf9730b7464eebb0909b7"; // Содержит API ключ погодного сервиса

        public async Task<string> GetWeatherDataAsync(string city)
        {
            using (var client = new HttpClient())
            {
                try
                {
                    // Получаем ответ от API
                    string url = $"https://api.openweathermap.org/data/2.5/weather?q={city}&APPID={apiKey}&units=metric&lang=ru";
                    HttpResponseMessage response = await client.GetAsync(url);
                    response.EnsureSuccessStatusCode();
                    string responseBody = await response.Content.ReadAsStringAsync();

                    // Извлекаем данные из JSON-ответа
                    JObject json = JObject.Parse(responseBody);
                    double temperature = (double)json["main"]["temp"];
                    string description = (string)json["weather"][0]["description"];
                    double windSpeed = (double)json["wind"]["speed"];

                    // Выводим необходимые для пользователя погодные данные
                    return $"Температура: {temperature}°C, Описание: {description}, Скорость ветра: {windSpeed} м/с";
                }
                catch (HttpRequestException e)
                {
                    return $"Ошибка при получении данных о погоде. {e.Message}";
                }
            }
        }
    }
}