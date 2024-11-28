using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
using System.Windows.Shapes;

namespace Text_Editor___Dom_Style
{
    /// <summary>
    /// Interaction logic for OptionsPane.xaml
    /// </summary>
    public partial class OptionsPane : Window
    {


        public OptionsPane()
        {
            InitializeComponent();

            ThemesChoice.Items.Add("Midnight (Purple)");
            ThemesChoice.Items.Add("Sunset (Orange)");
            ThemesChoice.Items.Add("Nature (Green)");
            ThemesChoice.Items.Add("Blossom (Pink)");
            ThemesChoice.Items.Add("Sky Light (Blue)");

        }


        private void ApplyChanges(object sender, RoutedEventArgs e)
        {

            if (ThemesChoice.SelectedItem is string selectedTheme)
            {

                ApplyTheme(selectedTheme);

            }

            bool tabsEnabled = MultiTabChoice.IsChecked ?? false;

            UpdateTabSetting(tabsEnabled);

            MessageBox.Show("Changes applied!", "Confirmation", MessageBoxButton.OK, MessageBoxImage.Information);

            Close();


        }

        private void ApplyTheme(string theme)
        {


        }

        private void UpdateTabSetting(bool isEnabled)
        {


        }


    }


    
}
