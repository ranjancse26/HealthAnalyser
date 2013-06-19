using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HealthAnalyser.Models
{
    public class ExerciseDataViewEntity
    {
        public string Activity { get; set; }
        public string Date { get; set; }
        public System.TimeSpan Time { get; set; }
        public string Description { get; set; }
        public int Duration { get; set; }
        public int Distance { get; set; }
    }

    public class ExerciseDataViewModel
    {
        public ExerciseDataViewModel()
        {
            this.ExerciseDataEntity = new List<ExerciseDataViewEntity>();
            this.ExerciseDataChart = new ExerciseDataViewForChart();
        }
        public List<ExerciseDataViewEntity> ExerciseDataEntity { get; set; }
        public ExerciseDataViewForChart ExerciseDataChart { get; set; }
    }

    public class ExerciseDataViewForChart
    {
        public string Labels { get; set; }
        public string DurationData { get; set; }
        public string DistanceData { get; set; }
    }
}