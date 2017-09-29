using Empathy.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Empathy.Core.DTOs
{
    public class PatientBilledDTO
    {
        public string PAPMI_No { get; set; }
        public IEnumerable<EpiBilled> ListEpiBilled { get; set; }
        public bool FlagBilled { get; set; }
        public string LastDateTimePrinted { get; set; }
    }

    public class EpiBilled
    {
        public string PAADM_ADMNO { get; set; }
        public IEnumerable<Billed> ListBilled { get; set; }
        public bool IsBilled { get; set; }
    }
}
