using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthAnalyserDataAccess
{
    public class SleepDataRepository
    {
        public List<SleepData> GetAllSleepData()
        {
            using (var dataContext = new HealthAnalyserEntities())
            {
                return dataContext.SleepData.OrderBy(s => s.SleepingDateTime).ToList();
            }
        }
    }
}
