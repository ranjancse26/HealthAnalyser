using HealthAnalyser.Models;
using HealthAnalyserDataAccess;

namespace HealthAnalyser.Helpers
{
    public class SleepDataHelper
    {
        SleepDataViewModel sleepDataViewModel;
        public SleepDataHelper()
        {
            sleepDataViewModel = new SleepDataViewModel();           
        }

        private static string PutIntoQuotes(string value)
        {
            return "\"" + value + "\"";
        }

        public SleepDataViewModel GetViewModel()
        {
            var sleepDataRepository = new SleepDataRepository();
            var sleepDataList = sleepDataRepository.GetAllSleepData();
            foreach (var item in sleepDataList)
            {
                sleepDataViewModel.SleepDataEntity.Add(new SleepDataViewEntity
                {
                    SettlingMinutes = item.SettlingMinutes,
                    SleepingDateTime = item.SleepingDateTime.Date.ToShortDateString(),
                    SleepMinutes = item.SleepMinutes,
                    Walk = item.Walk
                });
            }

            // Get Labels
            string lables = "[";
            foreach (var item in sleepDataList)
            {
                lables = lables + PutIntoQuotes(item.SleepingDateTime.Date.ToShortDateString()) + ",";
            }
            lables = lables.Substring(0, lables.Length - 1) + "]";

            sleepDataViewModel.SleepDataChart.Labels = lables.Replace(@"\", " ");

            // Sleeping Minutes Data
            string sleepData = "[";
            foreach (var item in sleepDataList)
            {
                sleepData = sleepData + item.SleepMinutes.ToString() + ",";
            }
            sleepData = sleepData.Substring(0, sleepData.Length - 1) + "]";
            sleepDataViewModel.SleepDataChart.SleepMinituesData = sleepData;

            // Settling Minitues Data
            string settlingMinituresData = "[";
            foreach (var item in sleepDataList)
            {
                settlingMinituresData = settlingMinituresData + item.SettlingMinutes.ToString() + ",";
            }
            settlingMinituresData = settlingMinituresData.Substring(0, settlingMinituresData.Length - 1) + "]";
            sleepDataViewModel.SleepDataChart.SettlingMinituesData = settlingMinituresData;
            return sleepDataViewModel;
        }
    }
}