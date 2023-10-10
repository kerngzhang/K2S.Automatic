using K2S.Automatic.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace K2S.Automatic.Models
{
    public class MonitorItemModel:NotifyBase
    {
        public string Header { get; set; }
        private double _value;

        public double Value
        {
            get { return _value; }
            set { SetProperty(ref _value, value); }
        }

    }
}
