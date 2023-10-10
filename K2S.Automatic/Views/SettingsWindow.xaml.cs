using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace K2S.Automatic.Views
{
    /// <summary>
    /// SettingsWindow.xaml 的交互逻辑
    /// </summary>
    public partial class SettingsWindow : Window
    {
        public SettingsWindow()
        {
            InitializeComponent();
        }

        private void RadioButton_Click(object sender, RoutedEventArgs e)
        {
            this.frame.Navigate(
                new Uri("pack://application:,,,/K2S.Automatic;component/Views/SettingsPage.xaml#"
                + (sender as RadioButton).Tag.ToString(), UriKind.RelativeOrAbsolute));
        }
    }
}
