using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// CircularProgressBar.xaml 的交互逻辑
    /// </summary>
    public partial class CircularProgressBar : UserControl
    {


        public double Value
        {
            get { return (double)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Value.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.Register("Value", typeof(double), typeof(CircularProgressBar),
                new PropertyMetadata(0.0,new PropertyChangedCallback(OnPropertyChanged)));

        private static void OnPropertyChanged(DependencyObject d,DependencyPropertyChangedEventArgs e)
        {
            (d as CircularProgressBar).Refresh();
        }

        public CircularProgressBar()
        {
            InitializeComponent();
            this.SizeChanged += CircularProgressBar_SizeChanged;
        }

        private void CircularProgressBar_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            this.Refresh();
        }

        private void Refresh()
        {
            this.LayoutRoot.Width = Math.Min(this.RenderSize.Width, this.RenderSize.Height);
            double radius = this.LayoutRoot.Width / 2.0;
            if (radius <= 0) return;

            double newX = 0.0;
            double newY = 0.0;

            newX = radius + (radius - 3) * Math.Cos((this.Value % 100 * 3.6 - 90) * Math.PI / 180.0);
            newY = radius + (radius - 3) * Math.Sin((this.Value % 100 * 3.6 - 90) * Math.PI / 180.0);

            string pathDataStr = "M{0} 3A{3} {3} 0 {4} 1 {1} {2}";
            pathDataStr = string.Format(pathDataStr, 
                radius + 0.01, 
                newX,
                newY, 
                radius - 3,
                this.Value < 50 ? 0 : 1);
            var converter = TypeDescriptor.GetConverter(typeof(Geometry));
            this.path.Data = converter.ConvertFrom(pathDataStr) as Geometry;
        }
    }
}
