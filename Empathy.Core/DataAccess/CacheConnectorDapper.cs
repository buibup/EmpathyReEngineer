using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using Empathy.Core.DTOs;
using Empathy.Core.Entities;
using static System.String;
using System.Text.RegularExpressions;
using InterSystems.Data.CacheClient;
using System.Data;
using Dapper;

namespace Empathy.Core.DataAccess
{
    public class CacheConnectorDapper : ICacheDataConnection
    {
        private const string db = "Cache89";

        public static IEnumerable<Appointment> GetApptConsult(IDbConnection connection, string epi)
        {
            var data = connection.Query<Appointment>(DbQuery.GetApptConsultByEpiNo(), new { epi }).ToList();

            return data;
        }

        public IEnumerable<DischargesDTO> GetDischgs(string hn)
        {
            throw new NotImplementedException();
        }

        public static IEnumerable<ICD9> GetICD9ByEpi(IDbConnection connection, string epi)
        {

            var data = connection.Query<ICD9>(DbQuery.GetIcd9ByEpiNo(), new { epi }).ToList();

            return data;
        }
        
        public static IEnumerable<ICD10> GetICD10ByEpi(IDbConnection connection, string epi)
        {
            var data = connection.Query<ICD10>(DbQuery.GetIcd10ByEpiNo(), new { epi }).ToList();

            return data;
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
            var ptInfo = new PatientInfoDTO();

            if (IsNullOrEmpty(hn)) return ptInfo;

            if (!hn.Contains("-"))
            {
                hn = Regex.Replace(hn, @"^(.{2})(.{2})(.{6})$", "$1-$2-$3");
            }

            using (IDbConnection conn = new CacheConnection(GlobalConfig.CnnString(db)))
            {
                var paPatmas = conn.Query<PaPatmas>(DbQuery.GetPatientInfo(), new { hn }).SingleOrDefault();

                if (paPatmas == null) return ptInfo;

                ptInfo.PAPMI_No = paPatmas.PAPMI_No;
                ptInfo.Name = IsNullOrEmpty(paPatmas.TTL_Desc) ? "" : paPatmas.TTL_Desc +
                    paPatmas.PAPMI_Name + " " + paPatmas.PAPMI_Name2;
                ptInfo.PAPMI_DOB = paPatmas.PAPMI_DOB.ToString("O");
                ptInfo.PAPER_AgeYr = paPatmas.PAPER_AgeYr;
                ptInfo.PAPER_AgeMth = paPatmas.PAPER_AgeMth;
                ptInfo.PAPER_AgeDay = paPatmas.PAPER_AgeDay;
                ptInfo.CTSEX_Desc = paPatmas.CTSEX_Desc;
                ptInfo.PAPER_StName = paPatmas.PAPER_StName;
                ptInfo.CTCIT_Desc = paPatmas.CTCIT_Desc;
                ptInfo.PAPER_TelH = paPatmas.PAPER_TelH;
                ptInfo.SetAddress(paPatmas.CITAREA_Desc, paPatmas.PROV_Desc, paPatmas.CTZIP_Code);
                ptInfo.IsImage = HasImage(conn, hn);
                ptInfo.PatientCategory = new PatientCategory(paPatmas.PCAT_Code, paPatmas.PCAT_Desc);
                ptInfo.AlertMsgs = GetPatientAlertMsg(conn, hn);
                ptInfo.Episode = GetPatientEpisode(conn, hn);
                ptInfo.Appointments = GetPatientAppointment(conn, hn);
            }

            return ptInfo;
        }

        private bool HasImage(IDbConnection connection, string hn)
        {
            var data = connection.Query<byte[]>(DbQuery.GetPatientImage(), new { hn }).SingleOrDefault();

            if(data == null) return false;

            return data.IsValidImage();
        }

        private static IEnumerable<AlertMsg> GetPatientAlertMsg(IDbConnection connection, string hn)
        {
            var data = connection.Query<AlertMsg>(DbQuery.GetPatientAlertMsg(), new { hn }).ToList();

            if (data == null) return new List<AlertMsg>();

            return data;
        }

        private static IEnumerable<Appointment> GetPatientAppointment(IDbConnection connection, string hn)
        {
            var app = connection.Query<Appointment>(DbQuery.GetPatientAppointments(), new { PAPMI_No = hn, PAPMI_No1 = hn } ).ToList();
            var appPast = connection.Query<Appointment>(DbQuery.GetPatientAppointmentsPast(), new { PAPMI_No = hn, PAPMI_No1 = hn }).ToList();
            var appCurrent = connection.Query<Appointment>(DbQuery.GetPatientAppointmentsCurrent(), new { hn }).ToList();

            var apps = app.Concat(appPast).Concat(appCurrent);

            try
            {
                apps = apps.OrderByDescending(a => a.AS_Date).ThenByDescending(a => a.AS_SessStartTime).ToList();
            }
            catch (Exception)
            {
                return apps;
            }

            return apps;
        }

        private static EpisodeDTO GetPatientEpisode(IDbConnection connection, string hn)
        {
            var paadmList = connection.Query<PaAdm>(DbQuery.GetPatientEpisodeInquiry(), new { hn }).ToList();

            var data = paadmList.ConvertPaAdmListToEpisodeList(connection);

            return data;
        }
        
        public PatientInfoDTO GetPatientInfoPost(string hn)
        {
            throw new NotImplementedException();
        }
    }
}
