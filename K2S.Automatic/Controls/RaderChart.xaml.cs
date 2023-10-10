using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace K2S.Automatic.Controls
{
    /// <summary>
    /// RaderChart.xaml 的交互逻辑
    /// </summary>
    public partial class RaderChart : UserControl
    {


        public ObservableCollection<RaderSeriesModel> ItemsSources
        {
            get { return (ObservableCollection<RaderSeriesModel>)GetValue(ItemsSourcesProperty); }
            set { SetValue(ItemsSourcesProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ItemsSourcesProperty =
            DependencyProperty.Register(
                "ItemsSources", 
                typeof(ObservableCollection<RaderSeriesModel>), 
                typeof(RaderChart), 
                new PropertyMetadata(null,new PropertyChangedCallback(OnPropertyChanged)));

        private static void OnPropertyChanged(DependencyObject d,DependencyPropertyChangedEventArgs e)
        {
            if (e.NewValue == null) return;
            (e.NewValue as ObservableCollection<RaderSeriesModel>).CollectionChanged += (se, ev) => 
            {
                (d as RaderChart).Refresh();
            };
        }

        private void Refresh()
        {
            if (ItemsSources.Count == 0) return;

            //清除历史数据
            this.mainCanvas.Children.Clear();
            this.p1.Points.Clear();
            this.p2.Points.Clear();
            this.p3.Points.Clear();
            this.p4.Points.Clear();
            this.p5.Points.Clear();

            //设置区域大小
            double size = Math.Min(RenderSize.Width, RenderSize.Height);
            this.LayoutRoot.Width = size;
            this.LayoutRoot.Height = size;

            //计算雷达圆半径
            double raduis = size / 2.0;

            double step = 360.0 / ItemsSources.Count;
            for (int i = 0; i < ItemsSources.Count; i++)
            {
                p1.Points.Add(new Point(
                    raduis + (raduis - 20) * Math.Cos((step * i - 90) * Math.PI / 180.0),
                    raduis + (raduis - 20) * Math.Sin((step * i - 90) * Math.PI / 180.0)
                    ));

                p2.Points.Add(new Point(
                    raduis + (raduis - 20) * Math.Cos((step * i - 90) * Math.PI / 180.0) * 0.25,
                    raduis + (raduis - 20) * Math.Sin((step * i - 90) * Math.PI / 180.0) * 0.25
                    ));

                p3.Points.Add(new Point(
                    raduis + (raduis - 20) * Math.Cos((step * i - 90) * Math.PI / 180.0) * 0.5,
                    raduis + (raduis - 20) * Math.Sin((step * i - 90) * Math.PI / 180.0) * 0.5
                    ));

                p4.Points.Add(new Point(
                    raduis + (raduis - 20) * Math.Cos((step * i - 90) * Math.PI / 180.0) * 0.75,
                    raduis + (raduis - 20) * Math.Sin((step * i - 90) * Math.PI / 180.0) * 0.75
                    ));

                p5.Points.Add(new Point(
                    raduis + (raduis - 20) * Math.Cos((step * i - 90) * Math.PI / 180.0) * ItemsSources[i].Value/100,
                    raduis + (raduis - 20) * Math.Sin((step * i - 90) * Math.PI / 180.0) * ItemsSources[i].Value/100
                    ));
                Line line = new Line();
                line.Stroke = new SolidColorBrush(Color.FromArgb(34, 255, 255, 255));
                line.X1 = raduis;
                line.Y1 = raduis;
                line.X2 = raduis + (raduis - 20) * Math.Cos((step * i - 90) * Math.PI / 180.0);
                line.Y2 = raduis + (raduis - 20) * Math.Sin((step * i - 90) * Math.PI / 180.0);
                this.mainCanvas.Children.Add(line);

                TextBlock text = new TextBlock();
                text.Width = 60;
                text.FontSize = 10;
                text.TextAlignment = TextAlignment.Center;
                text.Text = ItemsSources[i].Header;
                text.Foreground = new SolidColorBrush(Color.FromArgb(100, 255, 255, 255));
                text.SetValue(Canvas.LeftProperty, raduis + (raduis - 10) * Math.Cos((step * i - 90) * Math.PI / 180.0)-30);
                text.SetValue(Canvas.TopProperty, raduis + (raduis - 10) * Math.Sin((step * i - 90) * Math.PI / 180.0)-7);
                this.mainCanvas.Children.Add(text);
            }
        }

        public RaderChart()
        {
            InitializeComponent();
            this.SizeChanged += RaderChart_SizeChanged;
        }

        private void RaderChart_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            this.Refresh();
        }
    }

    public class RaderSeriesModel
    {
        public string Header { get; set; }
        public double Value { get; set; }
    }
}
