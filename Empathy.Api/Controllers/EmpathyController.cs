using Empathy.Core;
using Empathy.Core.DataAccess;
using Empathy.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Empathy.Api.Controllers
{
    public class EmpathyController:ApiController
    {
        ICacheDataConnection cacheData = GlobalConfig.CacheConnection;
        public PatientInfoDTO GetPatientInfo(string hn)
        {
            return cacheData.GetPatientInfo(hn);
        }
    }
}