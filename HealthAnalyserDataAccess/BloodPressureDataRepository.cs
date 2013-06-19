using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthAnalyserDataAccess
{
    public class BloodPressureDataRepository
    {
        public List<BloodPressure> GetAllBloodPressureData()
        {
            using (var dataContext = new HealthAnalyserEntities())
            {
                return dataContext.BloodPressure.OrderBy(e => e.Date).ToList();
            }
        }
    }
}
