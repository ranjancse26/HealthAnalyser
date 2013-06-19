using HealthAnalyser.Models;
using HealthAnalyserDataAccess;

namespace HealthAnalyser.Helpers
{
    public class WeightGoalDataHelper
    {
        WeightGoalDataViewModel weightGoalDataViewModel;
        public WeightGoalDataHelper()
        {
            weightGoalDataViewModel = new WeightGoalDataViewModel();           
        }

        private static string PutIntoQuotes(string value)
        {
            return "\"" + value + "\"";
        }

        public WeightGoalDataViewModel GetViewModel()
        {
            var weightGoalDataRepository = new WeightGoalDataRepository();
            var weightGoalDataList = weightGoalDataRepository.GetAllWeightGoalData();
            foreach (var item in weightGoalDataList)
            {
                weightGoalDataViewModel.WeightGoalDataEntity.Add(new WeightGoalDataViewEntity
                {
                    Date = item.Date.ToShortDateString(),
                    InitialValue = item.InitialValue,
                    MaxValue = item.MaxValue,
                    MinValue = item.MinValue,
                    Time = item.Time.ToString()
                });
            }

            // Get Labels
            string lables = "[";
            foreach (var item in weightGoalDataList)
            {
                lables = lables + PutIntoQuotes(item.Date.ToShortDateString()) + ",";
            }
            lables = lables.Substring(0, lables.Length - 1) + "]";

            weightGoalDataViewModel.WeightGoalDataChart.Labels = lables.Replace(@"\", " ");

            // Initial Weight Data
            string weightGoalData = "[";
            foreach (var item in weightGoalDataList)
            {
                weightGoalData = weightGoalData + item.InitialValue.ToString() + ",";
            }
            weightGoalData = weightGoalData.Substring(0, weightGoalData.Length - 1) + "]";
            weightGoalDataViewModel.WeightGoalDataChart.InitialWeightData = weightGoalData;

            // Min Weight Data
            string minWeightGoalData = "[";
            foreach (var item in weightGoalDataList)
            {
                minWeightGoalData = minWeightGoalData + item.MinValue.ToString() + ",";
            }
            minWeightGoalData = minWeightGoalData.Substring(0, minWeightGoalData.Length - 1) + "]";
            weightGoalDataViewModel.WeightGoalDataChart.MinWeightData = minWeightGoalData;

            // Max Weight Data
            string maxWeightGoalData = "[";
            foreach (var item in weightGoalDataList)
            {
                maxWeightGoalData = maxWeightGoalData + item.MaxValue.ToString() + ",";
            }
            maxWeightGoalData = maxWeightGoalData.Substring(0, maxWeightGoalData.Length - 1) + "]";
            weightGoalDataViewModel.WeightGoalDataChart.MaxWeightData = maxWeightGoalData;

            return weightGoalDataViewModel;
        }
    }
}