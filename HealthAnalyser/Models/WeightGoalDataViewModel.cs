using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HealthAnalyser.Models
{
    public class WeightGoalDataViewEntity
    {
        public string Date { get; set; }
        public int InitialValue { get; set; }
        public int MinValue { get; set; }
        public int MaxValue { get; set; }
        public string Time { get; set; }
    }

    public class WeightGoalDataViewModel
    {
        public WeightGoalDataViewModel()
        {
            this.WeightGoalDataEntity = new List<WeightGoalDataViewEntity>();
            this.WeightGoalDataChart = new WeightGoalDataViewForChart();
        }
        public List<WeightGoalDataViewEntity> WeightGoalDataEntity { get; set; }
        public WeightGoalDataViewForChart WeightGoalDataChart { get; set; }
    }

    public class WeightGoalDataViewForChart
    {
        public string Labels { get; set; }
        public string InitialWeightData { get; set; }
        public string MinWeightData { get; set; }
        public string MaxWeightData { get; set; }
    }
}