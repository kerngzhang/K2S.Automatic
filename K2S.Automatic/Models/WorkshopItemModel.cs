using System;
using System.Collections.Generic;
using System.Text;

namespace K2S.Automatic.Models
{
    public class WorkshopItemModel
    {
        public string Name { get; set; }
        public int TotalCount { get; set; }
        public int WorkCount { get; set; }
        public int WaitCount { get; set; }
        public int FaultCount { get; set; }
        public int StopCount { get; set; }
    }
}
