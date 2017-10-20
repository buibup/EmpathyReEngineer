using Empathy.Core.DTOs;
using Empathy.Core.Entities;
using System;
using System.Collections.Generic;
using System.Net.Http;

namespace Empathy.Core.DataAccess
{
    public interface IPostgresDataConnection
    {
        Tuple<bool, IEnumerable<PatientBilledDTO>, int> UpdatePatientBilled();
        Tuple<bool, IEnumerable<PatientDischargesDTO>, int> UpdateAllDisch();
        HttpResponseMessage GetImagePostgresByHn(string hn, int width, int height);
        Tuple<bool, IEnumerable<PharCollectDTO>, int> UpdatePharCollect();
        Tuple<bool, string> UpdateRegisLoc(string hn);
        BeaconLocation GetBeaconLocation(string beaconId);
        string GetLocationByLineBeacon(string beaconId);
    }
}
