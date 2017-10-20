using Empathy.Core.Entities;
using System.Collections.Generic;

namespace Empathy.Core.DTOs
{
    public class PatientInfoDTO
    {
        public void SetAddress(string CITAREA_Desc, string PROV_Desc, string CTZIP_Code)
        {
            Address = $"{PAPER_StName} {CITAREA_Desc} {CTCIT_Desc} {PROV_Desc} {CTZIP_Code}";
        }
        public string PAPMI_No { get; set; }
        public string Name { get; set; }
        public string PAPMI_DOB { get; set; }
        public int PAPER_AgeYr { get; set; }
        public int PAPER_AgeMth { get; set; }
        public int PAPER_AgeDay { get; set; }
        public string CTSEX_Desc { get; set; }
        public string PAPER_StName { get; set; }
        public string CTCIT_Desc { get; set; }
        public string Address { get; private set; }
        public string PAPER_TelH { get; set; }
        public bool IsImage { get; set; }
        public PatientCategory PatientCategory { get; set; }
        public IEnumerable<AlertMsg> AlertMsgs { get; set; }
        public EpisodeDTO Episode { get; set; }
        public IEnumerable<Appointment> Appointments { get; set; }
        public IEnumerable<Allergy> Allergys { get; set; }
        public IEnumerable<CRM> CRMs { get; set; }
    }

    public class PatientCategory
    {
        public PatientCategory(string code = "", string desc = "")
        {
            PCAT_CODE = code;
            PCAT_Desc = desc;
        }
        public string PCAT_CODE { get; private set; }
        public string PCAT_Desc { get; private set; }
    }
}
