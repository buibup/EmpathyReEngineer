using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Empathy.Core.Entities
{
    public class PaAdm
    {
        public string PAADM_ADMNo { get; set; }
        public DateTime PAADM_AdmDate { get; set; }
        public TimeSpan PAADM_AdmTime { get; set; }
        public string CTLOC_Code { get; set; }
        public string CTLOC_Desc { get; set; }
        public string CTPCP_Code { get; set; }
        public string CTPCP_Desc { get; set; }
        public string PAADM_Type { get; set; }
        public string PAADM_VisitStatus { get; set; }
        public string WARD_Code { get; set; } = "";
        public string WARD_Desc { get; set; } = "";
        public string ROOM_Code { get; set; } = "";
    }
}
