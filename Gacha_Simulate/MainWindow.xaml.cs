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
            Automate_Roll.Interval = new TimeSpan(0, 0, 0, 0, 100);
            Automate_Roll.Tick += Automated;
            InitializeComponent();
            gc.takedata(rd.OperatorDatabase);
            gc.SetRarity();
            rd.ClearDynamic();
            Automate_Roll.Start();
        }

        private void Automated(object sender, EventArgs e)
        {
            List<string> TenPull = new List<string>();
            TenPull = gc.Generic_Simulate();
            int x = 0;
            int y = 0;
            RollScreen.Children.Clear();
            foreach (string ops in TenPull)
            {
                WriteSquare(ops, x, y);
                x += 100;
            }
        }

        private void SimulateGeneric(object sender, RoutedEventArgs e)
        {
            List<string> TenPull =  new List<string>();
            TenPull = gc.Generic_Simulate();
            int x = 0;
            int y = 0;
            RollScreen.Children.Clear();
            foreach(string ops in TenPull)
            {
                WriteSquare(ops,x ,y);
                x += 100;
            }
            //string output = string.Join(Environment.NewLine,gc.Generic_Simulate());
            //Displaypulls.Document.Blocks.Clear();
            //Displaypulls.Document.Blocks.Add(new Paragraph(new Run(output)));
        }


        private void WriteSquare(string opname, int x, int y)
        {

            Image img = new Image();
            BitmapImage bmp = new BitmapImage(new Uri("https://raw.githubusercontent.com/Aceship/Arknight-Images/main/characters/" + opname + "_1.png"));
            img.Source = bmp;
            img.Width = 100;
            img.Height = 100;
            img.VerticalAlignment = VerticalAlignment.Top;
            img.HorizontalAlignment = HorizontalAlignment.Left;
            img.Margin = new Thickness(x, 0, 0, 0);
            //img.Unloaded += (s, e) => bmp.UriSource = null;
            RollScreen.Children.Add(img);
            count.Content = imageCache.Count();
        }
        //private void WriteSquare(string opname, int x, int y)
        //{
        //    Image img = new Image();
        //    BitmapImage bmp = new BitmapImage(new Uri("OpPictures/" + opname + ".png", UriKind.Relative));
        //    img.Source = bmp;
        //    img.Width = 100;
        //    img.Height = 100;
        //    img.VerticalAlignment = VerticalAlignment.Top;
        //    img.HorizontalAlignment = HorizontalAlignment.Left;
        //    img.Margin = new Thickness(x, 0, 0, 0);
        //    img.Unloaded += (s, e) => bmp.UriSource = null;
        //    RollScreen.Children.Add(img);
        //    count.Content = imageCache.Count();
        //}

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
