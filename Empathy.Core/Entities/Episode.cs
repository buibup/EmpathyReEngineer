using System.Collections.Generic;

namespace Empathy.Core.Entities
{
    public class Episode
    {
        public PaAdm PaAdm { get; set; }
        public IEnumerable<ICD10> ICD10 { get; set; }
        public IEnumerable<ICD9> ICD9 { get; set; }
        public IEnumerable<Appointment> AppConsults { get; set; }
    }
}
