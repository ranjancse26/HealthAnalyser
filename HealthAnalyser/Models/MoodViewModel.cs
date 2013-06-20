using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HealthAnalyser.Models
{
    public class MoodViewModelEntity
    {
        [Required]
        [Display(Name = "User ID")]
        public int UserId { get; set; }

        public string Reason { get; set; }
        
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "From Date")]        
        public DateTime FromDate { get; set; }
       
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "To Date")]
        public DateTime ToDate { get; set; }

        public int Rating { get; set; }

        [UIHint("Hidden")]
        public string Time { get; set; }
    }

    public class MoodDataViewModel
    {
        public MoodDataViewModel()
        {
            this.MoodViewModelEntity = new List<MoodViewModelEntity>();
            this.MoodDataViewForChart = new MoodDataViewForChart();
            this.MoodDataEntity = new MoodViewModelEntity();
        }

        public MoodViewModelEntity MoodDataEntity { get; set; }
        public List<MoodViewModelEntity> MoodViewModelEntity { get; set; }
        public MoodDataViewForChart MoodDataViewForChart { get; set; }
    }

    public class MoodDataViewForChart
    {
        public string Labels { get; set; }
        public string RatingData { get; set; }       
    }
}