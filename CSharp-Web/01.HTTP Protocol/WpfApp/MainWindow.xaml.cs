using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
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

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        //Event Handler - method invoked when event happens
        private async void Button_Click(object sender, RoutedEventArgs e)
        {
           ShowImageAsync(image1, "https://http.dog/200.jpg");
           ShowImageAsync(image2, "https://http.dog/static/img/large/101.webp");
           ShowImageAsync(image3, "https://http.dog/static/img/large/203.webp");
           ShowImageAsync(image4, "https://http.dog/static/img/large/218.webp");
           ShowImageAsync(image5, "https://http.dog/static/img/large/405.webp");
           ShowImageAsync(image6, "https://http.dog/static/img/large/505.webp");
        }

        private async Task ShowImageAsync(Image image, string url)
        {
            //This method shall download the image
            HttpClient httpClient = new HttpClient();
            var responce = await httpClient.GetAsync(url);
            byte[] imageBytes = await responce.Content.ReadAsByteArrayAsync();
            image.Source = LoadImage(imageBytes);
        }

        private static BitmapImage LoadImage(byte[] imageData)
        {
            if (imageData == null || imageData.Length == 0) return null;
            var image = new BitmapImage();
            using (var mem = new MemoryStream(imageData))
            {
                mem.Position = 0;
                image.BeginInit();
                image.CreateOptions = BitmapCreateOptions.PreservePixelFormat;
                image.CacheOption = BitmapCacheOption.OnLoad;
                image.UriSource = null;
                image.StreamSource = mem;
                image.EndInit();
            }
            image.Freeze();
            return image;
        }
    }
}
