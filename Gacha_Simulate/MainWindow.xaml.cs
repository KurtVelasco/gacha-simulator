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



namespace Gacha_Simulate
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ReadData rd = new ReadData();
        Gacha gc = new Gacha();
        public MainWindow()
        {
            
            InitializeComponent();
            gc.takedata(rd.OperatorDatabase);
            gc.SetRarity();
            rd.ClearDynamic();
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

        private void WriteSquare(string opname, int x , int y)
        {

            //Planning on adding an offline version *RIP file size
            //For now all images will be taken on github @Ace-Ship
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

            RollScreen.Children.Add(img);
        }
    }
}
