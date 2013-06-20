using HealthAnalyser.Helpers;
using HealthAnalyser.Models;
using System;
using System.Web.Mvc;

namespace HealthAnalyser.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult SleepData()
        {
            SleepDataViewModel sleepDataViewModel = new SleepDataViewModel();          
            try
            {
                sleepDataViewModel = new SleepDataHelper().GetViewModel();
                ViewBag.Error = "";
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
            }

            return View(sleepDataViewModel);
        }

        public ActionResult ExerciseData()
        {
            ExerciseDataViewModel exerciseDataViewModel = new ExerciseDataViewModel();          
            try
            {
                exerciseDataViewModel = new ExerciseDataHelper().GetViewModel();
                ViewBag.Error = "";
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
            }
            return View(exerciseDataViewModel);
        }

        public ActionResult BloodPressureData()
        {
            BloodPressureDataViewModel bloodPressureDataViewModel = new BloodPressureDataViewModel();
            try
            {
                bloodPressureDataViewModel = new BloodPressureDataHelper().GetViewModel();
                ViewBag.Error = "";
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
            }
            return View(bloodPressureDataViewModel);
        }

        public ActionResult WeightData()
        {
            WeightDataViewModel weightDataViewModel = new WeightDataViewModel();
            try
            {
                weightDataViewModel = new WeightDataHelper().GetViewModel();
                ViewBag.Error = "";
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
            }
            return View(weightDataViewModel);
        }


        public ActionResult WeightGoalData()
        {
            WeightGoalDataViewModel weightGoalDataViewModel = new WeightGoalDataViewModel();
            try
            {
                weightGoalDataViewModel = new WeightGoalDataHelper().GetViewModel();
                ViewBag.Error = "";
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
            }
            return View(weightGoalDataViewModel);
        }

        public ActionResult MoodData()
        {
            return View(new MoodDataViewModel());
        }

        [HttpPost]
        public ActionResult MoodData(MoodDataViewModel model)
        {
            var moodDataHelper = new MoodDataHelper(model.MoodDataEntity);
            var moodDataViewModel = new MoodDataViewModel();
            if (!ModelState.IsValid)
            {
                moodDataViewModel.MoodDataEntity = model.MoodDataEntity;
            }
            else
            {
                moodDataViewModel = moodDataHelper.GetViewModel();
            }
            return View(moodDataViewModel);
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }
    }
}
