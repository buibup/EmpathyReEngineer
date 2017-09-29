using Empathy.Core.Entities;
using System.Collections.Generic;

namespace Empathy.Core.DTOs
{
    public class DischargesDTO
    {
        public IEnumerable<Discharge> MedDischs { get; set; }
        public bool IsMedDischs { get; set; }
        public IEnumerable<Discharge> FinDischs { get; set; }
        public bool IsFinDischs { get; set; }
        public IEnumerable<Discharge> Dischgs { get; set; }
        public bool IsDischgs { get; set; }
    }
}
