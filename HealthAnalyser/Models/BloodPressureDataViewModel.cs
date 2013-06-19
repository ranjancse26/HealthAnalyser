using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HealthAnalyser.Models
{
    public class BloodPressureDataViewEntity
    {
        public string Date { get; set; }
        public int Systolic { get; set; }
        public int Diastolic { get; set; }
        public int Pulse { get; set; }
    }

    public class BloodPressureDataViewModel
    {
        public BloodPressureDataViewModel()
        {
            this.BloodPressureDataEntity = new List<BloodPressureDataViewEntity>();
            this.BloodPressureDataChart = new BloodPressureDataViewForChart();
        }
        public List<BloodPressureDataViewEntity> BloodPressureDataEntity { get; set; }
        public BloodPressureDataViewForChart BloodPressureDataChart { get; set; }
    }

    public class BloodPressureDataViewForChart
    {
        public string Labels { get; set; }
        public string SystolicData { get; set; }
        public string DiastolicData { get; set; }
        public string PulseData { get; set; }
    }
}