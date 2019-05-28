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

namespace UniversalConverterApp
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

        private void ComboBoxConverter_OnLoaded(object sender, RoutedEventArgs e)
        {
            ComboBoxConverter.Items.Add("SomeItem 1");
            ComboBoxConverter.Items.Add("SomeItem 2");
            ComboBoxConverter.Items.Add("SomeItem 3");
        }

        private void ComboBoxConverter_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            InputValueTextBox.Text = "selected item " + ComboBoxConverter.SelectedIndex;
        }
    }
}
