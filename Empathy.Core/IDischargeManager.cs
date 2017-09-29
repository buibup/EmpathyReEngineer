using Empathy.Core.DTOs;
using System;
using System.Collections.Generic;

namespace Empathy.Core
{
    public interface IDischargeManager
    {
        IEnumerable<DischargesDTO> GetDischgs(string hn);
        Tuple<bool, IEnumerable<PatientDischargesDTO>, int> UpdateAllDisch();
    }
}
