using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthAnalyserDataAccess
{
    public class WeightGoalDataRepository
    {
        public List<WeightGoal> GetAllWeightGoalData()
        {
            using (var dataContext = new HealthAnalyserEntities())
            {
                return dataContext.WeightGoal.OrderBy(e => e.Date).ToList();
            }
        }
    }
}
