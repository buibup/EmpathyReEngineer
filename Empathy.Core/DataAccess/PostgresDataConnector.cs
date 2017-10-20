using System;
using System.Collections.Generic;
using System.Net.Http;
using Empathy.Core.DTOs;
using Empathy.Core.Entities;

namespace Empathy.Core.DataAccess
{
    public class PostgresDataConnector : IPostgresDataConnection
    {
        public BeaconLocation GetBeaconLocation(string beaconId)
        {
            throw new NotImplementedException();
        }

        public HttpResponseMessage GetImagePostgresByHn(string hn, int width, int height)
        {
            throw new NotImplementedException();
        }

        public string GetLocationByLineBeacon(string beaconId)
        {
            throw new NotImplementedException();
        }

        public Tuple<bool, IEnumerable<PatientDischargesDTO>, int> UpdateAllDisch()
        {
            throw new NotImplementedException();
        }

        public Tuple<bool, IEnumerable<PatientBilledDTO>, int> UpdatePatientBilled()
        {
            throw new NotImplementedException();
        }

        public Tuple<bool, IEnumerable<PharCollectDTO>, int> UpdatePharCollect()
        {
            throw new NotImplementedException();
        }

        public Tuple<bool, string> UpdateRegisLoc(string hn)
        {
            throw new NotImplementedException();
        }
    }
}
