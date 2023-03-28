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
            WriteSquare();
        }

        private void SimulateGeneric(object sender, RoutedEventArgs e)
        {
            string output = string.Join(Environment.NewLine,gc.Generic_Simulate());
            Displaypulls.Document.Blocks.Clear();
            Displaypulls.Document.Blocks.Add(new Paragraph(new Run(output)));
        }

        private void WriteSquare()
        {
            // Create a BitmapImage with a white square image
            BitmapImage bmp = new BitmapImage();
            bmp.BeginInit();
            bmp.UriSource = new Uri("https://raw.githubusercontent.com/Aceship/Arknight-Images/main/characters/char_278_orchid_1.png");
            bmp.EndInit();

            // Create an Image element and set its properties
            Image img = new Image();
            img.Source = bmp;
            img.Width = 100;
            img.Height = 100    ;
            img.VerticalAlignment = VerticalAlignment.Top;
            img.HorizontalAlignment = HorizontalAlignment.Left;
            img.Margin = new Thickness(0, 0, 0, 0);

            // Add the Image to the Screen canvas
            Screen.Children.Add(img);
        }
    }
}
