using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CurrentWeatherChecker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly GetWeatherAPI _weatherApi;

        public MainWindow()
        {
            InitializeComponent();
            _weatherApi = new GetWeatherAPI();
        }

        private async void CheckWeatherButton_Click(object sender, RoutedEventArgs e)
        {
            string city = CityTextBox.Text;
            string weatherData = await _weatherApi.GetWeatherDataAsync(city);
            WeatherResultTextBlock.Text = weatherData;
        }
    }
}
