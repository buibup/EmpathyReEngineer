using Empathy.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Empathy.Core
{
    public interface IBilledManager
    {
        Tuple<bool, IEnumerable<PatientBilledDTO>, int> UpdatePatientBilled();
    }
}
