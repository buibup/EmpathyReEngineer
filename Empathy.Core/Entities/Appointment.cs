﻿using System;

namespace Empathy.Core.Entities
{
    public class Appointment
    {
        public DateTime AS_Date { get; set; }
        public TimeSpan AS_SessStartTime { get; set; }
        public string APPT_Status { get; set; }
        public string PAADM_VisitStatus { get; set; }
        public string CTLOC_Code { get; set; }
        public string CTLOC_Desc { get; set; }
        public string CTPCP_Desc { get; set; }
        public string SER_Desc { get; set; }
    }
}
