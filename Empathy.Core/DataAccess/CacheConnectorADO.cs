using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Empathy.Core.DTOs;
using Empathy.Core.Entities;

namespace Empathy.Core.DataAccess
{
    public class CacheConnectorADO : ICacheDataConnection
    {
        public IEnumerable<DischargesDTO> GetDischgs(string hn)
        {
            throw new NotImplementedException();
        }

        public HttpResponseMessage GetImageByHn(string hn, int width, int height)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Location> GetLocation(string site)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Location> GetLocation(string site, string type)
        {
            throw new NotImplementedException();
        }

        public PatientInfoDTO GetPatientInfo(string hn)
        {
            throw new NotImplementedException();
        }

        public PatientInfoDTO GetPatientInfoPost(string hn)
        {
            throw new NotImplementedException();
        }
    }
}
