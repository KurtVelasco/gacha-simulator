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
using System.Threading;
using System.Windows.Threading;

namespace Gacha_Simulate
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ReadData rd = new ReadData();
        Gacha gc = new Gacha();
        private Dictionary<string, BitmapImage> imageCache = new Dictionary<string, BitmapImage>();
        DispatcherTimer Automate_Roll = new DispatcherTimer();
        public MainWindow()
        {
            Automate_Roll.Interval = new TimeSpan(0, 0, 0, 0, 250);
            //Automate_Roll.Tick += Automated;
            InitializeComponent();
            gc.takedata(rd.OperatorDatabase);
            gc.SetRarity();
            rd.ClearDynamic();
            Automate_Roll.Start();
        }

        private void Automated(object sender, EventArgs e)
        {
            Dictionary<Double, List<string> > TenPulls = new Dictionary<double, List<string>>();
            List<string> TenPull = new List<string>();
            TenPulls = gc.Generic_Simulate();
            int x = 0;
            int y = 0;
            RollScreen.Children.Clear();
            foreach (KeyValuePair<double,List<string>> ops in TenPulls)
            {
                foreach(string singleops in ops.Value)
                {
                    Offline_Operator_Portrait(singleops, x, y, ops.Key);
                }
                //Offline_Operator_Portrait(, x, y);
                x += 100;
            }
        }

        private void SimulateGeneric(object sender, RoutedEventArgs e)
        {
            Dictionary<Double, List<string>> TenPulls = new Dictionary<double, List<string>>();
            List<string> TenPull = new List<string>();
            TenPulls = gc.Generic_Simulate();
            int x = 0;
            int y = 0;
            RollScreen.Children.Clear();
            foreach (KeyValuePair<double, List<string>> ops in TenPulls)
            {
                foreach (string singleops in ops.Value)
                {
                    Offline_Operator_Portrait(singleops, x, y , ops.Key);
                    x += 105;
                }
                //Offline_Operator_Portrait(, x, y);
            }
        }


        private void Online_Operator_Portrait(string opname, int x, int y, double rarity)
        {
            BitmapImage bmp = new BitmapImage();
            bmp.BeginInit();
            bmp.UriSource = new Uri("https://raw.githubusercontent.com/Aceship/Arknight-Images/main/characters/" + opname + "_1.png");
            bmp.EndInit();
            Image img = new Image();         
            img.Source = bmp;
            img.Width = 100;
            img.Height = 100;
            img.VerticalAlignment = VerticalAlignment.Top;
            img.HorizontalAlignment = HorizontalAlignment.Left;
            img.Margin = new Thickness(x, 0, 0, 0);
            img.Unloaded += (s, e) => bmp.UriSource = null;
            RollScreen.Children.Add(img);
            count.Content = imageCache.Count();
        }
        private void Offline_Operator_Portrait(string opname, int x, int y, double rarity)
        {
            Border bdr = new Border();
            bdr.Height = 102;
            bdr.Width = 102;
            bdr.VerticalAlignment = VerticalAlignment.Top;
            bdr.HorizontalAlignment = HorizontalAlignment.Left;
            switch (rarity)
            {
                case 0.02:
                    bdr.BorderBrush = new SolidColorBrush(Colors.Orange);
                    break;
                case 0.08:
                    bdr.BorderBrush = new SolidColorBrush(Colors.Yellow);
                    break;
                case 0.50:
                    bdr.BorderBrush = new SolidColorBrush(Colors.Blue);
                    break;
                case 0.40:
                    bdr.BorderBrush = new SolidColorBrush(Colors.Gray);
                    break;

            }
            bdr.CornerRadius = new CornerRadius(5);
            bdr.BorderThickness = new Thickness(5);
            bdr.Margin = new Thickness(x, 0, 0, 0);
            RollScreen.Children.Add(bdr);

            Image img = new Image();
            BitmapImage bmp = new BitmapImage(new Uri("OpPictures/" + opname + ".png", UriKind.Relative));
            img.Source = bmp;
            img.Width = 95;
            img.Height = 95;
            img.VerticalAlignment = VerticalAlignment.Top;
            img.HorizontalAlignment = HorizontalAlignment.Left;           
            img.Margin = new Thickness(x, 0, 0, 0);
            img.Unloaded += (s, e) => bmp.UriSource = null;
            RollScreen.Children.Add(img);
            count.Content = imageCache.Count();
        }

        private void ClearCache(object sender, RoutedEventArgs e)
        {
            Automate_Roll.Stop();
        }

  

        //if (!imageCache.ContainsKey(opname))
        //{

        //    BitmapImage bmp = new BitmapImage();
        //    bmp.BeginInit();
        //    bmp.CacheOption = BitmapCacheOption.OnLoad; // Load the image immediately to avoid memory leaks
        //    bmp.UriSource = new Uri("https://raw.githubusercontent.com/Aceship/Arknight-Images/main/characters/" + opname + "_1.png");
        //    bmp.EndInit();
        //    imageCache.Add(opname, bmp);
        //}
    }
}
