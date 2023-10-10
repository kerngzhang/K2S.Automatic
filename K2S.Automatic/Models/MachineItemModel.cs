using System;
using System.Collections.Generic;
using System.Text;

namespace K2S.Automatic.Models
{
    public class MachineItemModel
    {
        public string Name { get; set; }
        public double ProgressValue { get; set; }
        public string Status { get; set; }
        public string ProgressText { get; set; }
        public int CompleteCount { get; set; }
        public int PlanCount { get; set; }
        public string OrderNum { get; set; }
    }
}
