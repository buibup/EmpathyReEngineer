using Empathy.Core.Entities;
using System.Collections.Generic;

namespace Empathy.Core.DTOs
{
    public class PharCollectDTO
    {
        public string PAPMI_No { get; set; }
        public IEnumerable<EpiPharCollect> EpiPharCollectList { get; set; }
        public bool HnCollect { get; set; }
        public string LastCollectDateTime { get; set; }
    }

    public class EpiPharCollect
    {
        public string PAADM_ADMNo { get; set; }
        public IEnumerable<PharPrescNo> PharPrescNoList { get; set; }
        public bool EpiCollect { get; set; }
        public int TotalPharPrescNo { get; set; }
    }
}
