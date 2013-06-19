using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthAnalyserDataAccess
{
    public class WeightDataRepository
    {
        public List<Weight> GetAllWeightData()
        {
            using (var dataContext = new HealthAnalyserEntities())
            {
                return dataContext.Weight.OrderBy(e => e.Date).ToList();
            }
        }
    }
}
