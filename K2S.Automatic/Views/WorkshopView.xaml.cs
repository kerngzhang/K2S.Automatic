using System;
using System.Collections.Generic;
using System.Text;
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

namespace K2S.Automatic.Views
{
    /// <summary>
    /// WorkshopView.xaml 的交互逻辑
    /// </summary>
    public partial class WorkshopView : UserControl
    {
        public WorkshopView()
        {
            InitializeComponent();
        }

        private void Hyperlink_Click(object sender, RoutedEventArgs e)
        {//打开
            this.detail.Visibility = Visibility.Visible;
            //动画
            //位移
            ThicknessAnimation thicknessAnimation = new ThicknessAnimation(
                new Thickness(0, 50, 0, -50), new Thickness(0, 0, 0, 0),
                new TimeSpan(0, 0, 0, 0, 400));
            //透明度
            DoubleAnimation doubleAnimation = new DoubleAnimation(0, 1, new TimeSpan(0, 0, 0, 0, 400));

            Storyboard.SetTarget(thicknessAnimation, this.detail_content);
            Storyboard.SetTarget(doubleAnimation, this.detail_content);
            Storyboard.SetTargetProperty(thicknessAnimation, new PropertyPath("Margin"));
            Storyboard.SetTargetProperty(doubleAnimation, new PropertyPath("Opacity"));

            Storyboard storyboard = new Storyboard();
            storyboard.Children.Add(thicknessAnimation);
            storyboard.Children.Add(doubleAnimation);
            storyboard.Begin();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {//关闭
            //动画
            //位移
            ThicknessAnimation thicknessAnimation = new ThicknessAnimation(
                new Thickness(0, 0, 0, 0), new Thickness(0, 50, 0,-50),
                new TimeSpan(0, 0, 0, 0, 400));
            //透明度
            DoubleAnimation doubleAnimation = new DoubleAnimation(1, 0, new TimeSpan(0, 0, 0, 0, 400));

            Storyboard.SetTarget(thicknessAnimation, this.detail_content);
            Storyboard.SetTarget(doubleAnimation, this.detail_content);
            Storyboard.SetTargetProperty(thicknessAnimation, new PropertyPath("Margin"));
            Storyboard.SetTargetProperty(doubleAnimation, new PropertyPath("Opacity"));

            Storyboard storyboard = new Storyboard();
            storyboard.Children.Add(thicknessAnimation);
            storyboard.Children.Add(doubleAnimation);

            storyboard.Completed += (se, ev) =>
            {
                this.detail.Visibility = Visibility.Collapsed;
            };
            storyboard.Begin();
        }

    }
}
