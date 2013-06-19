using HealthAnalyser.Models;
using HealthAnalyserDataAccess;

namespace HealthAnalyser.Helpers
{
    public class BloodPressureDataHelper
    {
        BloodPressureDataViewModel bloodPressureDataViewModel;
        public BloodPressureDataHelper()
        {
            bloodPressureDataViewModel = new BloodPressureDataViewModel();           
        }

        private static string PutIntoQuotes(string value)
        {
            return "\"" + value + "\"";
        }

        public BloodPressureDataViewModel GetViewModel()
        {
            var bloodPressureDataRepository = new BloodPressureDataRepository();
            var bloodPressureDataList = bloodPressureDataRepository.GetAllBloodPressureData();
            foreach (var item in bloodPressureDataList)
            {
                bloodPressureDataViewModel.BloodPressureDataEntity.Add(new BloodPressureDataViewEntity
                {
                    Date = item.Date.ToShortDateString(),
                    Diastolic = item.Diastolic,
                    Systolic = item.Systolic,
                    Pulse = item.Pulse 
                });
            }

            // Get Labels
            string lables = "[";
            foreach (var item in bloodPressureDataList)
            {
                lables = lables + PutIntoQuotes(item.Date.ToShortDateString()) + ",";
            }
            lables = lables.Substring(0, lables.Length - 1) + "]";

            bloodPressureDataViewModel.BloodPressureDataChart.Labels = lables.Replace(@"\", " ");

            // Systolic Data
            string systolicData = "[";
            foreach (var item in bloodPressureDataList)
            {
                systolicData = systolicData + item.Systolic.ToString() + ",";
            }
            systolicData = systolicData.Substring(0, systolicData.Length - 1) + "]";
            bloodPressureDataViewModel.BloodPressureDataChart.SystolicData = systolicData;

            // Diastolic Data
            string diastolicData = "[";
            foreach (var item in bloodPressureDataList)
            {
                diastolicData = diastolicData + item.Diastolic.ToString() + ",";
            }
            diastolicData = diastolicData.Substring(0, diastolicData.Length - 1) + "]";
            bloodPressureDataViewModel.BloodPressureDataChart.DiastolicData = diastolicData;

            // Pulse Data
            string pulseData = "[";
            foreach (var item in bloodPressureDataList)
            {
                pulseData = pulseData + item.Pulse.ToString() + ",";
            }
            pulseData = pulseData.Substring(0, pulseData.Length - 1) + "]";
            bloodPressureDataViewModel.BloodPressureDataChart.PulseData = pulseData;
            return bloodPressureDataViewModel;
        }
    }
}