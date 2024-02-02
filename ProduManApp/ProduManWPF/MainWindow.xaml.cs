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
using ProduManWPF.ViewModels;

namespace ProduManWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private IColorEditor colorEditor = new ColorEditor();
        
        public MainWindow()
        {
            InitializeComponent();
            var color = colorEditor.GetColor();
            this.rectangle.Fill = new SolidColorBrush(color);
            sliderR.Value = color.R;
            sliderG.Value = color.G;
            sliderB.Value = color.B;
        }

        private Color rectangleColor
        {
            get { return (rectangle.Fill as SolidColorBrush).Color; }
            set { (rectangle.Fill as SolidColorBrush).Color = value; }
        }

        private void Slider_OnValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            rectangleColor = Color.FromRgb(
                (byte)sliderR.Value,
                (byte)sliderG.Value,
                (byte)sliderB.Value);
        }

        private void MainWindow_OnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                this.Close();
            }
        }

        private void MainWindow_OnClosed(object? sender, EventArgs e)
        {
            colorEditor colorEditor = this.FindResource("colorEditor") as ColorEditor;
            colorEditor.Save();
        }
    }
}