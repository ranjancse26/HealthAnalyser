using HealthAnalyser.Models;
using HealthAnalyserDataAccess;

namespace HealthAnalyser.Helpers
{
    public class ExerciseDataHelper
    {
        ExerciseDataViewModel exerciseDataViewModel;
        public ExerciseDataHelper()
        {
            exerciseDataViewModel = new ExerciseDataViewModel();           
        }

        private static string PutIntoQuotes(string value)
        {
            return "\"" + value + "\"";
        }

        public ExerciseDataViewModel GetViewModel()
        {
            var exerciseDataRepository = new ExerciseDataRepository();
            var exerciseDataList = exerciseDataRepository.GetAllExerciseData();
            foreach (var item in exerciseDataList)
            {
                exerciseDataViewModel.ExerciseDataEntity.Add(new ExerciseDataViewEntity
                {
                    Activity = item.Activity,
                    Date = item.Date.ToShortDateString(),
                    Description = item.Description,
                    Distance = item.Distance,
                    Duration = item.Duration,
                    Time = item.Time
                });
            }

            // Get Labels
            string lables = "[";
            foreach (var item in exerciseDataList)
            {
                lables = lables + PutIntoQuotes(item.Date.ToShortDateString()) + ",";
            }
            lables = lables.Substring(0, lables.Length - 1) + "]";

            exerciseDataViewModel.ExerciseDataChart.Labels = lables.Replace(@"\", " ");

            // Duration Data
            string durationData = "[";
            foreach (var item in exerciseDataList)
            {
                durationData = durationData + item.Duration.ToString() + ",";
            }
            durationData = durationData.Substring(0, durationData.Length - 1) + "]";
            exerciseDataViewModel.ExerciseDataChart.DurationData = durationData;

            // Distance Data
            string distanceData = "[";
            foreach (var item in exerciseDataList)
            {
                distanceData = distanceData + item.Distance.ToString() + ",";
            }
            distanceData = distanceData.Substring(0, distanceData.Length - 1) + "]";
            exerciseDataViewModel.ExerciseDataChart.DistanceData = distanceData;
            return exerciseDataViewModel;
        }
    }
}