using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthAnalyserDataAccess
{
    public class ExerciseDataRepository
    {
        public List<Exercise> GetAllExerciseData()
        {
            using (var dataContext = new HealthAnalyserEntities())
            {
                return dataContext.Exercise.OrderBy(e => e.Date).ToList();
            }
        }
    }
}
