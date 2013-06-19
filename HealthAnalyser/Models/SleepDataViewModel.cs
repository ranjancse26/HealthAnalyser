using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HealthAnalyser.Models
{
    public class SleepDataViewModel
    {
        public SleepDataViewModel()
        {
            this.SleepDataEntity = new List<SleepDataViewEntity>();
            this.SleepDataChart = new SleepDataViewForChart();
        }
        public List<SleepDataViewEntity> SleepDataEntity { get; set; }
        public SleepDataViewForChart SleepDataChart { get; set; }
    }

    public class SleepDataViewEntity
    {
        public string SleepingDateTime { get; set; }
        public int SleepMinutes { get; set; }
        public int SettlingMinutes { get; set; }
        public int Walk { get; set; }
    }

    public class SleepDataViewForChart
    {
        public string Labels { get; set; }
        public string SleepMinituesData { get; set; }
        public string SettlingMinituesData { get; set; }
    }
}