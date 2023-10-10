using K2S.Automatic.Base;
using K2S.Automatic.Controls;
using K2S.Automatic.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace K2S.Automatic.ViewModels
{
    public class MainViewModel : NotifyBase
    {
        //private object _pageContent;

        //public object PageContent
        //{
        //    get { return _pageContent; }
        //    set { _pageContent = value; }
        //}
        private object _pageContent;

        public object PageContent
        {
            get { return _pageContent; }
            set { SetProperty(ref _pageContent, value); }
        }

        private string _total;

        public string Total
        {
            get { return _total; }
            set { SetProperty(ref _total, value); }
        }

        private string _productionCount;

        public string ProductionCount
        {
            get { return _productionCount; }
            set { SetProperty(ref _productionCount, value); }
        }

        private string _badCount;

        public string BadCount
        {
            get { return _badCount; }
            set { SetProperty(ref _badCount, value); }
        }

        public List<MonitorItemModel> Evironment { get; set; }
        public List<MonitorItemModel> DeviceMonitor { get; set; }
        public List<AlarmItemModel> AlarmList { get; set; }
        public ObservableCollection<RaderSeriesModel> RaderDatas { get; set; }
        public List<PersonnelItemModel> PersonnelList { get; set; }
        public List<WorkshopItemModel> WorkShopList { get; set; }

        public List<MachineItemModel> MachineList { get; set; }

        public MainViewModel()
        {
            Total = 210.ToString("0000");

            ProductionCount = 7147.ToString("00000");

            BadCount = 17.ToString("000");

            #region 初始化环境监控
            Evironment = new List<MonitorItemModel>();
            //Evironment.Add(new MonitorItemModel { Header = "光照(Lux)", Value = 130 });
            //Evironment.Add(new MonitorItemModel { Header = "噪音(db)", Value = 100 });
            //Evironment.Add(new MonitorItemModel { Header = "温度(C)", Value = 36 });
            //Evironment.Add(new MonitorItemModel { Header = "湿度(%)", Value = 40 });
            //Evironment.Add(new MonitorItemModel { Header = "PM2.5(m²)", Value = 105 });
            //Evironment.Add(new MonitorItemModel { Header = "氧气(ppm)", Value = 150 });
            //Evironment.Add(new MonitorItemModel { Header = "氮气(ppm)", Value = 230 });

            Evironment.Add(new MonitorItemModel { Header = "冲压", Value = 20 });
            Evironment.Add(new MonitorItemModel { Header = "钣金", Value = 22 });
            Evironment.Add(new MonitorItemModel { Header = "组装", Value = 10 });
            Evironment.Add(new MonitorItemModel { Header = "喷涂", Value = 30 });
            Evironment.Add(new MonitorItemModel { Header = "后加工", Value = 40 });
            #endregion

            #region 初始化消息列表
            AlarmList = new List<AlarmItemModel>();
            AlarmList.Add(new AlarmItemModel { Num = "01", Message = "FL0-2289折弯开裂", Time = "2022-06-05", Type="客诉" });
            AlarmList.Add(new AlarmItemModel { Num = "02", Message = "FA22-00511油污", Time = "2022-07-11", Type = "内部" });
            AlarmList.Add(new AlarmItemModel { Num = "03", Message = "FL4-2233攻牙滑牙", Time = "2022-07-22", Type = "内部" });
            AlarmList.Add(new AlarmItemModel { Num = "03", Message = "FL4-2288毛刺", Time = "2022-08-01", Type = "内部" });
            #endregion

            #region 初始化设备监控
            DeviceMonitor = new List<MonitorItemModel>();
            //DeviceMonitor.Add(new MonitorItemModel { Header = "电能(Kw.h)", Value = 311.2 });
            //DeviceMonitor.Add(new MonitorItemModel { Header = "电压(V)", Value = 380 });
            //DeviceMonitor.Add(new MonitorItemModel { Header = "电流(A)", Value = 20 });
            //DeviceMonitor.Add(new MonitorItemModel { Header = "压差(KPA)", Value = 311.2 });
            //DeviceMonitor.Add(new MonitorItemModel { Header = "温度(C)", Value = 37 });
            //DeviceMonitor.Add(new MonitorItemModel { Header = "振动(mm/s)", Value = 311.2 });
            //DeviceMonitor.Add(new MonitorItemModel { Header = "转速(r/min)", Value = 311.2 });
            //DeviceMonitor.Add(new MonitorItemModel { Header = "气压(kpa)", Value = 311.2 });

            DeviceMonitor.Add(new MonitorItemModel { Header = "冲压(万元)", Value = 600 });
            DeviceMonitor.Add(new MonitorItemModel { Header = "钣金(万元)", Value = 200 });
            DeviceMonitor.Add(new MonitorItemModel { Header = "组装(万元)", Value = 200 });
            DeviceMonitor.Add(new MonitorItemModel { Header = "喷涂(万元)", Value = 300 });
            DeviceMonitor.Add(new MonitorItemModel { Header = "后加工(万元)", Value = 100 });
            //DeviceMonitor.Add(new MonitorItemModel { Header = "振动(万元)", Value = 311.2 });
            //DeviceMonitor.Add(new MonitorItemModel { Header = "转速(万元)", Value = 311.2 });
            //DeviceMonitor.Add(new MonitorItemModel { Header = "气压(万元)", Value = 311.2 });
            #endregion

            #region 初始化雷达数据
            RaderDatas = new ObservableCollection<RaderSeriesModel>();
            Random random = new Random();
            for (int i = 0; i < 7; i++)
            {
                RaderDatas.Add(new RaderSeriesModel() { Header = "成本" + i, Value = random.Next(20, 100) });
            }
            #endregion

            #region 初始化人力
            PersonnelList = new List<PersonnelItemModel>();
            PersonnelList.Add(new PersonnelItemModel { Name = "张三", Duties = "组长", ManHour = 16 });
            PersonnelList.Add(new PersonnelItemModel { Name = "李四", Duties = "工程师", ManHour = 32 });
            PersonnelList.Add(new PersonnelItemModel { Name = "王五", Duties = "技术员", ManHour = 24 });
            PersonnelList.Add(new PersonnelItemModel { Name = "赵六", Duties = "作业员", ManHour = 40 });
            #endregion

            #region 初始化车间列表
            WorkShopList = new List<WorkshopItemModel>();
            WorkShopList.Add(new WorkshopItemModel { Name = "冲压车间", TotalCount = 100, WorkCount = 80, WaitCount = 15, FaultCount = 5, StopCount = 0 });
            WorkShopList.Add(new WorkshopItemModel { Name = "钣金车间", TotalCount = 20, WorkCount = 15, WaitCount = 0, FaultCount = 0, StopCount = 5 });
            WorkShopList.Add(new WorkshopItemModel { Name = "组装车间", TotalCount = 50, WorkCount = 40, WaitCount = 2, FaultCount = 5, StopCount = 3 });
            WorkShopList.Add(new WorkshopItemModel { Name = "喷涂车间", TotalCount = 10, WorkCount = 8, WaitCount = 0, FaultCount = 0, StopCount = 2 });
            WorkShopList.Add(new WorkshopItemModel { Name = "后加工车间", TotalCount = 30, WorkCount = 28, WaitCount = 1, FaultCount = 1, StopCount = 0 });
            #endregion

            #region 初始化机台列表
            MachineList = new List<MachineItemModel>();
            var nowStr = DateTime.Now.ToString("yyMMdd");
            for (int i = 0; i < 40; i++)
            {
                int plan = random.Next(1000, 5000);
                int complete = random.Next(0, plan);
                MachineList.Add(new MachineItemModel
                {
                    Name = $"冲压{i + 1}号机",
                    CompleteCount = complete,
                    PlanCount = plan,
                    ProgressValue = complete * 1.0 / plan * 100.0,
                    Status = "作业中",
                    OrderNum = $"ALD{nowStr}-{(i + 100).ToString().PadLeft(4, '0')}"
                }) ; 
            }
            #endregion
        }
    }
}
