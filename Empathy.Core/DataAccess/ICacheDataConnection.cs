using Empathy.Core.DTOs;
using Empathy.Core.Entities;
using System.Collections.Generic;
using System.Net.Http;

namespace Empathy.Core.DataAccess
{
    public interface ICacheDataConnection
    {
        IEnumerable<DischargesDTO> GetDischgs(string hn);
        HttpResponseMessage GetImageByHn(string hn, int width, int height);
        IEnumerable<Location> GetLocation(string site);
        IEnumerable<Location> GetLocation(string site, string type);
        PatientInfoDTO GetPatientInfo(string hn);
        PatientInfoDTO GetPatientInfoPost(string hn);
    }
}
