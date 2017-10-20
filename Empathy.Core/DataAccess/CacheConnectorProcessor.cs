using System;
using System.Data;
using System.IO;
using System.Drawing;
using Empathy.Core.Entities;
using System.Collections;
using System.Collections.Generic;
using Empathy.Core.DTOs;

namespace Empathy.Core.DataAccess
{
    public static class CacheConnectorProcessor
    {
        public static EpisodeDTO ConvertPaAdmListToEpisodeList(this List<PaAdm> paadms, IDbConnection connection)
        {
            var epiList = new List<Episode>();

            foreach(var paadm in paadms)
            {
                var epi = new Episode();
                epi.PaAdm = paadm;
                epi.ICD10 = CacheConnectorDapper.GetICD10ByEpi(connection, paadm.PAADM_ADMNo);
                epi.ICD9 = CacheConnectorDapper.GetICD9ByEpi(connection, paadm.PAADM_ADMNo);
                epi.AppConsults = CacheConnectorDapper.GetApptConsult(connection, paadm.PAADM_ADMNo);

                epiList.Add(epi);
            }

            return new EpisodeDTO() { Episode = epiList };
        }

        public static bool IsValidImage(this DataTable dt)
        {
            if (dt.Rows.Count <= 0) return false;
            if (string.IsNullOrEmpty(dt.Rows[0][0].ToString())) return false;

            try
            {
                var data = (byte[])dt.Rows[0][0];
                if (!(data != null && data.Length > 0))
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public static bool IsValidImage(this byte[] bytes)
        {
            try
            {
                using (MemoryStream ms = new MemoryStream(bytes))
                    Image.FromStream(ms);
            }
            catch (ArgumentException)
            {
                return false;
            }
            return true;
        }
    }
}
