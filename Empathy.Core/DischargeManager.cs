using System;
using System.Collections.Generic;
using Empathy.Core.DTOs;

namespace Empathy.Core
{
    public class DischargeManager : IDischargeManager
    {
        public IEnumerable<DischargesDTO> GetDischgs(string hn)
        {
            throw new NotImplementedException();
        }

        public Tuple<bool, IEnumerable<PatientDischargesDTO>, int> UpdateAllDisch()
        {
            throw new NotImplementedException();
        }
    }
}
