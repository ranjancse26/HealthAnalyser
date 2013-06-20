using HealthAnalyser.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace HealthAnalyser.Helpers
{
    public class MoodDataHelper
    {
        MoodViewModelEntity viewModel;
        public MoodDataHelper(MoodViewModelEntity viewModel)
        {
            this.viewModel = viewModel;
        }

        private static string PutIntoQuotes(string value)
        {
            return "\"" + value + "\"";
        }

        public MoodDataViewModel GetViewModel()
        {
            DataSet ds = new DataSet();
            var moodDataViewModel = new MoodDataViewModel();
            moodDataViewModel.MoodDataEntity = viewModel; 

            ds.ReadXml(string.Format("http://moodpanda.com/api/user/feed/data.ashx?userid={0}&from={1}&to={2}&format=xml&DateOrder=ASC&key=5fe9dd40-1f55-4483-abb0-5540d7bf1b93", viewModel.UserId, viewModel.FromDate.Date.ToString("yyyy-MM-dd"), viewModel.ToDate.Date.ToString("yyyy-MM-dd")));
            if (ds.Tables.Count == 1)
            {
                string lables = "[";
                string ratingData = "[";
                foreach (DataRow item in ds.Tables[0].Rows)
                {
                    var splittedDate = item["Date"].ToString().Split('T');
                   
                    moodDataViewModel.MoodViewModelEntity.Add(new MoodViewModelEntity
                    {
                         Rating = int.Parse(item["Rating"].ToString()),
                         Reason = item["Reason"].ToString(),
                         Time = splittedDate[1].ToString()
                    });

                     lables = lables + PutIntoQuotes(splittedDate[0]) + ",";

                    ratingData = ratingData + item["Rating"].ToString() + ",";
                }

                lables = lables.Substring(0, lables.Length - 1) + "]";
                ratingData = ratingData.Substring(0, ratingData.Length - 1) + "]";

                moodDataViewModel.MoodDataViewForChart.Labels = lables.Replace(@"\", " ");
                moodDataViewModel.MoodDataViewForChart.RatingData = ratingData;
            }
            return moodDataViewModel;
        }
    }
}