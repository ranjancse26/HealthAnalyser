using HealthAnalyser.Models;
using HealthAnalyserDataAccess;

namespace HealthAnalyser.Helpers
{
    public class WeightDataHelper
    {
        WeightDataViewModel weightDataViewModel;
        public WeightDataHelper()
        {
            weightDataViewModel = new WeightDataViewModel();           
        }

        private static string PutIntoQuotes(string value)
        {
            return "\"" + value + "\"";
        }

        public WeightDataViewModel GetViewModel()
        {
            var weightDataRepository = new WeightDataRepository();
            var weightDataList = weightDataRepository.GetAllWeightData();
            foreach (var item in weightDataList)
            {
                weightDataViewModel.WeightDataEntity.Add(new WeightDataViewEntity
                {
                    Date = item.Date.ToShortDateString(),
                    Weight = item.WeightValue 
                });
            }

            // Get Labels
            string lables = "[";
            foreach (var item in weightDataList)
            {
                lables = lables + PutIntoQuotes(item.Date.ToShortDateString()) + ",";
            }
            lables = lables.Substring(0, lables.Length - 1) + "]";

            weightDataViewModel.WeightDataChart.Labels = lables.Replace(@"\", " ");

            // Weight Data
            string weightData = "[";
            foreach (var item in weightDataList)
            {
                weightData = weightData + item.WeightValue.ToString() + ",";
            }
            weightData = weightData.Substring(0, weightData.Length - 1) + "]";
            weightDataViewModel.WeightDataChart.WeightData = weightData;

            return weightDataViewModel;
        }
    }
}