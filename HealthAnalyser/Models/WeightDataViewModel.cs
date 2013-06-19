using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HealthAnalyser.Models
{
    public class WeightDataViewEntity
    {
        public string Date { get; set; }
        public int Weight { get; set; }
    }

    public class WeightDataViewModel
    {
        public WeightDataViewModel()
        {
            this.WeightDataEntity = new List<WeightDataViewEntity>();
            this.WeightDataChart = new WeightDataViewForChart();
        }
        public List<WeightDataViewEntity> WeightDataEntity { get; set; }
        public WeightDataViewForChart WeightDataChart { get; set; }
    }

    public class WeightDataViewForChart
    {
        public string Labels { get; set; }
        public string WeightData { get; set; }
    }
}