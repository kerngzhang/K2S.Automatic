using K2S.Automatic.Base;
using K2S.Automatic.ViewModels;
using K2S.Automatic.Views;
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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace K2S.Automatic
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MainViewModel mainViewModel = new MainViewModel();
        public Command DetailCommand { get; set; }
        public Command GoBackCommand { get; set; }
        public Command SettingsCommand { get; set; }
        public MainWindow()
        {
            InitializeComponent();

            btnClose.Click += (s, e) =>
            {
                this.Close();
            };

            this.DataContext = mainViewModel;
            mainViewModel.PageContent = new MonitorView();

            DetailCommand = new Command(DoDetailCommand);
            GoBackCommand = new Command(DoGoBackCommand);
            SettingsCommand = new Command(DoSettingsCommand);
        }

        private void DoSettingsCommand(object obj)
        {
            new SettingsWindow() { Owner = this }.ShowDialog();
        }

        private void DoDetailCommand(object obj)
        {
            WorkshopView view = new WorkshopView();
            mainViewModel.PageContent = view;

            //动画
            //位移
            ThicknessAnimation thicknessAnimation = new ThicknessAnimation(
                new Thickness(0, 50, 0, -50), new Thickness(0, 0, 0, 0),
                new TimeSpan(0, 0, 0, 0, 400));
            //透明度
            DoubleAnimation doubleAnimation = new DoubleAnimation(0, 1, new TimeSpan(0, 0, 0, 0, 400));

            Storyboard.SetTarget(thicknessAnimation, view);
            Storyboard.SetTarget(doubleAnimation, view);
            Storyboard.SetTargetProperty(thicknessAnimation, new PropertyPath("Margin"));
            Storyboard.SetTargetProperty(doubleAnimation, new PropertyPath("Opacity"));

            Storyboard storyboard = new Storyboard();
            storyboard.Children.Add(thicknessAnimation);
            storyboard.Children.Add(doubleAnimation);
            storyboard.Begin();
        }
    
    
        private void DoGoBackCommand(object obj)
        {
            MonitorView monitor = new MonitorView();
            mainViewModel.PageContent = monitor;

            //透明度
            DoubleAnimation doubleAnimation = new DoubleAnimation(0, 1, new TimeSpan(0, 0, 0, 0, 400));

            Storyboard.SetTarget(doubleAnimation, monitor);
            Storyboard.SetTargetProperty(doubleAnimation, new PropertyPath("Opacity"));

            Storyboard storyboard = new Storyboard();
            storyboard.Children.Add(doubleAnimation);
            storyboard.Begin();
        }
    }
}
